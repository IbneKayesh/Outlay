namespace Outlay
{
    partial class frmChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePass));
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChngPass = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.logusr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserId
            // 
            this.txtUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserId.Location = new System.Drawing.Point(118, 40);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(100, 20);
            this.txtUserId.TabIndex = 0;
            // 
            // txtPass1
            // 
            this.txtPass1.Location = new System.Drawing.Point(118, 99);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(100, 20);
            this.txtPass1.TabIndex = 2;
            // 
            // txtPass2
            // 
            this.txtPass2.Location = new System.Drawing.Point(118, 129);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(100, 20);
            this.txtPass2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Retype Password";
            // 
            // btnChngPass
            // 
            this.btnChngPass.Location = new System.Drawing.Point(118, 165);
            this.btnChngPass.Name = "btnChngPass";
            this.btnChngPass.Size = new System.Drawing.Size(99, 23);
            this.btnChngPass.TabIndex = 4;
            this.btnChngPass.Text = "Change";
            this.btnChngPass.UseVisualStyleBackColor = true;
            this.btnChngPass.Click += new System.EventHandler(this.btnChngPass_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Old Password";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(118, 70);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(100, 20);
            this.txtOldPass.TabIndex = 1;
            // 
            // logusr
            // 
            this.logusr.AutoSize = true;
            this.logusr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logusr.Location = new System.Drawing.Point(15, 13);
            this.logusr.Name = "logusr";
            this.logusr.Size = new System.Drawing.Size(82, 15);
            this.logusr.TabIndex = 9;
            this.logusr.Text = "Logged as :";
            // 
            // frmChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 194);
            this.Controls.Add(this.logusr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.btnChngPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPass2);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.txtUserId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangePass";
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChngPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label logusr;
    }
}