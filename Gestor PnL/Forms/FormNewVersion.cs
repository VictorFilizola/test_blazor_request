using DevExpress.XtraEditors;
using Gestor_PnL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.ReportServer.Printing.RemoteDocumentSource;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gestor_PnL.Forms
{
    public partial class FormNewVersion : DevExpress.XtraEditors.XtraForm
    {
        public FormNewVersion()
        {
            InitializeComponent();
        }

        private void simpleButtonCreateVersion_Click(object sender, EventArgs e)
        {
            decimal valueTotalInvestment = 0;
            try
            {
                valueTotalInvestment = Convert.ToDecimal(textEditInvestmenteValue.Text);
                SQLConnectionClass SQLCon = new SQLConnectionClass();
                try
                {
                    //create new version at SQL server
                    //declare version variables
                    string status = "Em atuação";
                    string step = "Etapa 1 - Valores Diretorias";
                    decimal plannedInvestment = valueTotalInvestment;
                    decimal usedInvestment = 00;
                    DateTime dateCreation = DateTime.Now;
                    string finishDate = "0000-00-00 00:00:00.000";

                    SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                    SqlParameter[] dataNewVersionParent =
                    {
                    new SqlParameter("@status", SqlDbType.VarChar, 100) { Value = status },
                    new SqlParameter("@step", SqlDbType.VarChar, 100) { Value = step },
                    new SqlParameter("@plannedInvestment", SqlDbType.Decimal) { Value = plannedInvestment },
                    new SqlParameter("@usedInvestment", SqlDbType.Decimal, 100) { Value = usedInvestment },
                    new SqlParameter("@dateCreation", SqlDbType.DateTime, 50) { Value = dateCreation },
                    new SqlParameter("@finishDate", SqlDbType.DateTime, 50) { Value = dateCreation },
                    };
                    SQLCon.ExecuteNoQuerySQL($"INSERT INTO versionParent VALUES (@status, @step, @plannedInvestment, @usedInvestment, @dateCreation, @finishDate)", "", dataNewVersionParent, false);

                    //get the id of the most recent created contract
                    SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                    SQLCon.RetornaDataTable("SELECT TOP 1 * FROM versionParent ORDER BY [creationDate] DESC");
                    string currentVersionID = Convert.ToString(SQLCon.DataTable.Rows[0][0]);

                    //create VP values at SQL Server
                    SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                    SQLCon.RetornaDataTable("SELECT * FROM [vps]");
                    for (int i = 0; i < SQLCon.DataTable.Rows.Count; i++)
                    {
                        SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);

                        string vp = SQLCon.DataTable.Rows[i][1].ToString();
                        string vpUser = SQLCon.DataTable.Rows[i][2].ToString();

                        SqlParameter[] dataNewParentVP =
                        {
                        new SqlParameter("@status", SqlDbType.VarChar, 100) { Value = "Status 0 - Criado" },
                        new SqlParameter("@versionID", SqlDbType.VarChar, 100) { Value = currentVersionID },
                        new SqlParameter("@vpName", SqlDbType.VarChar, 200) { Value = vp },
                        new SqlParameter("@vpUser", SqlDbType.VarChar, 200) { Value = vpUser },
                        new SqlParameter("@totalInvestment", SqlDbType.Decimal, 100) { Value = "0" },
                        };
                        SQLCon.ExecuteNoQuerySQL($"INSERT INTO [vpParent] VALUES (@status, @versionID, @vpName, @vpUser, @totalInvestment)", "", dataNewParentVP, false);
                    }

                    Close();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "Erro na conexão com o servidor SQL");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro no valor de despesa. Por favor, inserir valor em número");
                return;
            }
        }

        private void FormNewVersion_FormClosed(object sender, FormClosedEventArgs e)
        {
            //enable main form
            FormPrincipal.instance.barButtonItemManageVersionsInstance.PerformClick();

            HelperClass.enableMainForm();
        }
    }
}