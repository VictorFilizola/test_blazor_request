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

namespace Gestor_PnL.UserControls
{
    public partial class UserControlEditVPs : DevExpress.XtraEditors.XtraUserControl
    {
        SQLConnectionClass SQLCon = new SQLConnectionClass();

        public UserControlEditVPs()
        {
            InitializeComponent();

            string query = "SELECT TOP (1000) [DiretoriaID] as ID,[DiretorniaNome] as Diretoria ,[Responsavel] as Responsavel FROM [PLEDIGITAL].[dbo].[VP]\r\n";

            //load current contract items data to gridControlItems
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(query);
            gridControlVPs.DataSource = SQLCon.DataTable;
        }
    }
}
