namespace Gestor_PnL.Forms
{
    partial class FormStep1VP
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
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            textEditInvestmentAllocated = new DevExpress.XtraEditors.TextEdit();
            gridControlManageVPs = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            simpleButtonNewVersion = new DevExpress.XtraEditors.SimpleButton();
            labelControlInvestiment = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            gridControlVPsHistoric = new DevExpress.XtraGrid.GridControl();
            gridViewVPsHistoric = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEditInvestmentAllocated.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlManageVPs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlVPsHistoric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewVPsHistoric).BeginInit();
            SuspendLayout();
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(gridControlVPsHistoric);
            groupControl2.Controls.Add(labelControl3);
            groupControl2.Controls.Add(textEditInvestmentAllocated);
            groupControl2.Controls.Add(gridControlManageVPs);
            groupControl2.Controls.Add(simpleButtonNewVersion);
            groupControl2.Controls.Add(labelControlInvestiment);
            groupControl2.Controls.Add(labelControl1);
            groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl2.Location = new System.Drawing.Point(0, 0);
            groupControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new System.Drawing.Size(1170, 1056);
            groupControl2.TabIndex = 42;
            // 
            // labelControl3
            // 
            labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(496, 48);
            labelControl3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(214, 29);
            labelControl3.TabIndex = 42;
            labelControl3.Text = "Despesa distribuída:";
            // 
            // textEditInvestmentAllocated
            // 
            textEditInvestmentAllocated.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            textEditInvestmentAllocated.Location = new System.Drawing.Point(783, 51);
            textEditInvestmentAllocated.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            textEditInvestmentAllocated.Name = "textEditInvestmentAllocated";
            textEditInvestmentAllocated.Size = new System.Drawing.Size(150, 40);
            textEditInvestmentAllocated.TabIndex = 41;
            // 
            // gridControlManageVPs
            // 
            gridControlManageVPs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gridControlManageVPs.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            gridControlManageVPs.Location = new System.Drawing.Point(8, 89);
            gridControlManageVPs.MainView = gridView1;
            gridControlManageVPs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            gridControlManageVPs.Name = "gridControlManageVPs";
            gridControlManageVPs.Size = new System.Drawing.Size(1155, 568);
            gridControlManageVPs.TabIndex = 38;
            gridControlManageVPs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.DetailHeight = 512;
            gridView1.GridControl = gridControlManageVPs;
            gridView1.Name = "gridView1";
            gridView1.CellValueChanged += gridView1_CellValueChanged;
            // 
            // simpleButtonNewVersion
            // 
            simpleButtonNewVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            simpleButtonNewVersion.Location = new System.Drawing.Point(942, 38);
            simpleButtonNewVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            simpleButtonNewVersion.Name = "simpleButtonNewVersion";
            simpleButtonNewVersion.Size = new System.Drawing.Size(220, 42);
            simpleButtonNewVersion.TabIndex = 37;
            simpleButtonNewVersion.Text = "Finalizar Etapa";
            simpleButtonNewVersion.Click += simpleButtonNewVersion_Click;
            // 
            // labelControlInvestiment
            // 
            labelControlInvestiment.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControlInvestiment.Appearance.Options.UseFont = true;
            labelControlInvestiment.Location = new System.Drawing.Point(339, 48);
            labelControlInvestiment.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            labelControlInvestiment.Name = "labelControlInvestiment";
            labelControlInvestiment.Size = new System.Drawing.Size(140, 29);
            labelControlInvestiment.TabIndex = 40;
            labelControlInvestiment.Text = "{investment}";
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(32, 48);
            labelControl1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(243, 29);
            labelControl1.TabIndex = 39;
            labelControl1.Text = "Despesa desta versão:";
            // 
            // gridControlVPsHistoric
            // 
            gridControlVPsHistoric.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gridControlVPsHistoric.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            gridControlVPsHistoric.Location = new System.Drawing.Point(8, 665);
            gridControlVPsHistoric.MainView = gridViewVPsHistoric;
            gridControlVPsHistoric.Margin = new System.Windows.Forms.Padding(4);
            gridControlVPsHistoric.Name = "gridControlVPsHistoric";
            gridControlVPsHistoric.Size = new System.Drawing.Size(1153, 385);
            gridControlVPsHistoric.TabIndex = 43;
            gridControlVPsHistoric.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewVPsHistoric });
            // 
            // gridViewVPsHistoric
            // 
            gridViewVPsHistoric.DetailHeight = 512;
            gridViewVPsHistoric.GridControl = gridControlVPsHistoric;
            gridViewVPsHistoric.Name = "gridViewVPsHistoric";
            // 
            // FormStep1VP
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1170, 1056);
            Controls.Add(groupControl2);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "FormStep1VP";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormStepOneVP";
            FormClosed += FormStepOneVP_FormClosed;
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEditInvestmentAllocated.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlManageVPs).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlVPsHistoric).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewVPsHistoric).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControlManageVPs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNewVersion;
        private DevExpress.XtraEditors.LabelControl labelControlInvestiment;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditInvestmentAllocated;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gridControlVPsHistoric;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVPsHistoric;
    }
}