using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_PnL.Classes
{
    //global varibles to be used between forms and usercontrols
    static class GlobalVariablesClass
    {
        //string for the current database being used in the MSSQLServer
        private static string _baseDados = "PLEDIGITAL";
        public static string BaseDados
        {
            get { return _baseDados; }
            set { _baseDados = value; }
        }

        //string for the current flag of the UserControl instance being shown in the FormPrincipal
        private static string _panelPrincipalFlag = "";
        public static string PanelPrincipalFlag
        {
            get { return _panelPrincipalFlag; }
            set { _panelPrincipalFlag = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _chooseDateFlag = "";
        public static string chooseDateFlag
        {
            get { return _chooseDateFlag; }
            set { _chooseDateFlag = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentVersion = "";
        public static string currentVersion
        {
            get { return _currentVersion; }
            set { _currentVersion = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentVersionInvestment = "";
        public static string currentVersionInvestment
        {
            get { return _currentVersionInvestment; }
            set { _currentVersionInvestment = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentVPID = "";
        public static string currentVPID
        {
            get { return _currentVPID; }
            set { _currentVPID = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentVP = "";
        public static string currentVP
        {
            get { return _currentVP; }
            set { _currentVP = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentVPInvestiment = "";
        public static string currentVPInvestiment
        {
            get { return _currentVPInvestiment; }
            set { _currentVPInvestiment = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentCCName = "";
        public static string currentCCname
        {
            get { return _currentCCName; }
            set { _currentCCName = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentCCInvestiment = "";
        public static string currentCCInvestiment
        {
            get { return _currentCCInvestiment; }
            set { _currentCCInvestiment = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentCCVP = "";
        public static string currentCCVP
        {
            get { return _currentCCVP; }
            set { _currentCCVP = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentCCID = "";
        public static string currentCCID
        {
            get { return _currentCCID; }
            set { _currentCCID = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentCCNumber = "";
        public static string currentCCNumber
        {
            get { return _currentCCNumber; }
            set { _currentCCNumber = value; }
        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentManagerID = "";
        public static string currentManagerID
        {
            get { return _currentManagerID; }
            set { _currentManagerID = value; }

        }

        //string flag for the use of the current instance of the FormChooseDate
        private static string _currentVPArea = "";
        public static string currentVPArea
        {
            get { return _currentVPArea; }
            set { _currentVPArea = value; }
        }

        #region Variáveis globais gerais

        //String global pra se manuseiar um ID de PDPC
        private static string _pdpcAtualId = "";
        public static string PDPCAtualID
        {
            get { return _pdpcAtualId; }
            set { _pdpcAtualId = value; }
        }

        //String global pra se manuseiar o tipo do PDPC atual
        private static string _pdpcAtualTipo = "";
        public static string PDPCAtualTipo
        {
            get { return _pdpcAtualTipo; }
            set { _pdpcAtualTipo = value; }
        }

        //String global pra se manuseiar a etapa do PDPC atual
        private static string _pdpcAtualEtapa = "";
        public static string PDPCAtualEtapa
        {
            get { return _pdpcAtualEtapa; }
            set { _pdpcAtualEtapa = value; }
        }

        //String global pra se manuseiar a nota fiscal do PDPC atual
        private static string _pdpcAtualNF = "";
        public static string PDPCAtualNF
        {
            get { return _pdpcAtualNF; }
            set { _pdpcAtualNF = value; }
        }

        //Bool global pra checar se um produto crítico foi incluído
        private static bool _produtocriticoincluidoflag;
        public static bool ProdutoCriticoIncluidoFlag
        {
            get { return _produtocriticoincluidoflag; }
            set { _produtocriticoincluidoflag = value; }
        }

        //Bool global pra controlar flag de produto crítivo Anvisa ou não
        private static bool _produtocriticoflag;
        public static bool ProdutoCriticoFlag
        {
            get { return _produtocriticoflag; }
            set { _produtocriticoflag = value; }
        }

        #endregion

        #region global variables to creation of the current contract

        //global string to handle current client code
        private static string _currentContractGcatId = "";
        public static string currentContractGcatId
        {
            get { return _currentContractGcatId; }
            set { _currentContractGcatId = value; }
        }

        //global string to handle current client code
        private static string _currentContractClientCode = "";
        public static string currentContractClientCode
        {
            get { return _currentContractClientCode; }
            set { _currentContractClientCode = value; }
        }

        private static string _currentContractCNPJ = "";
        public static string currentContractCNPJ
        {
            get { return _currentContractCNPJ; }
            set { _currentContractCNPJ = value; }
        }

        private static string _currentContractName = "";
        public static string currentContractName
        {
            get { return _currentContractName; }
            set { _currentContractName = value; }
        }

        private static string _currentContractAddress = "";
        public static string currentContractAddress
        {
            get { return _currentContractAddress; }
            set { _currentContractAddress = value; }
        }

        private static string _currentContractCep = "";
        public static string currentContractCep
        {
            get { return _currentContractCep; }
            set { _currentContractCep = value; }
        }

        private static string _currentContractCity = "";
        public static string currentContractCity
        {
            get { return _currentContractCity; }
            set { _currentContractCity = value; }
        }

        private static string _currentContractState = "";
        public static string currentContractState
        {
            get { return _currentContractState; }
            set { _currentContractState = value; }
        }

        private static string _currentContractTelephone = "";
        public static string currentContractTelephone
        {
            get { return _currentContractTelephone; }
            set { _currentContractTelephone = value; }
        }
        #endregion
    }
}
