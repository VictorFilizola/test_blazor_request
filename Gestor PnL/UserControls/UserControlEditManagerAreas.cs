using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Gestor_PnL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Gestor_PnL.UserControls
{
    public partial class UserControlEditManagerAreas : XtraUserControl
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();
        EmailHandlerClass EmailHandlerClass = new EmailHandlerClass();

        public UserControlEditManagerAreas()
        {
            InitializeComponent();

            //gridControlCostCenters

            string getCurrentVPArea = @$"SELECT TOP (1)
                                              [versionID]
                                              ,[vpName]
                                              ,[totalInvestment]
                                              ,[vpID]
                                        FROM 
	                                        [PLEDIGITAL].[dbo].[vpParent] 
                                        WHERE 
	                                        [vpUser] LIKE '%{UserClass.userName}%' 
                                        ORDER BY 
	                                        [VersionID] 
                                        DESC";
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(getCurrentVPArea);
            var firstCellValue = SQLCon.DataTable.Rows[0][2];
            GlobalVariablesClass.currentVersionInvestment = Convert.ToString(firstCellValue);
            GlobalVariablesClass.currentVPArea = Convert.ToString(SQLCon.DataTable.Rows[0][1]);
            GlobalVariablesClass.currentVersion = Convert.ToString(SQLCon.DataTable.Rows[0][0]);
            GlobalVariablesClass.currentVPID = Convert.ToString(SQLCon.DataTable.Rows[0][3]);

            //MessageBox.Show($"investimento {GlobalVariablesClass.currentVersionInvestment}, currentVP {GlobalVariablesClass.currentVPArea}, currentVersion {GlobalVariablesClass.currentVersion}, ID {GlobalVariablesClass.currentVPID} ");
            
            labelControlInvestiment.Text = GlobalVariablesClass.currentVersionInvestment;




            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            // Load data into the grid
            SQLCon.RetornaDataTable(@$"SELECT DISTINCT 
	                                        [responsible] AS Gerente, InvestimentoGerencia = 0.00 
                                        FROM 
	                                        [PLEDIGITAL].[dbo].[costCenters] 
                                        WHERE [vp] 
	                                        LIKE '%{GlobalVariablesClass.currentVPArea}%'");
            gridControlManagerAreas.DataSource = SQLCon.DataTable;

            // Populate columns and configure grid settings
            gridViewManagerAreas.PopulateColumns();
            foreach (GridColumn column in gridViewManagerAreas.Columns) // Disable editing for all columns
                column.OptionsColumn.AllowEdit = false;

            gridViewManagerAreas.Columns["InvestimentoGerencia"].OptionsColumn.AllowEdit = true;


            // Add summary for the "InvestimentoGerencia" column
            gridViewManagerAreas.Columns["InvestimentoGerencia"].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            var a = gridViewManagerAreas.Columns["InvestimentoGerencia"].SummaryItem.SummaryValue;
            textEditAttributedInvestment.EditValue = a;
            textEditAttributedInvestment.ReadOnly = true;

            // Attach event handler for cell value changes
            gridViewManagerAreas.CellValueChanged += gridViewCostCenters_CellValueChanged;


            //gridViewManagerAreas.Columns["ValorUsado"].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            //var a = gridViewManagerAreas.Columns["ValorUsado"].SummaryItem.SummaryValue;
            //textEditAttributedInvestment.EditValue = a;
            //textEditAttributedInvestment.ReadOnly = true;
            //gridViewManagerAreas.CellValueChanged += gridViewCostCenters_CellValueChanged;

            //labelControlInvestiment.Text = GlobalVariablesClass.currentVersionInvestment;
        }

        private void gridViewCostCenters_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewManagerAreas.UpdateTotalSummary();
            textEditAttributedInvestment.EditValue = gridViewManagerAreas.Columns["InvestimentoGerencia"].SummaryItem.SummaryValue;
        }

        private void gridViewCostCenters_DoubleClick(object sender, EventArgs e)
        {
    


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Convert textEditAttributedInvestment.Text and labelControlInvestiment.Text to decimal variables
            decimal attributedInvestment = Convert.ToDecimal(textEditAttributedInvestment.Text);
            decimal investiment = Convert.ToDecimal(labelControlInvestiment.Text);

            // Check the condition
            if (attributedInvestment > investiment)
            {
                // Exit the method if the condition is met
                XtraMessageBox.Show("Valor alocado nas gerências maior que o estipulado para despesa");
                return;
            }
            else if (attributedInvestment < investiment)
            {
                // Show a message box with Yes and No options
                DialogResult result = XtraMessageBox.Show("O valor alocado nas gerências é menor que a despesa estipulada. Deseja continuar?", "Confirmação", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    // Exit the method if the user chooses No
                    return;
                }
            }
            else
            {
                // Show a message box with Yes and No options
                DialogResult result = XtraMessageBox.Show("Confirma em finalizar alocamento de despesas para gerências?", "Confirmação", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    // Exit the method if the user chooses No
                    return;
                }
            }

            for (int rowIndex = 0; rowIndex < gridViewManagerAreas.RowCount; rowIndex++)
            {
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);

                //string managerName = SQLCon.DataTable.Rows[rowIndex][0].ToString();
                //string allocatedCost = SQLCon.DataTable.Rows[rowIndex][1].ToString();

                string managerName = gridViewManagerAreas.GetRowCellValue(rowIndex, "Gerente").ToString();
                string allocatedCost = gridViewManagerAreas.GetRowCellValue(rowIndex, "InvestimentoGerencia").ToString();


                //XtraMessageBox.Show(Convert.ToString(managerName));
                //XtraMessageBox.Show(Convert.ToString(allocatedCost));

                //XtraMessageBox.Show(managerName + " - " + allocatedCost);

                //insert new manager 
                SqlParameter[] dataNewManagerRow =
                {
                        new SqlParameter("@versionID", SqlDbType.VarChar, 100) { Value = GlobalVariablesClass.currentVersion },
                        new SqlParameter("@managerName", SqlDbType.VarChar, 200) { Value = managerName },
                        new SqlParameter("@allocatedInvestment", SqlDbType.Decimal, 200) { Value = Convert.ToDecimal(allocatedCost) },
                        new SqlParameter("@usedlInvestment", SqlDbType.Decimal, 200) { Value = "0" },
                        new SqlParameter("@status", SqlDbType.VarChar, 200) { Value = "Não realizado" },

                };
                SQLCon.ExecuteNoQuerySQL(
                       "INSERT INTO [managerParent] ([versionID], [managerName], [allocatedInvestment], [usedInvestment], [status]) VALUES (@versionID, @managerName, @allocatedInvestment, @usedlInvestment, @status);",
                       "",
                       dataNewManagerRow,
                       false
                );
                SQLCon.CloseConnectionSQL();

                //get the id of the most recent created manager area
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                SQLCon.RetornaDataTable("SELECT TOP 1 * FROM [managerParent] ORDER BY [managerID] DESC");
                string currentManagerID = Convert.ToString(SQLCon.DataTable.Rows[0][0]);

                //create account center parent at SQL Server
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                SQLCon.RetornaDataTable($"SELECT * FROM [costCenters] WHERE [RESPONSIBLE] = '{managerName}'");
                DataTable dataTableCostCenters = SQLCon.DataTable;
                for (int i = 0; i < dataTableCostCenters.Rows.Count; i++)
                {
                    //XtraMessageBox.Show(Convert.ToString(dataTableCostCenters.Rows.Count));

                    SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);

                    string versionID = GlobalVariablesClass.currentVersion;
                    string statusCC = "Não realizado";
                    string costCenterCode = SQLCon.DataTable.Rows[i][1].ToString();
                    string costCenterName = SQLCon.DataTable.Rows[i][2].ToString();
                    string user = SQLCon.DataTable.Rows[i][3].ToString();
                    string vp = SQLCon.DataTable.Rows[i][4].ToString();

                    //XtraMessageBox.Show(costCenterCode +"-"+ costCenterCode + "-" + user + vp);

                    SqlParameter[] dataNewCostCenterParent =
                    {
                        new SqlParameter("@versionID", SqlDbType.VarChar, 100) { Value = GlobalVariablesClass.currentVersion },
                        new SqlParameter("@managerID", SqlDbType.VarChar, 100) { Value = currentManagerID },
                        new SqlParameter("@status", SqlDbType.VarChar, 200) { Value = statusCC },
                        new SqlParameter("@costCenterCode", SqlDbType.VarChar, 200) { Value = costCenterCode },
                        new SqlParameter("@costCenterName", SqlDbType.VarChar, 200) { Value = costCenterName },
                        new SqlParameter("@user", SqlDbType.VarChar, 200) { Value = user },
                        new SqlParameter("@vp", SqlDbType.VarChar, 200) { Value = vp },
                        new SqlParameter("@totalValue", SqlDbType.Decimal, 100) { Value = "0" },
                        new SqlParameter("@allocatedValue", SqlDbType.Decimal, 100) { Value = "0" },
                        };

                    SQLCon.ExecuteNoQuerySQL($"INSERT INTO [costCenterParent] VALUES (@versionID, @managerID, @status, @costCenterCode, @costCenterName, @user, @vp," +
                        "@totalValue, @allocatedValue)", "", dataNewCostCenterParent, false);

                    SQLCon.CloseConnectionSQL();
                }
            }

            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);

            SqlParameter[] dataEditVP =
            {
            new SqlParameter("@step", SqlDbType.VarChar, 500) { Value = "Etapa 3 - dados de gerencia atribuídos"},
            };
            SQLCon.ExecuteNoQuerySQL($"UPDATE [vpParent] SET [status] = @step WHERE [vpID] = '{GlobalVariablesClass.currentVPID}'", "", dataEditVP, false);

            EmailHandlerClass.SendEmail($"Diretor {UserClass.userName} finalizou o preenchimento da sua área.",
                                        "alessandro.silva@bbraun.com",
                                        $"Gestor Despesas - Gestor {UserClass.userName} finalizou seu preenchimento");

            string getCurrentVPManagers = @$"SELECT DISTINCT
                                                [responsible]
                                            FROM 
	                                            [PLEDIGITAL].[dbo].[costCenters] 
                                            WHERE 
	                                            VP 
                                            LIKE '{GlobalVariablesClass.currentVPArea}'
                                            ";

            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(getCurrentVPManagers);
            // Iterate through each item of the DataTable
            foreach (DataRow row in SQLCon.DataTable.Rows)
            {
                string responsible = row["responsible"].ToString();
                // Perform actions with the 'responsible' value

                string getCurrentManagersEmails = @$"SELECT TOP (1) 
                                                    [email]
                                                FROM 
                                                    [PLEDIGITAL].[dbo].[users] 
                                                WHERE 
                                                    [name] 
                                                LIKE '{responsible}'
                                                ";
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                SQLCon.RetornaDataTable(getCurrentManagersEmails);

                string managerEmail = Convert.ToString(SQLCon.DataTable.Rows[0][0]);

                EmailHandlerClass.SendEmail($"Caro gestor {responsible}, a sua despesa gerencial já foi alocada. Você pode acessar o programa e realizar sua atuação.",
                                        $"{managerEmail}",
                                        $"Despesas 2024 - Centros de custo do Gestor {responsible} podem ser preenchidos");
            }

            SQLCon.CloseConnectionSQL();

            XtraMessageBox.Show("Despesas da diretoria alocadas com sucesso");

            FormPrincipal.instance.Close();

        }
    }
}
