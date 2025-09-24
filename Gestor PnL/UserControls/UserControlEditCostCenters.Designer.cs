namespace Gestor_PnL.UserControls
{
    partial class UserControlEditCostCenters
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
            gridControlCostCenters = new DevExpress.XtraGrid.GridControl();
            gridViewCostCenters = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEditAttributedInvestment.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlCostCenters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCostCenters).BeginInit();
            SuspendLayout();
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(simpleButton1);
            groupControl1.Controls.Add(labelControlInvestiment);
            groupControl1.Controls.Add(labelControl2);
            groupControl1.Controls.Add(labelControl1);
            groupControl1.Controls.Add(textEditAttributedInvestment);
            groupControl1.Controls.Add(gridControlCostCenters);
            groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupControl1.Location = new System.Drawing.Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1054, 600);
            groupControl1.TabIndex = 0;
            groupControl1.Text = "Editar Centros de Custo";
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
            labelControl2.Location = new System.Drawing.Point(224, 42);
            labelControl2.Margin = new System.Windows.Forms.Padding(1);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(177, 19);
            labelControl2.TabIndex = 50;
            labelControl2.Text = "Despesas desta gerencia:";
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
            labelControl1.Text = "Despesa distribuída:";
            // 
            // textEditAttributedInvestment
            // 
            textEditAttributedInvestment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            textEditAttributedInvestment.Location = new System.Drawing.Point(792, 40);
            textEditAttributedInvestment.Name = "textEditAttributedInvestment";
            textEditAttributedInvestment.Size = new System.Drawing.Size(100, 28);
            textEditAttributedInvestment.TabIndex = 48;
            // 
            // gridControlCostCenters
            // 
            gridControlCostCenters.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControlCostCenters.Location = new System.Drawing.Point(2, 29);
            gridControlCostCenters.MainView = gridViewCostCenters;
            gridControlCostCenters.Name = "gridControlCostCenters";
            gridControlCostCenters.Size = new System.Drawing.Size(1050, 569);
            gridControlCostCenters.TabIndex = 0;
            gridControlCostCenters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewCostCenters });
            // 
            // gridViewCostCenters
            // 
            gridViewCostCenters.GridControl = gridControlCostCenters;
            gridViewCostCenters.Name = "gridViewCostCenters";
            gridViewCostCenters.CellValueChanged += gridViewCostCenters_CellValueChanged;
            gridViewCostCenters.DoubleClick += gridViewCostCenters_DoubleClick;
            // 
            // UserControlEditCostCenters
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupControl1);
            Name = "UserControlEditCostCenters";
            Size = new System.Drawing.Size(1054, 600);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEditAttributedInvestment.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlCostCenters).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCostCenters).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlCostCenters;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCostCenters;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControlInvestiment;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditAttributedInvestment;
    }
}
