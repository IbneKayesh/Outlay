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
    public partial class frmChangePass : Form
    {
        SQLiteConnection DBConStrng = new SQLiteConnection(@"Data Source =.\OutlayDB.db;Version=3;");
        SQLiteCommand SqlCommand;
        string pwd, act;
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void btnChngPass_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "" || txtOldPass.Text == "" || txtPass1.Text == "" || txtPass2.Text == "")
            {
                MessageBox.Show("Some fileds are empty", "Null field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtPass1.Text.Length < 6)
            {
                MessageBox.Show("Please check" + Environment.NewLine + Environment.NewLine + " New Password minimum length 6 char", "Length", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtPass1.Text != txtPass2.Text)
            {
                MessageBox.Show("Retype password not matched!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass2.Text = "";
            }
            else
            {
                _CheckUserActivity();
            }
            
        }
        private void _CheckUserActivity()
        {
            try
            {
                string SQL = @"select LoginPassword,IsActive from UserInfo Where LoginID='" + txtUserId.Text + "'";
                SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                DBConStrng.Open();
                SQLiteDataReader read = SqlCommand.ExecuteReader();
                while (read.Read())
                {
                    pwd = (read["LoginPassword"].ToString());
                    act = (read["IsActive"].ToString());
                }
                read.Close();
                DBConStrng.Close();
                if (txtOldPass.Text != pwd)
                {
                    MessageBox.Show("Old Password Not Matched", "Credential Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtOldPass.Text = "";

                }
                else if (act == "0")
                {
                    MessageBox.Show("User is Disabled", "Credential Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    _ClearText();
                }
                else
                {
                    _UpdatePassword();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Invalid User Id," + Ex.Message, "Error");
            }
            finally
            {
                DBConStrng.Close();
            }
        }
        private void frmChangePass_Load(object sender, EventArgs e)
        {
            if (DBConnection.LoginUserID == null)
            {
                MessageBox.Show("Please Login first", "No Credential", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.BeginInvoke(new MethodInvoker(Close));
            }
            logusr.Text ="Logged as: "+ DBConnection.LoginUserName;
        }
        private void _UpdatePassword()
        {
            string SQL = @"update UserInfo Set LoginPassword='" + txtPass2.Text + "' where LoginID='" + txtUserId.Text + "'";
            try
            {
                SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                DBConStrng.Open();
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.ExecuteNonQuery();
                DBConStrng.Close();
                MessageBox.Show("Password Changed", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ClearText();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong, " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DBConStrng.Close();
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                }
            }
        }
        private void _ClearText()
        {
            txtUserId.Text = "";
            txtOldPass.Text = "";
            txtPass1.Text = "";
            txtPass2.Text = "";
        }
    }
}
