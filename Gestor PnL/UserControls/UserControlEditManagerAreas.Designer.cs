namespace Gestor_PnL.UserControls
{
    partial class UserControlEditManagerAreas
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
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            labelControlInvestiment = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            textEditAttributedInvestment = new DevExpress.XtraEditors.TextEdit();
            gridControlManagerAreas = new DevExpress.XtraGrid.GridControl();
            gridViewManagerAreas = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEditAttributedInvestment.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlManagerAreas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewManagerAreas).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(simpleButton1);
            groupControl1.Controls.Add(labelControlInvestiment);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Controls.Add(textEditAttributedInvestment);
            groupControl1.Controls.Add(gridControlManagerAreas);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1054, 600);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Editar Gerências";
            // 
            // simpleButton1
            // 
            simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            simpleButton1.Location = new System.Drawing.Point(898, 38);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(147, 29);
            simpleButton1.TabIndex = 52;
            simpleButton1.Text = "Finalizar Etapa";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // labelControlInvestiment
            // 
            labelControlInvestiment.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControlInvestiment.Appearance.Options.UseFont = true;
            labelControlInvestiment.Location = new System.Drawing.Point(450, 41);
            labelControlInvestiment.Margin = new System.Windows.Forms.Padding(1);
            labelControlInvestiment.Name = "labelControlInvestiment";
            labelControlInvestiment.Size = new System.Drawing.Size(93, 19);
            labelControlInvestiment.TabIndex = 51;
            labelControlInvestiment.Text = "{investment}";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(228, 41);
            labelControl2.Margin = new System.Windows.Forms.Padding(1);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(196, 19);
            labelControl2.TabIndex = 50;
            labelControl2.Text = "Alocado para esta diretoria:";
            // 
            // labelControl1
            // 
            labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(610, 41);
            labelControl1.Margin = new System.Windows.Forms.Padding(1);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(143, 19);
            labelControl1.TabIndex = 49;
            labelControl1.Text = "Despesa distribuida:";
            // 
            // textEditAttributedInvestment
            // 
            textEditAttributedInvestment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            textEditAttributedInvestment.Location = new System.Drawing.Point(792, 40);
            textEditAttributedInvestment.Name = "textEditAttributedInvestment";
            textEditAttributedInvestment.Size = new System.Drawing.Size(100, 28);
            textEditAttributedInvestment.TabIndex = 48;
            // 
            // gridControlManagerAreas
            // 
            gridControlManagerAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlManagerAreas.Location = new System.Drawing.Point(2, 29);
            gridControlManagerAreas.MainView = gridViewManagerAreas;
            gridControlManagerAreas.Name = "gridControlManagerAreas";
            gridControlManagerAreas.Size = new System.Drawing.Size(1050, 569);
            gridControlManagerAreas.TabIndex = 0;
            gridControlManagerAreas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewManagerAreas });
            // 
            // gridViewManagerAreas
            // 
            gridViewManagerAreas.GridControl = gridControlManagerAreas;
            gridViewManagerAreas.Name = "gridViewManagerAreas";
            gridViewManagerAreas.CellValueChanged += gridViewCostCenters_CellValueChanged;
            gridViewManagerAreas.DoubleClick += gridViewCostCenters_DoubleClick;
            // 
            // UserControlEditManagerAreas
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Name = "UserControlEditManagerAreas";
            Size = new System.Drawing.Size(1054, 600);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEditAttributedInvestment.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlManagerAreas).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewManagerAreas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlManagerAreas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewManagerAreas;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControlInvestiment;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditAttributedInvestment;
    }
}
