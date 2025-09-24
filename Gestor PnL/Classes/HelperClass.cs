using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Svg;
using DevExpress.Utils;

namespace Gestor_PnL.Classes
{
    //class with function to handle various miscellaneous functions in the project 
    internal class HelperClass
    {
        //enable main FormPrincipal
        public static void enableMainForm()
        {
            FormPrincipal.instance.Enabled = true;
        }

        //dehabilitate FormPrincipal
        public static void disableMainForm()
        {
            FormPrincipal.instance.Enabled = false;
        }

        //public static void showRibbonPageGroupNewContract()
        //{
        //    hideRibbonPageGroups();
        //    FormPrincipal.instance.ribbonPageGroupNewContractInstance.Visible = true;
        //}

        //public static void showRibbonPageGroupContractData()
        //{
        //    hideRibbonPageGroups();
        //    FormPrincipal.instance.ribbonPageGroupContractDataInstance.Visible = true;
        //}

        //public static void hideRibbonPageGroups()
        //{
        //    FormPrincipal.instance.ribbonPageGroupNewContractInstance.Visible = false;
        //    FormPrincipal.instance.ribbonPageGroupContractDataInstance.Visible = false;
        //}
    }
}
