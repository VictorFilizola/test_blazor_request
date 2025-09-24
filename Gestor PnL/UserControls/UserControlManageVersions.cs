using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Gestor_PnL.Classes;
using Gestor_PnL.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Gestor_PnL.UserControls
{
    public partial class UserControlManageVersions : DevExpress.XtraEditors.XtraUserControl
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();

        public UserControlManageVersions()
        {
            InitializeComponent();

            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable($"SELECT [versionID] as Versao ,[status] as Status, [step] as Etapa ,[plannedInvestment] as InvestimentoPlanejado ,[usedInvestment] as InvestimentoUsado ,[creationDate] as DataCriacao ,[finishDate] as DataFinalizacao FROM [PLEDIGITAL].[dbo].[versionParent]");
            gridControlVersions.DataSource = SQLCon.DataTable;

            gridView1.PopulateColumns();
            foreach (GridColumn column in gridView1.Columns) // disable editing for all columns
                column.OptionsColumn.AllowEdit = false;

            //gridView1.Columns["Status"].OptionsColumn.AllowEdit = true;
        }

        private void simpleButtonNewVersion_Click(object sender, EventArgs e)
        {
            //open new FormNewVersion form
            var FormNewVersion = new FormNewVersion();
            FormNewVersion.Show();

            //disable the main form
            HelperClass.disableMainForm();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var versionID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]);
                var versionInvestment = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]);
                var currentStep = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]);

                GlobalVariablesClass.currentVersion = versionID.ToString();
                GlobalVariablesClass.currentVersionInvestment = versionInvestment.ToString();

                if (currentStep.ToString() == "Etapa 1 - Valores Diretorias")
                {
                    var FormStep1VP = new FormStep1VP();
                    FormStep1VP.Show();

                    //disable the main form
                    HelperClass.disableMainForm();
                }
                if (currentStep.ToString() == "Etapa 2 - Valores Gerenciais")
                {
                    var FormStep2Management = new FormStep2Management();
                    FormStep2Management.Show();

                    //disable the main form
                    HelperClass.disableMainForm();
                }
                if (currentStep.ToString() == "Etapa 3 - Valores Centros de Custo")
                {
                    //put UserControlPrincipal at the panelControlPrincipal during program start
                    var UserControlEditUsers = new UserControls.UserControlControlVersion();
                    UserControlEditUsers.Dock = DockStyle.Fill;

                    FormPrincipal.instance.panelControlPrincipalInstance.Controls.Clear();
                    FormPrincipal.instance.panelControlPrincipalInstance.Controls.Add(UserControlEditUsers);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
