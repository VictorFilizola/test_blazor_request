using DevExpress.CodeParser;
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

namespace Gestor_PnL.Forms
{
    public partial class FormStep2EditManagers : DevExpress.XtraEditors.XtraForm
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();

        public FormStep2EditManagers()
        {
            InitializeComponent();
   
            labelControlInvestiment.Text = GlobalVariablesClass.currentVPInvestiment;

            LoadAndConfigureGrid();
        }

        private void LoadAndConfigureGrid()
        {
            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            // Load data into the grid
            SQLCon.RetornaDataTable($"SELECT DISTINCT [responsible] as Gerente, InvestimentoGerencia = 0.00 FROM [PLEDIGITAL].[dbo].[costCenters] WHERE [vp] = '{GlobalVariablesClass.currentVP}'");
            gridControlManagers.DataSource = SQLCon.DataTable;

            // Populate columns and configure grid settings
            gridViewManagers.PopulateColumns();
            foreach (GridColumn column in gridViewManagers.Columns) // Disable editing for all columns
                column.OptionsColumn.AllowEdit = false;

            gridViewManagers.Columns["InvestimentoGerencia"].OptionsColumn.AllowEdit = true;

            // Add summary for the "InvestimentoGerencia" column
            gridViewManagers.Columns["InvestimentoGerencia"].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            var a = gridViewManagers.Columns["InvestimentoGerencia"].SummaryItem.SummaryValue;
            textEdit2.EditValue = a;
            textEdit2.ReadOnly = true;

            // Attach event handler for cell value changes
            gridViewManagers.CellValueChanged += gridView1_CellValueChanged;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewManagers.UpdateTotalSummary();
            textEdit2.EditValue = gridViewManagers.Columns["InvestimentoGerencia"].SummaryItem.SummaryValue;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (labelControlInvestiment.Text != textEdit2.Text)
            {
                DialogResult Resultado = MessageBox.Show("Valor distribuido para gerencias diferente do estipulado para diretoria. Deseja continuar?", "Confirmação", MessageBoxButtons.YesNo);
                switch (Resultado)
                {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        return;
                }
            }

            for (int rowIndex = 0; rowIndex < gridViewManagers.RowCount; rowIndex++)
            {
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);

                //string managerName = SQLCon.DataTable.Rows[rowIndex][0].ToString();
                //string allocatedCost = SQLCon.DataTable.Rows[rowIndex][1].ToString();

                string managerName = gridViewManagers.GetRowCellValue(rowIndex, "Gerente").ToString();
                string allocatedCost = gridViewManagers.GetRowCellValue(rowIndex, "InvestimentoGerencia").ToString();


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

            SQLCon.CloseConnectionSQL();

            FormStep2Management.instance.LoadAndConfigureGrid();

            FormPrincipal.instance.barButtonItemManageVersionsInstance.PerformClick();

            Close();
        }
    }
}