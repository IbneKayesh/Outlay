namespace Outlay
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblRemining = new System.Windows.Forms.Label();
            this.cmbTrnType = new System.Windows.Forms.ComboBox();
            this.cmbTrnCat = new System.Windows.Forms.ComboBox();
            this.toPick = new System.Windows.Forms.DateTimePicker();
            this.btnReportCat = new System.Windows.Forms.Button();
            this.lblReport = new System.Windows.Forms.Label();
            this.frmPick = new System.Windows.Forms.DateTimePicker();
            this.btnReportType = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(20, 19);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(125, 20);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Total Cost: BDT ";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(20, 45);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(145, 20);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "Total Income: BDT ";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(20, 71);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(120, 20);
            this.lbl3.TabIndex = 2;
            this.lbl3.Text = "Remining: BDT ";
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncome.Location = new System.Drawing.Point(169, 46);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(146, 22);
            this.lblIncome.TabIndex = 3;
            this.lblIncome.Text = "Income Taka Paisa";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(169, 18);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(126, 22);
            this.lblCost.TabIndex = 4;
            this.lblCost.Text = "Cost Taka Paisa";
            // 
            // lblRemining
            // 
            this.lblRemining.AutoSize = true;
            this.lblRemining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemining.Location = new System.Drawing.Point(169, 73);
            this.lblRemining.Name = "lblRemining";
            this.lblRemining.Size = new System.Drawing.Size(123, 22);
            this.lblRemining.TabIndex = 5;
            this.lblRemining.Text = "Remining Value";
            // 
            // cmbTrnType
            // 
            this.cmbTrnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrnType.FormattingEnabled = true;
            this.cmbTrnType.Items.AddRange(new object[] {
            "Cost",
            "Income"});
            this.cmbTrnType.Location = new System.Drawing.Point(24, 116);
            this.cmbTrnType.Name = "cmbTrnType";
            this.cmbTrnType.Size = new System.Drawing.Size(121, 21);
            this.cmbTrnType.TabIndex = 6;
            this.cmbTrnType.SelectedIndexChanged += new System.EventHandler(this.cmbTrnType_SelectedIndexChanged);
            // 
            // cmbTrnCat
            // 
            this.cmbTrnCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrnCat.FormattingEnabled = true;
            this.cmbTrnCat.Location = new System.Drawing.Point(164, 116);
            this.cmbTrnCat.Name = "cmbTrnCat";
            this.cmbTrnCat.Size = new System.Drawing.Size(121, 21);
            this.cmbTrnCat.TabIndex = 7;
            // 
            // toPick
            // 
            this.toPick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toPick.Location = new System.Drawing.Point(164, 144);
            this.toPick.Name = "toPick";
            this.toPick.Size = new System.Drawing.Size(121, 20);
            this.toPick.TabIndex = 9;
            // 
            // btnReportCat
            // 
            this.btnReportCat.Location = new System.Drawing.Point(291, 115);
            this.btnReportCat.Name = "btnReportCat";
            this.btnReportCat.Size = new System.Drawing.Size(109, 23);
            this.btnReportCat.TabIndex = 10;
            this.btnReportCat.Text = "Report  by Category";
            this.btnReportCat.UseVisualStyleBackColor = true;
            this.btnReportCat.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Location = new System.Drawing.Point(21, 177);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(160, 20);
            this.lblReport.TabIndex = 11;
            this.lblReport.Text = "Cost/Income-Amount";
            // 
            // frmPick
            // 
            this.frmPick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.frmPick.Location = new System.Drawing.Point(24, 144);
            this.frmPick.Name = "frmPick";
            this.frmPick.Size = new System.Drawing.Size(121, 20);
            this.frmPick.TabIndex = 12;
            // 
            // btnReportType
            // 
            this.btnReportType.Location = new System.Drawing.Point(291, 141);
            this.btnReportType.Name = "btnReportType";
            this.btnReportType.Size = new System.Drawing.Size(109, 23);
            this.btnReportType.TabIndex = 13;
            this.btnReportType.Text = "Report by Type";
            this.btnReportType.UseVisualStyleBackColor = true;
            this.btnReportType.Click += new System.EventHandler(this.btnReportType_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(291, 171);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(109, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 207);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReportType);
            this.Controls.Add(this.frmPick);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.btnReportCat);
            this.Controls.Add(this.toPick);
            this.Controls.Add(this.cmbTrnCat);
            this.Controls.Add(this.cmbTrnType);
            this.Controls.Add(this.lblRemining);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblRemining;
        private System.Windows.Forms.ComboBox cmbTrnType;
        private System.Windows.Forms.ComboBox cmbTrnCat;
        private System.Windows.Forms.DateTimePicker toPick;
        private System.Windows.Forms.Button btnReportCat;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.DateTimePicker frmPick;
        private System.Windows.Forms.Button btnReportType;
        private System.Windows.Forms.Button btnExport;
    }
}