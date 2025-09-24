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
    public partial class FormStep2Management : DevExpress.XtraEditors.XtraForm
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();

        public static FormStep2Management instance;

        public FormStep2Management()
        {
            InitializeComponent();

            HelperClass.disableMainForm();

            //define the instances of this form
            instance = this;

            ////load current contract items data to gridControlItems
            //SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            //SQLCon.RetornaDataTable($"SELECT [vpID] as ID ,[status] as Status, [vpName] as NomeDiretoria,[vpUser] as VP ,[totalInvestment] as InvestimentoDiretoria FROM [PLEDIGITAL].[dbo].[vpParent] WHERE [versionID] = '{GlobalVariablesClass.currentVersion}'");
            //gridControlManageVPs.DataSource = SQLCon.DataTable;

            //gridViewVPs.PopulateColumns();
            //foreach (GridColumn column in gridViewVPs.Columns) // disable editing for all columns
            //column.OptionsColumn.AllowEdit = false;

            //gridView1.Columns["InvestimentoDiretoria"].OptionsColumn.AllowEdit = true;

            //gridView1.Columns["InvestimentoDiretoria"].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            //var a = gridView1.Columns["InvestimentoDiretoria"].SummaryItem.SummaryValue;
            //textEdit1.EditValue = a;
            //textEdit1.ReadOnly = true;
            //gridView1.CellValueChanged += gridView1_CellValueChanged;

            //labelControlInvestiment.Text = GlobalVariablesClass.currentVersionInvestment;

            LoadAndConfigureGrid();
        }

        public void LoadAndConfigureGrid()
        {
            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable($"SELECT [vpID] as ID ,[status] as Status, [vpName] as NomeDiretoria,[vpUser] as VP ,[totalInvestment] as InvestimentoDiretoria FROM [PLEDIGITAL].[dbo].[vpParent] WHERE [versionID] = '{GlobalVariablesClass.currentVersion}'");
            gridControlManageVPs.DataSource = SQLCon.DataTable;

            gridViewVPs.PopulateColumns();
            foreach (GridColumn column in gridViewVPs.Columns) // disable editing for all columns
                column.OptionsColumn.AllowEdit = false;
        }

            private void gridControlManageVPs_Click(object sender, EventArgs e)
        {
            //SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            var currentStatus = gridViewVPs.GetRowCellValue(gridViewVPs.FocusedRowHandle, gridViewVPs.Columns[1]);

            if (currentStatus.ToString() == "Etapa 3 - dados de gerencia atribuídos")
            {
                XtraMessageBox.Show("Diretoria já aprovada. Não é possível editar.");
                return;
            }

            var currentVPID = gridViewVPs.GetRowCellValue(gridViewVPs.FocusedRowHandle, gridViewVPs.Columns[0]);
            var currentVP = gridViewVPs.GetRowCellValue(gridViewVPs.FocusedRowHandle, gridViewVPs.Columns[2]);
            var currentVPInvestiment = gridViewVPs.GetRowCellValue(gridViewVPs.FocusedRowHandle, gridViewVPs.Columns[4]);

            GlobalVariablesClass.currentVPID = currentVPID.ToString();
            GlobalVariablesClass.currentVP = currentVP.ToString();
            GlobalVariablesClass.currentVPInvestiment = currentVPInvestiment.ToString();

            var FormStep2EditManagers = new FormStep2EditManagers();
            FormStep2EditManagers.Show();

            //disable the main form
            HelperClass.disableMainForm();

            //Altera a próxima etapa do PDPC
            //SqlParameter[] DataEtapa =
            //{
            //    new SqlParameter("@step", SqlDbType.VarChar, 100) { Value = "Etapa 2 - Valores Gerenciais" },
            //};
            //SQLCon.ExecuteNoQuerySQL($"UPDATE [versionParent] SET [step] = @step WHERE [versionID] = '{GlobalVariablesClass.currentVersion}'", "", DataEtapa, false);

            //for (int i = 0; i < gridView1.DataRowCount; i++)
            //{
            //    string vpID = Convert.ToString(gridView1.GetRowCellValue(i, gridView1.Columns[0]));
            //    decimal totalInvestment = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[3]));

            //    SqlParameter[] dataEditVP =
            //    {
            //        //new SqlParameter("@", SqlDbType.VarChar, 100) { Value = vpID },
            //        new SqlParameter("@step", SqlDbType.Decimal, 100) { Value = totalInvestment },
            //    };
            //    SQLCon.ExecuteNoQuerySQL($"UPDATE [vpParent] SET [totalInvestment] = @step WHERE [vpID] = '{vpID}'", "", dataEditVP, false);
            //}

            //XtraMessageBox.Show("Etapa concluída com sucesso");

            //Close();
        }

        private void FormStep2Management_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormPrincipal.instance.barButtonItemManageVersionsInstance.PerformClick();

            HelperClass.enableMainForm();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int rowIndex = 0; rowIndex < gridViewVPs.RowCount; rowIndex++)
            {
                var cellValue = gridViewVPs.GetRowCellValue(rowIndex, gridViewVPs.Columns[1]);

                if (cellValue != null && cellValue.ToString() == "Status 0 - Criado")
                {
                    XtraMessageBox.Show("Por favor, finalize a alocação de recursos para todas gerências dentro das diretorias");
                    // Exit the method if the condition is met
                    return;
                }
            }

            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);

            SqlParameter[] DataEtapa =
            {
                    new SqlParameter("@step", SqlDbType.VarChar, 100) { Value = "Etapa 3 - Valores Centros de Custo" },
                };
            SQLCon.ExecuteNoQuerySQL($"UPDATE [versionParent] SET [step] = @step WHERE [versionID] = '{GlobalVariablesClass.currentVersion}'", "", DataEtapa, false);

            //SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            //SqlParameter[] TesteData =
            //    {
            //        new SqlParameter("@step", SqlDbType.Decimal, 100) { Value = "00" },
            //    };
            //SQLCon.ExecuteNoQuerySQL($"UPDATE [costCenterParent] SET [totalValue] = '69' WHERE [user] = 'Marcos Werneck'", "", TesteData, false);


            //UPDATE [costCenterParent] SET [totalValue] = '100000' WHERE [user] = 'Marcos Werneck'

            //for (int i = 0; i < gridView1.DataRowCount; i++)
            //{
            //    string vpID = Convert.ToString(gridView1.GetRowCellValue(i, gridView1.Columns[0]));
            //    decimal totalInvestment = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[3]));

            //    SqlParameter[] dataEditVP =
            //    {
            //            //new SqlParameter("@", SqlDbType.VarChar, 100) { Value = vpID },
            //            new SqlParameter("@step", SqlDbType.VarChar, 100) { Value = totalInvestment },
            //        };
            //    SQLCon.ExecuteNoQuerySQL($"UPDATE [vpParent] SET [totalInvestment] = @step WHERE [vpID] = '{vpID}'", "", dataEditVP, false);
            //}

            XtraMessageBox.Show("Etapa concluída com sucesso");

            Close();
        }
    }
}