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
    public partial class FormNewCCValue : DevExpress.XtraEditors.XtraForm
    {
        public FormNewCCValue()
        {
            InitializeComponent();
        }

        private void simpleButtonCreateVersion_Click(object sender, EventArgs e)
        {
            GlobalVariablesClass.currentCCInvestiment = textEditInvestmenteValue.Text;

            var FormEditCostCenters = new FormEditCostCenters();
            FormEditCostCenters.Show();

            FormPrincipal.instance.barButtonItemInitialPageInstance.PerformClick();

            Close();
        }

        private void FormNewVersion_FormClosed(object sender, FormClosedEventArgs e)
        {
            //enable main form
            HelperClass.enableMainForm();
        }
    }
}