namespace Gestor_PnL.UserControls
{
    partial class UserControlManageVersions
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
            simpleButtonNewVersion = new DevExpress.XtraEditors.SimpleButton();
            gridControlVersions = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlVersions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(simpleButtonNewVersion);
            groupControl1.Controls.Add(gridControlVersions);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 0);
            groupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1581, 877);
            groupControl1.TabIndex = 2;
            groupControl1.Text = "Target B Braun";
            // 
            // simpleButtonNewVersion
            // 
            simpleButtonNewVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            simpleButtonNewVersion.Location = new System.Drawing.Point(1280, 38);
            simpleButtonNewVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            simpleButtonNewVersion.Name = "simpleButtonNewVersion";
            simpleButtonNewVersion.Size = new System.Drawing.Size(220, 42);
            simpleButtonNewVersion.TabIndex = 32;
            simpleButtonNewVersion.Text = "Criar nova Versão";
            simpleButtonNewVersion.Click += simpleButtonNewVersion_Click;
            // 
            // gridControlVersions
            // 
            gridControlVersions.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlVersions.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            gridControlVersions.Location = new System.Drawing.Point(2, 43);
            gridControlVersions.MainView = gridView1;
            gridControlVersions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            gridControlVersions.Name = "gridControlVersions";
            gridControlVersions.Size = new System.Drawing.Size(1577, 832);
            gridControlVersions.TabIndex = 0;
            gridControlVersions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.DetailHeight = 512;
            gridView1.GridControl = gridControlVersions;
            gridView1.Name = "gridView1";
            gridView1.DoubleClick += gridView1_DoubleClick;
            // 
            // UserControlManageVersions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "UserControlManageVersions";
            Size = new System.Drawing.Size(1581, 877);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlVersions).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlVersions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNewVersion;
    }
}
