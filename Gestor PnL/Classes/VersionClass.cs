using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_PnL.Classes
{
    class VersionClass
    {
        //global variables to be used between forms and usercontrols

        //global string to handle the current version of the program
        private static string _softwareVersion = "1.0";
        public static string softwareVersion
        {
            get { return _softwareVersion; }
            set { _softwareVersion = value; }
        }
    }
}
