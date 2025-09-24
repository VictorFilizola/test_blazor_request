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

namespace Gestor_PnL.UserControls
{
    public partial class UserControlEditCostCenters : XtraUserControl
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();
        EmailHandlerClass EmailHandlerClass = new EmailHandlerClass();

        public UserControlEditCostCenters()
        {
            InitializeComponent();

            //gridControlCostCenters

            string queryControlInvestment = $"SELECT TOP (1) [allocatedInvestment], [managerID], [versionID], [status] FROM [PLEDIGITAL].[dbo].[managerParent] WHERE ManagerName LIKE '%{UserClass.userName}%' ORDER BY VersionID DESC";
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(queryControlInvestment);
            string statusAtual = Convert.ToString(SQLCon.DataTable.Rows[0][3]);
            if (statusAtual == "Realizado")
            {
                XtraMessageBox.Show("Dados de centro de custo já preenchidos. Saindo do programa...");
              
                FormPrincipal.instance.Close();
            }
            var firstCellValue = SQLCon.DataTable.Rows[0][0];
            GlobalVariablesClass.currentVersionInvestment = Convert.ToString(firstCellValue);
            GlobalVariablesClass.currentManagerID = Convert.ToString(SQLCon.DataTable.Rows[0][1]);
            GlobalVariablesClass.currentVersion = Convert.ToString(SQLCon.DataTable.Rows[0][2]);
            //MessageBox.Show($"The first cell value is: {firstCellValue}");
            labelControlInvestiment.Text = GlobalVariablesClass.currentVersionInvestment;
            //XtraMessageBox.Show(Convert.ToString(firstCellValue));
            //XtraMessageBox.Show(GlobalVariablesClass.currentManagerID);

            string query = $"SELECT [costCenterID] as ID ,[status] as Status, [costCenterCode] as CodigoCentroCusto, [costCenterName] as NomeCentroCusto, [user] as Gerente, [allocatedValue] as ValorAlocado, [usedValue] as ValorUsado FROM [PLEDIGITAL].[dbo].[costCenterParent] WHERE [managerID] LIKE '%{GlobalVariablesClass.currentManagerID}%'";

            //control if manager area already has been filled
            //var firstCellValue = SQLCon.DataTable.Rows[0][0];


            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(query);
            gridControlCostCenters.DataSource = SQLCon.DataTable;

            foreach (GridColumn column in gridViewCostCenters.Columns) // disable editing for all columns
            column.OptionsColumn.AllowEdit = false;

            //ValorUsado

            gridViewCostCenters.Columns["ValorUsado"].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            var a = gridViewCostCenters.Columns["ValorUsado"].SummaryItem.SummaryValue;
            textEditAttributedInvestment.EditValue = a;
            textEditAttributedInvestment.ReadOnly = true;
            gridViewCostCenters.CellValueChanged += gridViewCostCenters_CellValueChanged;

            //labelControlInvestiment.Text = GlobalVariablesClass.currentVersionInvestment;
        }

        private void gridViewCostCenters_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewCostCenters.UpdateTotalSummary();
            textEditAttributedInvestment.EditValue = gridViewCostCenters.Columns["ValorUsado"].SummaryItem.SummaryValue;
        }

        private void gridViewCostCenters_DoubleClick(object sender, EventArgs e)
        {
            var CurrentCCID = gridViewCostCenters.GetRowCellValue(gridViewCostCenters.FocusedRowHandle, gridViewCostCenters.Columns[0]);
            var CurrentCCNumber = gridViewCostCenters.GetRowCellValue(gridViewCostCenters.FocusedRowHandle, gridViewCostCenters.Columns[2]);
            var CurrentCCName = gridViewCostCenters.GetRowCellValue(gridViewCostCenters.FocusedRowHandle, gridViewCostCenters.Columns[3]);
            var CurrentCCInvestiment = gridViewCostCenters.GetRowCellValue(gridViewCostCenters.FocusedRowHandle, gridViewCostCenters.Columns[5]);

            GlobalVariablesClass.currentCCID = Convert.ToString(CurrentCCID);
            GlobalVariablesClass.currentCCNumber = Convert.ToString(CurrentCCNumber);
            GlobalVariablesClass.currentCCname = Convert.ToString(CurrentCCName);
            GlobalVariablesClass.currentCCInvestiment = Convert.ToString(CurrentCCInvestiment);
            //GlobalVariablesClass.currentCCVP = "Finanças";
            GlobalVariablesClass.currentCCVP = " ";

            //XtraMessageBox.Show(Convert.ToString(gridViewCostCenters.GetRowCellValue(gridViewCostCenters.FocusedRowHandle, gridViewCostCenters.Columns[3])));
            //XtraMessageBox.Show(GlobalVariablesClass.currentCCInvestiment);

            GlobalVariablesClass.currentCCname = CurrentCCName.ToString();

            //disable the main form
            HelperClass.disableMainForm();

            var FormNewCCValue = new Forms.FormNewCCValue();
            FormNewCCValue.Show();

            //var FormEditCostCenters = new Forms.FormEditCostCenters();
            //FormEditCostCenters.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //EmailHandlerClass.SendEmail($"Gestor {UserClass.userName} finalizou o preenchimento da sua área.",
            //                            "br_controladoria @bbraun.com",
            //                            $"LE Digital - Gestor {UserClass.userName} finalizou seu preenchimento");

            // Convert textEditAttributedInvestment.Text and labelControlInvestiment.Text to decimal variables
            decimal attributedInvestment = Convert.ToDecimal(textEditAttributedInvestment.Text);
            decimal investiment = Convert.ToDecimal(labelControlInvestiment.Text);

            // Check the condition
            if (attributedInvestment > investiment)
            {
                // Exit the method if the condition is met
                XtraMessageBox.Show("Valor alocado no Centro de Custo maior que o estipulado para despesa");
                return;
            }
            else if (attributedInvestment < investiment)
            {
                // Show a message box with Yes and No options
                DialogResult result = XtraMessageBox.Show("O valor alocado no Centro de Custo é menor que o despesa estipulada. Deseja continuar?", "Confirmação", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    // Exit the method if the user chooses No
                    return;
                }
            }
            else
            {
                // Show a message box with Yes and No options
                DialogResult result = XtraMessageBox.Show("Confirma em finalizar alocamento de despesas para centros de custo?", "Confirmação", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    // Exit the method if the user chooses No
                    return;
                }
            }

            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);

            SqlParameter[] newData =
            {
                    new SqlParameter("@investment", SqlDbType.Decimal) { Value = attributedInvestment },
                    new SqlParameter("@status", SqlDbType.VarChar, 100) { Value = "Realizado" }
            };

            SQLCon.ExecuteNoQuerySQL($"UPDATE [managerParent] SET [usedInvestment] = @investment, [status] = @status WHERE [managerID] = '{GlobalVariablesClass.currentManagerID}'", "", newData, false);

            SQLCon.CloseConnectionSQL();

            EmailHandlerClass.SendEmail($"Gestor {UserClass.userName} finalizou o preenchimento da sua área.",
                                        "alessandro.silva@bbraun.com",
                                        $"LE Digital - Gestor {UserClass.userName} finalizou seu preenchimento");

            HelperClass.disableMainForm();

            XtraMessageBox.Show("Atribuição de despesas concluída com sucesso");

            FormPrincipal.instance.Close();
        }
    }
}
