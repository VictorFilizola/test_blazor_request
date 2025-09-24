namespace Gestor_PnL.UserControls
{
    partial class UserControlControlVersion
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            simpleButtonExportExcel = new DevExpress.XtraEditors.SimpleButton();
            gridControlUsers = new DevExpress.XtraGrid.GridControl();
            gridViewUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(simpleButtonExportExcel);
            groupControl1.Controls.Add(gridControlUsers);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1054, 600);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "Editar Usuários";
            // 
            // simpleButtonExportExcel
            // 
            simpleButtonExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            simpleButtonExportExcel.Location = new System.Drawing.Point(614, 3);
            simpleButtonExportExcel.Name = "simpleButtonExportExcel";
            simpleButtonExportExcel.Size = new System.Drawing.Size(148, 49);
            simpleButtonExportExcel.TabIndex = 52;
            simpleButtonExportExcel.Text = "Exportar Excel";
            simpleButtonExportExcel.Click += simpleButtonExportExcel_Click;
            // 
            // gridControlUsers
            // 
            gridControlUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlUsers.Location = new System.Drawing.Point(2, 23);
            gridControlUsers.MainView = gridViewUsers;
            gridControlUsers.Name = "gridControlUsers";
            gridControlUsers.Size = new System.Drawing.Size(1050, 575);
            gridControlUsers.TabIndex = 0;
            gridControlUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewUsers });
            // 
            // gridViewUsers
            // 
            gridViewUsers.GridControl = gridControlUsers;
            gridViewUsers.Name = "gridViewUsers";
            gridViewUsers.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridViewUsers.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            // 
            // UserControlControlVersion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Name = "UserControlControlVersion";
            Size = new System.Drawing.Size(1054, 600);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUsers;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExportExcel;
    }
}
