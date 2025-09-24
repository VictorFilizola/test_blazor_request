using DevExpress.XtraEditors;
using Gestor_PnL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using OfficeOpenXml;
using System.IO;

namespace Gestor_PnL.UserControls
{
    public partial class UserControlControlVersion : DevExpress.XtraEditors.XtraUserControl
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();

        public UserControlControlVersion()
        {
            InitializeComponent();

            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(@$"SELECT 
	                                        *
                                        FROM 
	                                        [PLEDIGITAL].[dbo].[costCenterParent] 
                                        WHERE 
	                                        [versionID] = '{GlobalVariablesClass.currentVersion}'");
            gridControlUsers.DataSource = SQLCon.DataTable;
        }

        private void simpleButtonNewVersion_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Todos os Centros de Custo precisam ter seus valores alocados para a versão poder ser finalizada");
        }

        private void simpleButtonExportExcel_Click(object sender, EventArgs e)
        {
            string Query1 = @$"SELECT [managerID]
                                      ,[versionID]
                                      ,[managerName]
                                      ,[allocatedInvestment] as InvestimentoAlocado
                                      ,[usedInvestment] as InvestimentoUsado
                                      ,[status]
                              FROM [PLEDIGITAL].[dbo].[managerParent] 
                              WHERE [versionID] = {GlobalVariablesClass.currentVersion}";
            string Query2 = @$"SELECT [costCenterID]
                                      ,[versionID]
                                      ,[managerID]
                                      ,[status]
                                      ,[costCenterCode] as CodigoCC
                                      ,[costCenterName] as NomeCC
                                      ,[user] as Usuario
                                      ,[vp] as Diretor
                                      ,[allocatedValue] as InvestimentoAlocado
                                      ,[usedValue] as InvestimentoUsado
                              FROM [PLEDIGITAL].[dbo].[costCenterParent]
                              WHERE [versionID] = {GlobalVariablesClass.currentVersion}";
            string Query3 = @$"SELECT 
                                    CCS.[costCenterSubID],
                                    CCS.[costCenterParentID],
                                    CCS.[managerID],
                                    CCS.[versionID],
	                                CCP.[costCenterCode],
                                    CCP.[costCenterName],
                                    CCS.[contaGerencial],
                                    CCS.[january],
                                    CCS.[february],
                                    CCS.[march],
                                    CCS.[april],
                                    CCS.[may],
                                    CCS.[june],
                                    CCS.[july],
                                    CCS.[august],
                                    CCS.[september],
                                    CCS.[october],
                                    CCS.[november],
                                    CCS.[december]
                                FROM 
                                    [PLEDIGITAL].[dbo].[CostCenterSub] AS CCS
                                INNER JOIN 
                                    [PLEDIGITAL].[dbo].[costCenterParent] AS CCP
                                ON 
                                    CCS.[costCenterParentID] = CCP.[costCenterID]
                                WHERE CCS.[versionID] = { GlobalVariablesClass.currentVersion}";

            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(Query1);
            DataTable dt1 = SQLCon.DataTable;
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(Query2);
            DataTable dt2 = SQLCon.DataTable;
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(Query3);
            DataTable dt3 = SQLCon.DataTable;

            // Open a SaveFileDialog to let the user choose the file path
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Salvar arquivo Excel";
                saveFileDialog.FileName = "LEDigital_ExcelGerado.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Create the Excel file with multiple sheets
                    CreateExcelFileWithMultipleSheets(dt1, dt2, dt3, filePath);

                    XtraMessageBox.Show("Excel gerado com sucesso");
                }
            }
        }

        private void CreateExcelFileWithMultipleSheets(DataTable dt1, DataTable dt2, DataTable dt3, string filePath)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                // Add first sheet and load data from the first DataTable
                var worksheet1 = package.Workbook.Worksheets.Add("Sheet1");
                worksheet1.Cells["A1"].LoadFromDataTable(dt1, true);

                // Add second sheet and load data from the second DataTable
                var worksheet2 = package.Workbook.Worksheets.Add("Sheet2");
                worksheet2.Cells["A1"].LoadFromDataTable(dt2, true);

                // Add third sheet and load data from the third DataTable
                var worksheet3 = package.Workbook.Worksheets.Add("Sheet3");
                worksheet3.Cells["A1"].LoadFromDataTable(dt3, true);

                // Save the package to the specified file path
                FileInfo file = new FileInfo(filePath);
                package.SaveAs(file);
            }
        }
    }
}
