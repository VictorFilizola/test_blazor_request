namespace Gestor_PnL.Forms
{
    partial class FormStep2EditManagers
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
            labelControlInvestiment = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            textEdit2 = new DevExpress.XtraEditors.TextEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            gridControlManagers = new DevExpress.XtraGrid.GridControl();
            gridViewManagers = new DevExpress.XtraGrid.Views.Grid.GridView();
            simpleButtonNewVersion = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)groupControl2).BeginInit();
            groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlManagers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewManagers).BeginInit();
            SuspendLayout();
            // 
            // groupControl2
            // 
            groupControl2.Controls.Add(simpleButton1);
            groupControl2.Controls.Add(labelControlInvestiment);
            groupControl2.Controls.Add(labelControl2);
            groupControl2.Controls.Add(labelControl1);
            groupControl2.Controls.Add(textEdit2);
            groupControl2.Controls.Add(labelControl3);
            groupControl2.Controls.Add(textEdit1);
            groupControl2.Controls.Add(gridControlManagers);
            groupControl2.Controls.Add(simpleButtonNewVersion);
            groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl2.Location = new System.Drawing.Point(0, 0);
            groupControl2.Name = "groupControl2";
            groupControl2.Size = new System.Drawing.Size(826, 462);
            groupControl2.TabIndex = 44;
            // 
            // simpleButton1
            // 
            simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            simpleButton1.Location = new System.Drawing.Point(677, 30);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(147, 29);
            simpleButton1.TabIndex = 47;
            simpleButton1.Text = "Finalizar Etapa";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // labelControlInvestiment
            // 
            labelControlInvestiment.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControlInvestiment.Appearance.Options.UseFont = true;
            labelControlInvestiment.Location = new System.Drawing.Point(223, 33);
            labelControlInvestiment.Margin = new System.Windows.Forms.Padding(1);
            labelControlInvestiment.Name = "labelControlInvestiment";
            labelControlInvestiment.Size = new System.Drawing.Size(93, 19);
            labelControlInvestiment.TabIndex = 46;
            labelControlInvestiment.Text = "{investment}";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(7, 33);
            labelControl2.Margin = new System.Windows.Forms.Padding(1);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(204, 19);
            labelControl2.TabIndex = 45;
            labelControl2.Text = "Despesa desta diretoria:";
            // 
            // labelControl1
            // 
            labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(389, 33);
            labelControl1.Margin = new System.Windows.Forms.Padding(1);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(178, 19);
            labelControl1.TabIndex = 44;
            labelControl1.Text = "Despesa distribuída:";
            // 
            // textEdit2
            // 
            textEdit2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            textEdit2.Location = new System.Drawing.Point(571, 32);
            textEdit2.Name = "textEdit2";
            textEdit2.Size = new System.Drawing.Size(100, 28);
            textEdit2.TabIndex = 43;
            // 
            // labelControl3
            // 
            labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(1522, 33);
            labelControl3.Margin = new System.Windows.Forms.Padding(1);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(178, 19);
            labelControl3.TabIndex = 42;
            labelControl3.Text = "Despesa distribuída:";
            // 
            // textEdit1
            // 
            textEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            textEdit1.Location = new System.Drawing.Point(1713, 35);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new System.Drawing.Size(100, 28);
            textEdit1.TabIndex = 41;
            // 
            // gridControlManagers
            // 
            gridControlManagers.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlManagers.Location = new System.Drawing.Point(2, 29);
            gridControlManagers.MainView = gridViewManagers;
            gridControlManagers.Name = "gridControlManagers";
            gridControlManagers.Size = new System.Drawing.Size(822, 431);
            gridControlManagers.TabIndex = 38;
            gridControlManagers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewManagers });
            // 
            // gridViewManagers
            // 
            gridViewManagers.GridControl = gridControlManagers;
            gridViewManagers.Name = "gridViewManagers";
            gridViewManagers.CellValueChanged += gridView1_CellValueChanged;
            // 
            // simpleButtonNewVersion
            // 
            simpleButtonNewVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            simpleButtonNewVersion.Location = new System.Drawing.Point(1819, 26);
            simpleButtonNewVersion.Name = "simpleButtonNewVersion";
            simpleButtonNewVersion.Size = new System.Drawing.Size(147, 29);
            simpleButtonNewVersion.TabIndex = 37;
            simpleButtonNewVersion.Text = "Finalizar Etapa";
            // 
            // FormStep2EditManagers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(826, 462);
            Controls.Add(groupControl2);
            Name = "FormStep2EditManagers";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)groupControl2).EndInit();
            groupControl2.ResumeLayout(false);
            groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlManagers).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewManagers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.GridControl gridControlManagers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewManagers;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNewVersion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.LabelControl labelControlInvestiment;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}