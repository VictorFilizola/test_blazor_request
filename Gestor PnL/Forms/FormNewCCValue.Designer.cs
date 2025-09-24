namespace Gestor_PnL.Forms
{
    partial class FormNewCCValue
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
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            simpleButtonCreateVersion = new DevExpress.XtraEditors.SimpleButton();
            textEditInvestmenteValue = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)textEditInvestmenteValue.Properties).BeginInit();
            SuspendLayout();
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(18, 10);
            labelControl1.Margin = new System.Windows.Forms.Padding(1);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(267, 38);
            labelControl1.TabIndex = 38;
            labelControl1.Text = "Informe o valor de despesa a ser\r\n  alocado para este Centro de Custo";
            // 
            // simpleButtonCreateVersion
            // 
            simpleButtonCreateVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            simpleButtonCreateVersion.Location = new System.Drawing.Point(87, 84);
            simpleButtonCreateVersion.Name = "simpleButtonCreateVersion";
            simpleButtonCreateVersion.Size = new System.Drawing.Size(131, 29);
            simpleButtonCreateVersion.TabIndex = 37;
            simpleButtonCreateVersion.Text = "Alocar valor";
            simpleButtonCreateVersion.Click += simpleButtonCreateVersion_Click;
            // 
            // textEditInvestmenteValue
            // 
            textEditInvestmenteValue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textEditInvestmenteValue.Location = new System.Drawing.Point(18, 52);
            textEditInvestmenteValue.Name = "textEditInvestmenteValue";
            textEditInvestmenteValue.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textEditInvestmenteValue.Properties.Appearance.Options.UseFont = true;
            textEditInvestmenteValue.Size = new System.Drawing.Size(273, 24);
            textEditInvestmenteValue.TabIndex = 36;
            // 
            // FormNewCCValue
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(297, 125);
            Controls.Add(labelControl1);
            Controls.Add(simpleButtonCreateVersion);
            Controls.Add(textEditInvestmenteValue);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNewCCValue";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormClosed += FormNewVersion_FormClosed;
            ((System.ComponentModel.ISupportInitialize)textEditInvestmenteValue.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCreateVersion;
        private DevExpress.XtraEditors.TextEdit textEditInvestmenteValue;
    }
}