using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Gestor_PnL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Gestor_PnL.Forms
{
    public partial class FormEditCostCenters : DevExpress.XtraEditors.XtraForm
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();

        public FormEditCostCenters()
        {
            InitializeComponent();

            HelperClass.disableMainForm();

            labelControlCCName.Text = $"Nome CC: {GlobalVariablesClass.currentCCname}";
            labelControlVP.Text = $"Diretoria: {GlobalVariablesClass.currentCCVP}";
            labelControlCCCode.Text = $"Código CC: {GlobalVariablesClass.currentCCNumber}";
            labelControlAllocatedInvestment.Text = $"Despesa Alocada: {GlobalVariablesClass.currentCCInvestiment}";

            string query = "SELECT TOP (1000) [costCenterSubID] as ID,[costCenterParentID] as VersaoID,[contaGerencial] as ContaGerencial,[january] as Janeiro,[february] as Fevereiro,[march] as Março,[april] as Abril,[may] as Maio,[june] as Junho,[july] as Julho,[august] as Agosto,[september] as Setembro ,[october] as Outubro,[november] as Novembro,[december] as Dezembro FROM [PLEDIGITAL].[dbo].[costCenterTemplate] ORDER BY ContaGerencial ASC";
            string query2 = @$"  SELECT 
                                      LE2024.[ContaGerencial],
                                      ISNULL(LE2024.[Janeiro], 0) AS [Janeiro],
                                      ISNULL(LE2024.[Fevereiro], 0) AS [Fevereiro],
                                      ISNULL(LE2024.[Março], 0) AS [Março],
                                      ISNULL(LE2024.[Abril], 0) AS [Abril],
                                      ISNULL(LE2024.[Maio], 0) AS [Maio],
                                      ISNULL(LE2024.[Junho], 0) AS [Junho],
                                      ISNULL(LE2024.[Julho], 0) AS [Julho],
                                      ISNULL(LE2024.[Agosto], 0) AS [Agosto],
                                      ISNULL(LE2024.[Setembro], 0) AS [Setembro],
                                      ISNULL(LE2024.[Outubro], 0) AS [Outubro],
                                      ISNULL(LE2023.[Novembro], 0) AS [Novembro],
                                      ISNULL(LE2023.[Dezembro], 0) AS [Dezembro]
                                  FROM 
                                      [PLEDIGITAL].[dbo].[LE_Ag_Ger_Historico] LE2024
                                  LEFT JOIN 
                                      [PLEDIGITAL].[dbo].[LE_Ag_Ger_Historico] LE2023
                                  ON 
                                      LE2024.[CentroCusto] = LE2023.[CentroCusto] 
                                      AND LE2024.[ContaGerencial] = LE2023.[ContaGerencial]
                                      AND LE2023.[Ano] = 2023
                                  WHERE 
                                      LE2024.[CentroCusto] = '{GlobalVariablesClass.currentCCNumber}'
                                      AND LE2024.[ContaGerencial] IS NOT NULL
                                      AND LE2024.[ContaGerencial] != 'Training'
                                      AND LE2024.[Ano] = 2024
                                  ORDER BY 
                                      LE2024.[ContaGerencial] ASC";

            //string query2 = @$"  
            //                SELECT 
            //                    LE2024.[ContaGerencial],
            //                    CASE WHEN LE2024.[Janeiro] < 0 THEN 0 ELSE ISNULL(LE2024.[Janeiro], 0) END AS [Janeiro],
            //                    CASE WHEN LE2024.[Fevereiro] < 0 THEN 0 ELSE ISNULL(LE2024.[Fevereiro], 0) END AS [Fevereiro],
            //                    CASE WHEN LE2024.[Março] < 0 THEN 0 ELSE ISNULL(LE2024.[Março], 0) END AS [Março],
            //                    CASE WHEN LE2024.[Abril] < 0 THEN 0 ELSE ISNULL(LE2024.[Abril], 0) END AS [Abril],
            //                    CASE WHEN LE2024.[Maio] < 0 THEN 0 ELSE ISNULL(LE2024.[Maio], 0) END AS [Maio],
            //                    CASE WHEN LE2024.[Junho] < 0 THEN 0 ELSE ISNULL(LE2024.[Junho], 0) END AS [Junho],
            //                    CASE WHEN LE2024.[Julho] < 0 THEN 0 ELSE ISNULL(LE2024.[Julho], 0) END AS [Julho],
            //                    CASE WHEN LE2024.[Agosto] < 0 THEN 0 ELSE ISNULL(LE2024.[Agosto], 0) END AS [Agosto],
            //                    CASE WHEN LE2024.[Setembro] < 0 THEN 0 ELSE ISNULL(LE2024.[Setembro], 0) END AS [Setembro],
            //                    CASE WHEN LE2024.[Outubro] < 0 THEN 0 ELSE ISNULL(LE2024.[Outubro], 0) END AS [Outubro],
            //                    CASE WHEN LE2023.[Novembro] < 0 THEN 0 ELSE ISNULL(LE2023.[Novembro], 0) END AS [Novembro],
            //                    CASE WHEN LE2023.[Dezembro] < 0 THEN 0 ELSE ISNULL(LE2023.[Dezembro], 0) END AS [Dezembro]
            //                FROM 
            //                    [PLEDIGITAL].[dbo].[LE_Ag_Ger_Historico] LE2024
            //                LEFT JOIN 
            //                    [PLEDIGITAL].[dbo].[LE_Ag_Ger_Historico] LE2023
            //                ON 
            //                    LE2024.[CentroCusto] = LE2023.[CentroCusto] 
            //                    AND LE2024.[ContaGerencial] = LE2023.[ContaGerencial]
            //                    AND LE2023.[Ano] = 2023
            //                WHERE 
            //                    LE2024.[CentroCusto] = '{GlobalVariablesClass.currentCCNumber}'
            //                    AND LE2024.[ContaGerencial] IS NOT NULL
            //                    AND LE2024.[ContaGerencial] != 'Training'
            //                    AND LE2024.[Ano] = 2024
            //                ORDER BY 
            //                    LE2024.[ContaGerencial] ASC";


            //]string query2 = $"SELECT [ContaGerencial],[Janeiro],[Fevereiro],[Março],[Abril],[Maio],[Junho],[Julho],[Agosto],[Setembro],[Outubro],[Novembro],[Dezembro] FROM [PLEDIGITAL].[dbo].[LE_Ag_Ger_Historico] WHERE CentroCusto = '{GlobalVariablesClass.currentCCNumber}' AND ContaGerencial != 'NULL' AND ContaGerencial != 'Training' AND [ANO] = 2024 ORDER BY [ContaGerencial] ASC";


            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(query);
            gridControlValueCC.DataSource = SQLCon.DataTable;

            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(query2);
            gridControlValueHistoric.DataSource = SQLCon.DataTable;

            gridViewValueCCs.Columns[0].Visible = false;
            gridViewValueCCs.Columns[1].Visible = false;

            if (SQLCon.DataTable != null && SQLCon.DataTable.Rows.Count > 0 && SQLCon.DataTable.Columns.Count > 0)
            {
                // Calculate totals for each column in gridViewHistoricCCs
                string[] months = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
                decimal[] totalsHistoric = new decimal[months.Length];

                for (int i = 0; i < months.Length; i++)
                {
                    gridViewHistoricCCs.Columns[months[i]].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
                    totalsHistoric[i] = Convert.ToDecimal(gridViewHistoricCCs.Columns[months[i]].SummaryItem.SummaryValue);
                }

                // Calculate percentages for each cell in gridViewHistoricCCs
                decimal[,] percentages = new decimal[gridViewHistoricCCs.RowCount, months.Length];

                for (int rowIndex = 0; rowIndex < gridViewHistoricCCs.RowCount; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < months.Length; colIndex++)
                    {
                        decimal cellValue = Convert.ToDecimal(gridViewHistoricCCs.GetRowCellValue(rowIndex, months[colIndex]));
                        percentages[rowIndex, colIndex] = (totalsHistoric[colIndex] != 0) ? Math.Round((cellValue / totalsHistoric[colIndex]) * 100, 2) : 0;

                    }
                }

                // Example: Accessing the percentage value of the first row and first column
                //decimal firstRowFirstColumnPercentage = percentages[0, 0];

                for (int i = 0; i < months.Length; i++)
                {
                    gridViewHistoricCCs.Columns[months[i]].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
                    totalsHistoric[i] = Convert.ToDecimal(gridViewHistoricCCs.Columns[months[i]].SummaryItem.SummaryValue);
                }

                decimal totalCell1 = percentages[0, 0] * totalsHistoric[0];

                gridViewHistoricCCs.UpdateTotalSummary();

                string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
                DevExpress.XtraEditors.TextEdit[] textEditsCC = { textEditCCJan, textEditCCFeb, textEditCCMar, textEditCCApr, textEditCCMay, textEditCCJun, textEditCCJul, textEditCCAug, textEditCCSep, textEditCCOct, textEditCCNov, textEditCCDec };
                DevExpress.XtraEditors.TextEdit[] textEditsHistoric = { textEditHistoricJan, textEditHistoricFeb, textEditHistoricMar, textEditHistoricApr, textEditHistoricMay, textEditHistoricJun, textEditHistoricJul, textEditHistoricAug, textEditHistoricSep, textEditHistoricOct, textEditHistoricNov, textEditHistoricDec };

                decimal totalCC = 0;
                decimal totalHistorico = 0;
                decimal[] totalsCC = new decimal[meses.Length];
                decimal[] totalsHistoricUp = new decimal[meses.Length];

                // Calculate totals for each month and update text edits for CC
                for (int i = 0; i < meses.Length; i++)
                {
                    gridViewValueCCs.Columns[meses[i]].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
                    totalsCC[i] = Convert.ToDecimal(gridViewValueCCs.Columns[meses[i]].SummaryItem.SummaryValue);
                    totalCC += totalsCC[i];
                    textEditsCC[i].EditValue = totalsCC[i];
                    textEditsCC[i].ReadOnly = true;
                }

                textEditCCTotal.EditValue = totalCC;
                textEditCCTotal.ReadOnly = true;

                gridViewValueCCs.CellValueChanged += gridViewValueCCs_CellValueChanged;
                gridViewValueCCs.UpdateTotalSummary();

                // Calculate totals for each month and update text edits for Historic
                for (int i = 0; i < meses.Length; i++)
                {
                    gridViewHistoricCCs.Columns[meses[i]].Summary.Add(DevExpress.Data.SummaryItemType.Sum);
                    totalsHistoricUp[i] = Convert.ToDecimal(gridViewHistoricCCs.Columns[meses[i]].SummaryItem.SummaryValue);
                    totalHistorico += totalsHistoricUp[i];
                    textEditsHistoric[i].EditValue = totalsHistoricUp[i];
                    textEditsHistoric[i].ReadOnly = true;
                }

                textEditHistoricTotal.EditValue = totalHistorico;
                textEditHistoricTotal.ReadOnly = true;

                gridViewHistoricCCs.CellValueChanged += gridViewUsers_CellValueChanged;
                gridViewHistoricCCs.UpdateTotalSummary();

                // Calculate percentages and update text edits for Historic
                for (int i = 0; i < meses.Length; i++)
                {
                    decimal percentage = Math.Round((totalsHistoricUp[i] / totalHistorico) * 100, 2);
                    textEditsHistoric[i].EditValue = Convert.ToString(percentage);
                }

                var totalJaneiro = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricJan.Text) / 100);
                var totalFevereiro = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricFeb.Text) / 100);
                var totalMarço = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricMar.Text) / 100);
                var totalAbril = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricApr.Text) / 100);
                var totalMaio = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricMay.Text) / 100);
                var totalJunho = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricJun.Text) / 100);
                var totalJulho = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricJul.Text) / 100);
                var totalAgosto = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricAug.Text) / 100);
                var totalSetembro = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricSep.Text) / 100);
                var totalOutubro = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricOct.Text) / 100);
                var totalNovembro = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricNov.Text) / 100);
                var totalDezembro = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricDec.Text) / 100);

                var totalInvestments = new Dictionary<int, decimal>
                {
                { 0, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricJan.Text) / 100) },
                { 1, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricFeb.Text) / 100) },
                { 2, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricMar.Text) / 100) },
                { 3, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricApr.Text) / 100) },
                { 4, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricMay.Text) / 100) },
                { 5, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricJun.Text) / 100) },
                { 6, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricJul.Text) / 100) },
                { 7, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricAug.Text) / 100) },
                { 8, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricSep.Text) / 100) },
                { 9, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricOct.Text) / 100) },
                { 10, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricNov.Text) / 100) },
                { 11, Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment) * (Convert.ToDecimal(textEditHistoricDec.Text) / 100) }
                };

                //XtraMessageBox.Show($"Total Janeiro: {totalJaneiro}\nTotal Fevereiro: {totalFevereiro}\nTotal Março: {totalMarço}\nTotal Abril: {totalAbril}\nTotal Maio: {totalMaio}\nTotal Junho: {totalJunho}\nTotal Julho: {totalJulho}\nTotal Agosto: {totalAgosto}\nTotal Setembro: {totalSetembro}\nTotal Outubro: {totalOutubro}\nTotal Novembro: {totalNovembro}\nTotal Dezembro: {totalDezembro}");

                var textEditsHistoricTable = new DevExpress.XtraEditors.TextEdit[]
                {
                textEditHistoricJan, textEditHistoricFeb, textEditHistoricMar, textEditHistoricApr, textEditHistoricMay,
                textEditHistoricJun, textEditHistoricJul, textEditHistoricAug, textEditHistoricSep, textEditHistoricOct,
                textEditHistoricNov, textEditHistoricDec
                };

                for (int colIndex = 3; colIndex <= 14; colIndex++)
                {
                    decimal allocatedInvestment = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment);
                    var currentColumnHistoric = colIndex - 3;

                    decimal currentColumnInvestment = allocatedInvestment * ((Convert.ToDecimal(textEditsHistoricTable[currentColumnHistoric].Text)) / 100);

                    for (int rowIndex = 0; rowIndex <= 25; rowIndex++)
                    {
                        var cellValue = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[colIndex]);
                        var currentCellName = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[2]);

                        for (int i = 0; i < meses.Length; i++)
                        {
                            // Obter o valor da célula correspondente na linha 0 de gridControlValueHistoric na coluna 0
                            var cellValueHistoric = gridViewHistoricCCs.GetRowCellValue(i, gridViewHistoricCCs.Columns[0]);

                            // Verificar se os valores são iguais
                            if (currentCellName.Equals(cellValueHistoric))
                            {
                                decimal novoValor = Math.Round(percentages[i, currentColumnHistoric] * (currentColumnInvestment / 100), 0);

                                gridViewValueCCs.SetRowCellValue(rowIndex, gridViewValueCCs.Columns[colIndex], novoValor);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há histórico para este centro de custo, então não haverá preenchimento automático");

                textEditCCTotal.Text = "0";

                string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
                DevExpress.XtraEditors.TextEdit[] textEditsCC = { textEditCCJan, textEditCCFeb, textEditCCMar, textEditCCApr, textEditCCMay, textEditCCJun, textEditCCJul, textEditCCAug, textEditCCSep, textEditCCOct, textEditCCNov, textEditCCDec };


                textEditCCTotal.ReadOnly = true;

                gridViewValueCCs.CellValueChanged += gridViewValueCCs_CellValueChanged;
                gridViewValueCCs.UpdateTotalSummary();
            }

            gridViewHistoricCCs.CustomDrawCell += gridViewHistoricCCs_CustomDrawCell;
        }

        private void gridViewHistoricCCs_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            // Check if the column is the 11th or 12th column (index 10 or 11)
            if (e.Column.VisibleIndex == 11 || e.Column.VisibleIndex == 12)
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void FormEditCostCenters_FormClosed(object sender, FormClosedEventArgs e)
        {
            HelperClass.enableMainForm();
        }


        private void gridViewValueCCs_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewValueCCs.UpdateTotalSummary();

            string[] months = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            DevExpress.XtraEditors.TextEdit[] textEdits = { textEditCCJan, textEditCCFeb, textEditCCMar, textEditCCApr, textEditCCMay, textEditCCJun, textEditCCJul, textEditCCAug, textEditCCSep, textEditCCOct, textEditCCNov, textEditCCDec };

            decimal totalCC = 0;
            decimal[] totals = new decimal[months.Length];

            // Calculate totals for each month
            for (int i = 0; i < months.Length; i++)
            {
                totals[i] = Convert.ToDecimal(gridViewValueCCs.Columns[months[i]].SummaryItem.SummaryValue);
                totalCC += totals[i];
            }

            // Calculate percentages and update text edits
            for (int i = 0; i < months.Length; i++)
            {
                try
                {
                    decimal percentage = Math.Round((totals[i] / totalCC) * 100, 2);
                    textEdits[i].EditValue = Convert.ToString(percentage);
                }
                catch (DivideByZeroException)
                {
                    // Handle the exception or simply ignore it
                    textEdits[i].EditValue = "0"; // Set to 0 or any default value
                }
            }

            textEditCCTotal.EditValue = Convert.ToString(totalCC);

        }

        private void gridViewUsers_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void simpleButtonNewVersion_Click(object sender, EventArgs e)
        {
            // Parse the values from the text edit and label control
            decimal totalInvestment = Convert.ToDecimal(textEditCCTotal.Text);

            // Extract only the numeric part from the label text
            string allocatedInvestmentText = labelControlAllocatedInvestment.Text;
            string numericPart = Regex.Replace(allocatedInvestmentText, @"[^\d,]", ""); // Keeps digits and decimal point
            decimal allocatedInvestment = Convert.ToDecimal(numericPart);

            //XtraMessageBox.Show(Convert.ToString(totalInvestment));
            //XtraMessageBox.Show(Convert.ToString(allocatedInvestment));

            // Check the condition
            if (totalInvestment > allocatedInvestment)
            {
                // Exit the method if the condition is met
                XtraMessageBox.Show("Valor alocado no Centro de Custo maior que o estipulado para despesa");
                return;
            }
            else if (totalInvestment < allocatedInvestment)
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
                DialogResult result = XtraMessageBox.Show("Confirma em finalizar alocamento de despesa para Centro de Custo??", "Confirmação", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    // Exit the method if the user chooses No
                    return;
                }
            }
            // Perform the action if the condition is not met
            SqlParameter[] kekw =
                {
                    new SqlParameter("@cavalo", SqlDbType.VarChar, 100) { Value = GlobalVariablesClass.currentCCID }
                };
            string queryDelete = $"DELETE FROM [CostCenterSub] WHERE [costCenterParentID] = {GlobalVariablesClass.currentCCID}";
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.ExecuteNoQuerySQL(queryDelete, "", kekw, false);
            SQLCon.CloseConnectionSQL();


            string investimentoAlocado = GlobalVariablesClass.currentCCInvestiment;
            string investimentoUsado = textEditCCTotal.Text;

            //SqlParameter[] dataNewCostCenterSub =
            //   {

            //        new SqlParameter("@contaGerencialNov", SqlDbType.Decimal) { Value = contaGerencialNov },
            //        new SqlParameter("@contaGerencialDec", SqlDbType.Decimal) { Value = contaGerencialDec }
            //    };

            for (int rowIndex = 0; rowIndex < gridViewValueCCs.RowCount; rowIndex++)
            {
                var contaGerencialNome = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[2]);
                var contaGerencialJan = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[3]);
                var contaGerencialFeb = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[4]);
                var contaGerencialMar = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[5]);
                var contaGerencialApr = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[6]);
                var contaGerencialMay = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[7]);
                var contaGerencialJun = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[8]);
                var contaGerencialJul = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[9]);
                var contaGerencialAug = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[10]);
                var contaGerencialSep = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[11]);
                var contaGerencialOct = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[12]);
                var contaGerencialNov = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[13]);
                var contaGerencialDec = gridViewValueCCs.GetRowCellValue(rowIndex, gridViewValueCCs.Columns[14]);

                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                SqlParameter[] dataNewCostCenterSub =
                {
                    new SqlParameter("@contaGerencialParentID", SqlDbType.VarChar, 100) { Value = GlobalVariablesClass.currentCCID },
                    new SqlParameter("@contaGerencialManagerID", SqlDbType.VarChar, 100) { Value = GlobalVariablesClass.currentManagerID },
                    new SqlParameter("@contaGerencialVersionID", SqlDbType.VarChar, 100) { Value = GlobalVariablesClass.currentVersion },
                    new SqlParameter("@contaGerencialNome", SqlDbType.VarChar, 200) { Value = contaGerencialNome },
                    new SqlParameter("@contaGerencialJan", SqlDbType.Decimal) { Value = contaGerencialJan },
                    new SqlParameter("@contaGerencialFeb", SqlDbType.Decimal) { Value = contaGerencialFeb },
                    new SqlParameter("@contaGerencialMar", SqlDbType.Decimal) { Value = contaGerencialMar },
                    new SqlParameter("@contaGerencialApr", SqlDbType.Decimal) { Value = contaGerencialApr },
                    new SqlParameter("@contaGerencialMay", SqlDbType.Decimal) { Value = contaGerencialMay },
                    new SqlParameter("@contaGerencialJun", SqlDbType.Decimal) { Value = contaGerencialJun },
                    new SqlParameter("@contaGerencialJul", SqlDbType.Decimal) { Value = contaGerencialJul },
                    new SqlParameter("@contaGerencialAug", SqlDbType.Decimal) { Value = contaGerencialAug },
                    new SqlParameter("@contaGerencialSep", SqlDbType.Decimal) { Value = contaGerencialSep },
                    new SqlParameter("@contaGerencialOct", SqlDbType.Decimal) { Value = contaGerencialOct },
                    new SqlParameter("@contaGerencialNov", SqlDbType.Decimal) { Value = contaGerencialNov },
                    new SqlParameter("@contaGerencialDec", SqlDbType.Decimal) { Value = contaGerencialDec }
                };

                //XtraMessageBox.Show(GlobalVariablesClass.currentCCID + GlobalVariablesClass.currentManagerID + GlobalVariablesClass.currentVersion + contaGerencialNome + contaGerencialJan + contaGerencialFeb + contaGerencialMar + contaGerencialApr + contaGerencialMay + contaGerencialJun + contaGerencialJul + contaGerencialAug + contaGerencialSep + contaGerencialOct + contaGerencialNov + contaGerencialDec);

                string query = @"
                INSERT INTO [CostCenterSub] 
                (
                    [costCenterParentID], [managerID], [versionID], [contaGerencial], 
                    [january], [february], [march], [april], [may], [june], 
                    [july], [august], [september], [october], [november], [december]
                ) 
                VALUES 
                (
                    @contaGerencialParentID, @contaGerencialManagerID, @contaGerencialVersionID,
                    @contaGerencialNome, @contaGerencialJan, @contaGerencialFeb, 
                    @contaGerencialMar, @contaGerencialApr, @contaGerencialMay, @contaGerencialJun, 
                    @contaGerencialJul, @contaGerencialAug, @contaGerencialSep, @contaGerencialOct, 
                    @contaGerencialNov, @contaGerencialDec
                )";

                SQLCon.ExecuteNoQuerySQL(query, "", dataNewCostCenterSub, false);
                SQLCon.CloseConnectionSQL();
            }

            //GlobalVariablesClass.currentCCID

            // Convert GlobalVariablesClass.currentCCInvestiment to decimal
            decimal investimentoCCAtual = Convert.ToDecimal(GlobalVariablesClass.currentCCInvestiment);
            decimal investimentoAlocadoAtual = Convert.ToDecimal(textEditCCTotal.Text);
            string status = "Realizado";

            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SqlParameter[] updateCCValues =
            {
                    new SqlParameter("@investimentoCCAtual", SqlDbType.Decimal) { Value = Convert.ToDecimal(investimentoCCAtual) },
                    new SqlParameter("@investimentoAlocadoAtual", SqlDbType.Decimal) { Value = Convert.ToDecimal(investimentoAlocadoAtual) },
                    new SqlParameter("@status", SqlDbType.VarChar, 100) { Value = status }
            };
            SQLCon.ExecuteNoQuerySQL($@"UPDATE [costCenterParent] 
                                    SET [allocatedValue] = @investimentoCCAtual, 
	                                    [usedValue] = @investimentoAlocadoAtual,
                                        [status] = @status
                                    WHERE [costCenterID] = {GlobalVariablesClass.currentCCID}", 
                                    "", updateCCValues, false);

            //// Compare the values and perform actions
            //if (investimentoAlocadoAtual < investimentoCCAtual)
            //{
            //    // Action when investimentoAlocadoAtual is less than investimentoCCAtual
            //    XtraMessageBox.Show("Investimento Alocado Atual is less than Investimento CC Atual.");
            //}
            //else if (investimentoAlocadoAtual == investimentoCCAtual)
            //{
            //    // Action when investimentoAlocadoAtual is equal to investimentoCCAtual
            //    XtraMessageBox.Show("Investimento Alocado Atual is equal to Investimento CC Atual.");
            //}
            //else if (investimentoAlocadoAtual > investimentoCCAtual)
            //{
            //    // Action when investimentoAlocadoAtual is greater than investimentoCCAtual
            //    XtraMessageBox.Show("Investimento Alocado Atual is greater than Investimento CC Atual.");
            //}

            XtraMessageBox.Show("Etapa concluída com sucesso");
            //FormPrincipal.instance.barButtonItemInitialPageInstance.PerformClick();

            FormPrincipal.instance.barButtonItemInitialPageInstance.PerformClick();

            //FormPrincipal.instance.Close();

            Close();
        }
    }
}