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
    public partial class FormStep1VP : DevExpress.XtraEditors.XtraForm
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();

        public FormStep1VP()
        {
            InitializeComponent();

            //load current contract items data to gridControlVPsHistoric
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(@$"SELECT 
                                            CC.[vp],
                                            ROUND(SUM(LE.[Janeiro] + LE.[Fevereiro] + LE.[Março] + LE.[Abril] + LE.[Maio] + LE.[Junho] + LE.[Julho] + LE.[Agosto] + LE.[Setembro] + LE.[Outubro] + LE.[Novembro] + LE.[Dezembro]), 0) AS Total
                                        FROM 
                                            [PLEDIGITAL].[dbo].[LE_Ag_Ger_Historico] LE
                                        INNER JOIN 
                                            [PLEDIGITAL].[dbo].[costCenters] CC
                                        ON 
                                            LE.[CentroCusto] = CC.[costCenter]
                                        WHERE 
                                            LE.[Ano] = 2023
                                            AND LE.[ContaGerencial] IN (SELECT [contaGerencial] FROM [PLEDIGITAL].[dbo].[costCenterTemplate])
                                        GROUP BY 
                                            CC.[vp]");
            gridControlVPsHistoric.DataSource = SQLCon.DataTable;

            gridViewVPsHistoric.PopulateColumns();
            
            //foreach (GridColumn column in gridViewVPsHistoric.Columns) // disable editing for all columns
            //    column.OptionsColumn.AllowEdit = false;

            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable($"SELECT [vpID] as ID ,[vpName] as NomeDiretoria ,[vpUser] as VP ,[totalInvestment] as InvestimentoDiretoria FROM [PLEDIGITAL].[dbo].[vpParent] WHERE [versionID] = '{GlobalVariablesClass.currentVersion}'");
            gridControlManageVPs.DataSource = SQLCon.DataTable;

            gridView1.PopulateColumns();
            foreach (GridColumn column in gridView1.Columns) // disable editing for all columns
                column.OptionsColumn.AllowEdit = false;

            gridView1.Columns["InvestimentoDiretoria"].OptionsColumn.AllowEdit = true;

            gridView1.Columns["InvestimentoDiretoria"].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
            var a = gridView1.Columns["InvestimentoDiretoria"].SummaryItem.SummaryValue;
            textEditInvestmentAllocated.EditValue = a;
            textEditInvestmentAllocated.ReadOnly = true;
            gridView1.CellValueChanged += gridView1_CellValueChanged;

            labelControlInvestiment.Text = GlobalVariablesClass.currentVersionInvestment;
        }

        private void simpleButtonNewVersion_Click(object sender, EventArgs e)
        {
            //if (labelControlInvestiment.Text != textEditInvestmentAllocated.Text)
            //{
            //    XtraMessageBox.Show("Despesa distribuída diferente do estipulado na versão");
            //}
            //else
            //{
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                SqlParameter[] DataEtapa =
                {
                    new SqlParameter("@step", SqlDbType.VarChar, 100) { Value = "Etapa 2 - Valores Gerenciais" },
                };
                SQLCon.ExecuteNoQuerySQL($"UPDATE [versionParent] SET [step] = @step WHERE [versionID] = '{GlobalVariablesClass.currentVersion}'", "", DataEtapa, false);

                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    string vpID = Convert.ToString(gridView1.GetRowCellValue(i, gridView1.Columns[0]));
                    decimal totalInvestment = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[3]));

                    SqlParameter[] dataEditVP =
                    {
                        //new SqlParameter("@", SqlDbType.VarChar, 100) { Value = vpID },
                        new SqlParameter("@step", SqlDbType.Decimal, 100) { Value = totalInvestment },
                    };
                    SQLCon.ExecuteNoQuerySQL($"UPDATE [vpParent] SET [totalInvestment] = @step WHERE [vpID] = '{vpID}'", "", dataEditVP, false);
                }

                XtraMessageBox.Show("Etapa concluída com sucesso");

                FormPrincipal.instance.barButtonItemManageVersionsInstance.PerformClick();

                Close();
            //}
        }

        private void FormStepOneVP_FormClosed(object sender, FormClosedEventArgs e)
        {
            HelperClass.enableMainForm();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.UpdateTotalSummary();
            textEditInvestmentAllocated.EditValue = gridView1.Columns["InvestimentoDiretoria"].SummaryItem.SummaryValue;
        }
    }
}