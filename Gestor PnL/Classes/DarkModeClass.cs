using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ReportServer.ServiceModel.Client;
using Gestor_PnL;

namespace Gestor_PnL.Classes
{
    //functions in order to handle darktheme troughout the program
    internal class DarkModeClass
    {
        //boolean flag to determinate if darkmode is on or off
        public static bool _darkModeFlag = false;
        public static bool darkModeFlag
        {
            get { return _darkModeFlag; }
            set { _darkModeFlag = value; }
        }

        //handle the darkmode flag when the barButtonItemdarkModeFlag at FormPrincipal is pressed
        public static void handleDarkthemeFormPrincipal()
        {
            SQLConnectionClass SQLCon = new SQLConnectionClass();
            if (darkModeFlag == true)
            {
                //change user darkmode preference in database to lightmode
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                SqlParameter[] dataLightModePreference =
                {
                    new SqlParameter("@lightModePreference", SqlDbType.VarChar, 100) { Value = "Lightmode" },
                };
                //SQLCon.ExecuteNoQuerySQL($"UPDATE users SET darkModePreference = 'Lightmode' WHERE [422code] = '{UserClass.userFuncional}'", "", dataLightModePreference, false);
                //SQLCon.CloseConnectionSQL();

                FormPrincipal.instance.defaultLookAndFeelInstance.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinSvgPalette.WXI.Default);
                darkModeFlag = false;
            }
            else
            {
                //change user darkmode preference in database to darkmode
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                SqlParameter[] dataDarkModePreference =
                {
                    new SqlParameter("@lightModePreference", SqlDbType.VarChar, 100) { Value = "Darkmode" },
                };
                //SQLCon.ExecuteNoQuerySQL($"UPDATE users SET darkModePreference = 'Darkmode' WHERE [422code] = '{UserClass.userFuncional}'", "", dataDarkModePreference, false);
                //SQLCon.CloseConnectionSQL();

                FormPrincipal.instance.defaultLookAndFeelInstance.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinSvgPalette.WXI.Darkness);
                darkModeFlag = true;
            }
        }
    }
}
