using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Outlay
{
    public partial class frmLogin : Form
    {
        SQLiteConnection DBConStrng = new SQLiteConnection(@"Data Source =.\OutlayDB.db;Version=3;");
        SQLiteCommand SqlCommand;
        string pwd,act,uID, uName;
       // DBConnection DBA;

        public frmLogin()
        {
            InitializeComponent();
            //  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Mobile number or Password is null", "Credential Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                _CheckUserCredential();
            }            
        }
        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Close();
           frmMain.SignUnpUser();
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.Focus();
        }
        private void _CheckUserCredential()
        {
            try
            {
                string SQL = @"select ID,UserName, LoginPassword,IsActive from UserInfo Where LoginID='" + txtUserId.Text + "'";
                SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                DBConStrng.Open();
                SQLiteDataReader read = SqlCommand.ExecuteReader();
                while (read.Read())
                {
                    uID = (read["ID"].ToString());
                    uName = (read["UserName"].ToString());
                    pwd = (read["LoginPassword"].ToString());
                    act = (read["IsActive"].ToString());
                }
                read.Close();
                _CheckUserValidation();
            }
            finally
            {
                DBConStrng.Close();
            }
        }
        private void _CheckUserValidation()
        {
            if (act == "0")
            {
                MessageBox.Show("User is Disabled", "Denied",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtPassword.Text = "";
            }
            else if (txtPassword.Text == pwd)
            {
                DBConnection.CheckuserLogin = "Y";
                DBConnection.LoginUserID = uID;
                DBConnection.LoginUserName = uName; 
                frmMain.Current.LoginLogoutText = "Logout";
                MessageBox.Show("Welcome " + uName, "Login OK", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                frmMain.DashOpen();
            }
            else
            {
                MessageBox.Show("Wrong Mobile number or Password", "Login Credential",MessageBoxButtons.OK,MessageBoxIcon.Question);
                txtPassword.Text = "";
                txtUserId.Text = "";
            }
        }
       
    }
}