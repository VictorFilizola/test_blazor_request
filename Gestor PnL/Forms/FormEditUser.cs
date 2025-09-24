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

namespace Gestor_PnL.Forms
{
    public partial class FormEditUser : DevExpress.XtraEditors.XtraForm
    {
        public FormEditUser()
        {
            InitializeComponent();
        }

        private void EditUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            //enable main form
            HelperClass.enableMainForm();
        }
    }
}