 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_PnL.Classes
{
    class UserClass
    {
        //global variables to be used between forms and usercontrols

        //global string to manipulate the logged user's id 
        private static string _userId = "1";
        public static string userId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        //global string to manipulate the logged user's login 
        private static string _userFuncional = "TEIXVIBR";
        public static string userFuncional
        {
            get { return _userFuncional; }
            set { _userFuncional = value; }
        }

        //global string to manipulate the logged user's name
        private static string _userName = "Victor Filizola";
        public static string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        //global string to manipulate the logged user's permision
        private static string _userPermission = "Master";
        public static string userPermission
        {
            get { return _userPermission; }
            set { _userPermission = value; }
        }

        //global string to manipulate the logged user's e-mail
        private static string _userEmail = "victor.filizola_teixeira@bbraun.com";
        public static string userEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }

        //global string to manipulate the logged user's darkmode preference
        private static string _userDarkmodePreference = "Darkmode";
        public static string userDarkmodePreference
        {
            get { return _userDarkmodePreference; }
            set { _userDarkmodePreference = value; }
        }
    }
}
