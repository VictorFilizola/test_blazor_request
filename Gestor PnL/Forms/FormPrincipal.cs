using DevExpress.Charts.Native;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Gestor_PnL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gestor_PnL
{
    public partial class FormPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //define variables to handle e-mail calls
        EmailHandlerClass EmailHandlerClass = new EmailHandlerClass();

        public PanelControl panelControlPrincipalInstance;
        SQLConnectionClass SQLCon = new SQLConnectionClass();
        //define the instances of this form
        public static FormPrincipal instance;
        public DefaultLookAndFeel defaultLookAndFeelInstance;
        public BarButtonItem barButtonItemInitialPageInstance;
        public BarButtonItem barButtonItemManageVersionsInstance;
        public BarButtonItem barButtonItemInitialPageDirectorsInstance;

        //boolean flag to determinate if darkmode is on or off
        public static bool _darkModeFlag = false;
        public static bool darkModeFlag
        {
            get { return _darkModeFlag; }
            set { _darkModeFlag = value; }
        }

        public FormPrincipal()
        {
            InitializeComponent();

            //get user's login 
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            userName = userName.Remove(0, 4);
            userName = userName.ToUpper();

            //Ale
            //userName = "ProjGlob";

            //managers test
            //userName = "DINIMABR";
            //userName = "BARRREBR";
            //userName = "SOUZAXBR"; 
            //userName = "FERRCNBR";
            //userName = "KOCHKEBR";
            //userName = "PASQMABR";
            //userName = "SOUZPTBR";
            //userName = "ProjGlob";
            //userName = "SEBBFRBR";
            //serName = "SENRVEBR";
            //userName = "CUNHERBR";
            userName = "RIBEPEBR";

            //directors test
            //userName = "ALEXMABR";
            //userName = "CORRADBR";
            //userName = "KOCHKEBR";
            //userName = "LOPEDABR";
            //userName = "DICKMIBR";
            //userName = "REISTABR";
            //userName = "BARBERBR";
            //userName = "SILV43BR";

            //XtraMessageBox.Show(userName);

            //define the instances of this form
            instance = this;
            defaultLookAndFeelInstance = defaultLookAndFeel;
            panelControlPrincipalInstance = panelControlPrincipal;
            barButtonItemInitialPageInstance = barButtonItemInitialPage;
            barButtonItemManageVersionsInstance = barButtonItemManageVersions;
            barButtonItemInitialPageDirectorsInstance = barButtonItemInitialPageDirectors;

            //check if user is in database
            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable("SELECT TRIM([name]), TRIM([login]), TRIM([permission]), TRIM([email]), [themePreference] FROM users");
            int i = 0;
            foreach (DataRow row in SQLCon.DataTable.Rows)
            {
                if (userName == SQLCon.DataTable.Rows[i][1].ToString())
                {
                    UserClass.userName = SQLCon.DataTable.Rows[i][0].ToString();
                    UserClass.userFuncional = SQLCon.DataTable.Rows[i][1].ToString();
                    UserClass.userPermission = SQLCon.DataTable.Rows[i][2].ToString();
                    UserClass.userEmail = SQLCon.DataTable.Rows[i][3].ToString();

                    //XtraMessageBox.Show(UserClass.userName + UserClass.userFuncional + UserClass.userPermission + UserClass.userEmail);

                    goto SairLoop;
                }
                i++;
            }
            XtraMessageBox.Show("Usuário logado não está cadastrado no sistema");
            SairLoop:
            SQLCon.CloseConnectionSQL();

            //put user funcional, user permission and program version names into the footer
            //labelControlUser.Text = UserClass.userName;
            labelControlUser.Text = UserClass.userName;
            labelControlPermission.Text = UserClass.userPermission;
            labelControlVersion.Text = VersionClass.softwareVersion;

            barButtonItemManageCostCenters.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemManageUsers.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemManageVPs.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //GlobalVariablesClass.currentVP

            try
            {
                // Control what user permission can show
                if (UserClass.userPermission == "Manager")
                {
                    instance.ribbonPageGroupController.Visible = false;
                    instance.ribbonPageGroupDiretores.Visible = false;

                    barButtonItemInitialPage.PerformClick();
                }

                if (UserClass.userPermission == "Director")
                {
                    string getCurrentVPArea = @$"SELECT TOP (1)
                                              [versionID]
                                              ,[vpName]
                                              ,[totalInvestment]
                                              ,[vpID]
                                              ,[status]
                                        FROM 
	                                        [PLEDIGITAL].[dbo].[vpParent] 
                                        WHERE 
	                                        [vpUser] LIKE '%{UserClass.userName}%' 
                                        ORDER BY 
	                                        [VersionID] 
                                        DESC";
                    SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                    SQLCon.RetornaDataTable(getCurrentVPArea);
                    var firstCellValue = SQLCon.DataTable.Rows[0][2];
                    GlobalVariablesClass.currentVersionInvestment = Convert.ToString(firstCellValue);
                    GlobalVariablesClass.currentVPArea = Convert.ToString(SQLCon.DataTable.Rows[0][1]);
                    GlobalVariablesClass.currentVersion = Convert.ToString(SQLCon.DataTable.Rows[0][0]);
                    GlobalVariablesClass.currentVPID = Convert.ToString(SQLCon.DataTable.Rows[0][3]);
                    string status = Convert.ToString(SQLCon.DataTable.Rows[0][4]);

                    if (status == "Etapa 3 - dados de gerencia atribuídos")
                    {
                        instance.ribbonPageGroupController.Visible = false;
                        instance.ribbonPageGroupDiretores.Visible = false;

                        barButtonItemInitialPage.PerformClick();
                    }
                    else
                    {
                        instance.ribbonPageGroupController.Visible = false;
                        instance.ribbonPageGroupPrincipal.Visible = false;

                        barButtonItembarButtonItemInitialPageDirectors.PerformClick();
                    }
                    //instance.ribbonPageGroupController.Visible = false;
                    //instance.ribbonPageGroupPrincipal.Visible = false;

                    //barButtonItembarButtonItemInitialPageDirectors.PerformClick();
                }
                if (UserClass.userPermission == "Controller" || UserClass.userPermission == "Master")
                {
                    instance.ribbonPageGroupPrincipal.Visible = false;
                    instance.ribbonPageGroupDiretores.Visible = false;

                    barButtonItemManageVersions.PerformClick();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Você não possui acesso ao programa. Por favor, contatar o administrador se o uso é necessário", "Sem Atuação Necessária", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //XtraMessageBox.Show($"Sua gerência não precisa de atuação neste momento, fechando programada... Mensagem programática: {ex.Message}", "Sem Atuação Necessária", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            //instance.ribbonPageGroupPrincipal.Visible = false;

            //put userControlPrincipal at front when program start
            //var UserControlPrincipal = new UserControls.UserControlPrincipal();
            //UserControlPrincipal.Dock = DockStyle.Fill;
            //instance.panelControlPrincipalInstance.Controls.Clear();
            //instance.panelControlPrincipalInstance.Controls.Add(UserControlPrincipal);
        }


        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItemChangeTheme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (darkModeFlag == true)
            {
                //FormPrincipal.instance.defaultLookAndFeelInstance.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinSvgPalette.WXI.Default);
                darkModeFlag = false;
            }
            else
            {
                FormPrincipal.instance.defaultLookAndFeelInstance.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinSvgPalette.WXI.Darkness);
                darkModeFlag = true;
            }
        }

        private void barButtonItemManageCCs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////put UserControlPrincipal at the panelControlPrincipal during program start
            //var UserControlEditCCs = new UserControls.UserControlEditCCs();
            //UserControlEditCCs.Dock = DockStyle.Fill;
            //panelControlPrincipal.Controls.Clear();
            //panelControlPrincipal.Controls.Add(UserControlEditCCs);
        }

        private void barButtonItemManageCostCenters_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //put UserControlPrincipal at the panelControlPrincipal during program start
            var UserControlEditCCs = new UserControls.UserControlEditCostCenters();
            UserControlEditCCs.Dock = DockStyle.Fill;
            panelControlPrincipal.Controls.Clear();
            panelControlPrincipal.Controls.Add(UserControlEditCCs);
        }

        private void barButtonItemManageUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //put UserControlPrincipal at the panelControlPrincipal during program start
            var UserControlEditUsers = new UserControls.UserControlControlVersion();
            UserControlEditUsers.Dock = DockStyle.Fill;
            panelControlPrincipal.Controls.Clear();
            panelControlPrincipal.Controls.Add(UserControlEditUsers);
        }

        private void barButtonItemManageVPs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //put UserControlPrincipal at the panelControlPrincipal during program start
            var UserControlEditVPs = new UserControls.UserControlEditVPs();
            UserControlEditVPs.Dock = DockStyle.Fill;
            panelControlPrincipal.Controls.Clear();
            panelControlPrincipal.Controls.Add(UserControlEditVPs);
        }

        private void barButtonItemManageVersions_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //put UserControlManageVersions at the panelControlPrincipal during program start
            var UserControlManageVersions = new UserControls.UserControlManageVersions();
            UserControlManageVersions.Dock = DockStyle.Fill;
            panelControlPrincipal.Controls.Clear();
            panelControlPrincipal.Controls.Add(UserControlManageVersions);
        }

        private void barButtonItemInitialPage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                //put UserControlManageVersions at the panelControlPrincipal during program start
                var UserControlEditCostCenters = new UserControls.UserControlEditCostCenters();
                UserControlEditCostCenters.Dock = DockStyle.Fill;
                panelControlPrincipal.Controls.Clear();
                panelControlPrincipal.Controls.Add(UserControlEditCostCenters);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Sua gerência não precisa de atuação neste momento, fechando programa... Mensagem programática: {ex.Message}", "Sem Atuação Necessária", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void barButtonItembarButtonItemInitialPageDirectors_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //put UserControlManageVersions at the panelControlPrincipal during program start
                var UserControlEditManagerAreas = new UserControls.UserControlEditManagerAreas();
                UserControlEditManagerAreas.Dock = DockStyle.Fill;
                panelControlPrincipal.Controls.Clear();
                panelControlPrincipal.Controls.Add(UserControlEditManagerAreas);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Sua diretoria não precisa de atuação neste momento, fechando programa... Mensagem programática: {ex.Message}", "Sem Atuação Necessária", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void barButtonItemSendEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
            string getCurrentVPManagers = @$"SELECT DISTINCT
                                                [responsible]
                                            FROM 
	                                            [PLEDIGITAL].[dbo].[costCenters] 
                                            WHERE 
	                                            VP 
                                            LIKE 'Aevitum'
                                            ";

            SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
            SQLCon.RetornaDataTable(getCurrentVPManagers);
            // Iterate through each item of the DataTable
            foreach (DataRow row in SQLCon.DataTable.Rows)
            {
                string responsible = row["responsible"].ToString();
                // Perform actions with the 'responsible' value

                string getCurrentManagersEmails = @$"SELECT TOP (1) 
                                                    [email]
                                                FROM 
                                                    [PLEDIGITAL].[dbo].[users] 
                                                WHERE 
                                                    [name] 
                                                LIKE '{responsible}'
                                                ";
                SQLCon.ConnectSQL(GlobalVariablesClass.BaseDados);
                SQLCon.RetornaDataTable(getCurrentManagersEmails);

                string managerEmail = Convert.ToString(SQLCon.DataTable.Rows[0][0]);

                EmailHandlerClass.SendEmail($"Caro gestor {responsible}, a sua despesa gerencial já foi alocada. Você pode acessar o programa e realizar sua atuação.",
                                        $"{managerEmail}",
                                        $"Despesas 2024 - Centros de custo do Gestor {responsible} podem ser preenchidos");

                EmailHandlerClass.SendEmail($"Caro gestor {responsible}, a sua despesa gerencial já foi alocada. Você pode acessar o programa e realizar sua atuação. e-mail: {managerEmail}",
                                        $"victor.filizola_teixeira@bbraun.com",
                                        $"Despesas 2024 - Centros de custo do Gestor {responsible} podem ser preenchidos");
            }
        }
    }
}
