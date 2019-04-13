namespace Outlay
{
    partial class frmCostType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCostType));
            this.label1 = new System.Windows.Forms.Label();
            this.chkActiveCost = new System.Windows.Forms.CheckBox();
            this.txtCostType = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvCostTypes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cost Type";
            // 
            // chkActiveCost
            // 
            this.chkActiveCost.AutoSize = true;
            this.chkActiveCost.Location = new System.Drawing.Point(70, 48);
            this.chkActiveCost.Name = "chkActiveCost";
            this.chkActiveCost.Size = new System.Drawing.Size(56, 17);
            this.chkActiveCost.TabIndex = 1;
            this.chkActiveCost.Text = "Active";
            this.chkActiveCost.UseVisualStyleBackColor = true;
            // 
            // txtCostType
            // 
            this.txtCostType.Location = new System.Drawing.Point(70, 13);
            this.txtCostType.Name = "txtCostType";
            this.txtCostType.Size = new System.Drawing.Size(100, 20);
            this.txtCostType.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(70, 71);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvCostTypes
            // 
            this.dgvCostTypes.AllowUserToAddRows = false;
            this.dgvCostTypes.AllowUserToDeleteRows = false;
            this.dgvCostTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostTypes.Location = new System.Drawing.Point(191, 12);
            this.dgvCostTypes.Name = "dgvCostTypes";
            this.dgvCostTypes.Size = new System.Drawing.Size(245, 180);
            this.dgvCostTypes.TabIndex = 5;
            this.dgvCostTypes.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCostTypes_RowHeaderMouseClick);
            // 
            // frmCostType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 201);
            this.Controls.Add(this.dgvCostTypes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCostType);
            this.Controls.Add(this.chkActiveCost);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCostType";
            this.Text = "frmCostType";
            this.Load += new System.EventHandler(this.frmCostType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActiveCost;
        private System.Windows.Forms.TextBox txtCostType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvCostTypes;
    }
}