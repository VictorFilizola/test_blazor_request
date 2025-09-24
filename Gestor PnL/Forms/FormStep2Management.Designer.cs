namespace Gestor_PnL.Forms
{
    partial class FormStep2Management
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupControl2 = new DevExpress.XtraEditors.GroupControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            gridControlManageVPs = new DevExpress.XtraGrid.GridControl();
            gridViewVPs = new DevExpress.XtraGrid.Views.Grid.GridView();
            simpleButtonNewVersion = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlManageVPs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewVPs).BeginInit();
            SuspendLayout();
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(simpleButton1);
            groupControl2.Controls.Add(labelControl3);
            groupControl2.Controls.Add(textEdit1);
            groupControl2.Controls.Add(gridControlManageVPs);
            groupControl2.Controls.Add(simpleButtonNewVersion);
            groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl2.Location = new System.Drawing.Point(0, 0);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new System.Drawing.Size(765, 501);
            groupControl2.TabIndex = 43;
            groupControl2.Text = "Valor de despesa nas diretorias";
            // 
            // simpleButton1
            // 
            simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            simpleButton1.Location = new System.Drawing.Point(583, 26);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(147, 29);
            simpleButton1.TabIndex = 48;
            simpleButton1.Text = "Finalizar Etapa";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // labelControl3
            // 
            labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(896, 33);
            labelControl3.Margin = new System.Windows.Forms.Padding(1);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(178, 19);
            labelControl3.TabIndex = 42;
            labelControl3.Text = "Despesa distribuída:";
            // 
            // textEdit1
            // 
            textEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            textEdit1.Location = new System.Drawing.Point(1087, 35);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new System.Drawing.Size(100, 28);
            textEdit1.TabIndex = 41;
            // 
            // gridControlManageVPs
            // 
            gridControlManageVPs.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlManageVPs.Location = new System.Drawing.Point(2, 29);
            gridControlManageVPs.MainView = gridViewVPs;
            gridControlManageVPs.Name = "gridControlManageVPs";
            gridControlManageVPs.Size = new System.Drawing.Size(761, 470);
            gridControlManageVPs.TabIndex = 38;
            gridControlManageVPs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewVPs });
            gridControlManageVPs.Click += gridControlManageVPs_Click;
            // 
            // gridViewVPs
            // 
            gridViewVPs.GridControl = gridControlManageVPs;
            gridViewVPs.Name = "gridViewVPs";
            // 
            // simpleButtonNewVersion
            // 
            simpleButtonNewVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            simpleButtonNewVersion.Location = new System.Drawing.Point(1193, 26);
            simpleButtonNewVersion.Name = "simpleButtonNewVersion";
            simpleButtonNewVersion.Size = new System.Drawing.Size(147, 29);
            simpleButtonNewVersion.TabIndex = 37;
            simpleButtonNewVersion.Text = "Finalizar Etapa";
            // 
            // FormStep2Management
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(765, 501);
            Controls.Add(groupControl2);
            Name = "FormStep2Management";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormClosed += FormStep2Management_FormClosed;
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlManageVPs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewVPs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.GridControl gridControlManageVPs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVPs;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNewVersion;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}