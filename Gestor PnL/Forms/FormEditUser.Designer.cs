namespace Gestor_PnL.Forms
{
    partial class FormEditUser
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
            textEditContact = new DevExpress.XtraEditors.TextEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            textEditContactType = new DevExpress.XtraEditors.TextEdit();
            labelControlNewContract = new DevExpress.XtraEditors.LabelControl();
            simpleButtonAddNewItem = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)textEditContact.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEditContactType.Properties).BeginInit();
            SuspendLayout();
            // 
            // textEditContact
            // 
            textEditContact.Location = new System.Drawing.Point(99, 45);
            textEditContact.Name = "textEditContact";
            textEditContact.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textEditContact.Properties.Appearance.Options.UseFont = true;
            textEditContact.Size = new System.Drawing.Size(231, 32);
            textEditContact.TabIndex = 7;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new System.Drawing.Point(11, 53);
            labelControl4.Margin = new System.Windows.Forms.Padding(2);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(76, 16);
            labelControl4.TabIndex = 5;
            labelControl4.Text = "Responsável:";
            // 
            // textEditContactType
            // 
            textEditContactType.Location = new System.Drawing.Point(99, 7);
            textEditContactType.Name = "textEditContactType";
            textEditContactType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textEditContactType.Properties.Appearance.Options.UseFont = true;
            textEditContactType.Size = new System.Drawing.Size(231, 32);
            textEditContactType.TabIndex = 8;
            // 
            // labelControlNewContract
            // 
            labelControlNewContract.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControlNewContract.Appearance.Options.UseFont = true;
            labelControlNewContract.Location = new System.Drawing.Point(11, 11);
            labelControlNewContract.Margin = new System.Windows.Forms.Padding(2);
            labelControlNewContract.Name = "labelControlNewContract";
            labelControlNewContract.Size = new System.Drawing.Size(54, 16);
            labelControlNewContract.TabIndex = 6;
            labelControlNewContract.Text = "Diretoria:";
            // 
            // simpleButtonAddNewItem
            // 
            simpleButtonAddNewItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            simpleButtonAddNewItem.Appearance.Options.UseFont = true;
            simpleButtonAddNewItem.Location = new System.Drawing.Point(99, 91);
            simpleButtonAddNewItem.Margin = new System.Windows.Forms.Padding(2);
            simpleButtonAddNewItem.Name = "simpleButtonAddNewItem";
            simpleButtonAddNewItem.Size = new System.Drawing.Size(142, 34);
            simpleButtonAddNewItem.TabIndex = 4;
            simpleButtonAddNewItem.Text = "Atualizar dados";
            // 
            // EditUser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(342, 136);
            Controls.Add(textEditContact);
            Controls.Add(labelControl4);
            Controls.Add(textEditContactType);
            Controls.Add(labelControlNewContract);
            Controls.Add(simpleButtonAddNewItem);
            Name = "EditUser";
            FormClosed += EditUser_FormClosed;
            ((System.ComponentModel.ISupportInitialize)textEditContact.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEditContactType.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditContact;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditContactType;
        private DevExpress.XtraEditors.LabelControl labelControlNewContract;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddNewItem;
    }
}