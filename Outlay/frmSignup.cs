using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Outlay
{
    public partial class frmSignup : Form
    {
        // DBConnection DB;
        SQLiteConnection DBConStrng = new SQLiteConnection(@"Data Source =.\OutlayDB.db;Version=3;");
        SQLiteCommand SqlCommand;
        SQLiteDataAdapter SqlDataAdapter;
        int WHOuser;
        public frmSignup()
        {
            InitializeComponent();
            btnSignup.Enabled = false;
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {
            if (DBConnection.LoginUserID == null)
            {
                this.Size = new Size(283, 310);
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
            else
            {
                this.Size = new Size(823, 310);
            }
            //call another data load method
            _LoadGridView();
        }
        private void _LoadGridView()
        {
            try
            {
                string SQL = @"select ID Sl, UserName Name, Usermail Mail,UserMobile Mobile,UserAddress Address,IsActive Status from UserInfo;";
                DataTable SqlDataTable = new DataTable();
                //Database Open
                DBConStrng.Open();
                SqlDataAdapter = new SQLiteDataAdapter(SQL, DBConStrng); //Execute  Query
                SqlDataAdapter.Fill(SqlDataTable); //store data into data table
                dgvUsers.DataSource = SqlDataTable; //load to data grid from data table
                //Database Close
                DBConStrng.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Something went wrong " + Ex.Message, "Error");
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                }
            }
        }
        private void chkActiveUser_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSignup.Text == "Create")
            {
                if (chkActiveUser.Checked)
                {
                    btnSignup.Enabled = true;
                }
                else
                {
                    btnSignup.Enabled = false;
                }
            }
        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (btnSignup.Text == "Create")
            {
                _SignupUser();
            }
            else
            {
                _UpdateUser();
            }
        }
        private void _SignupUser()
        {
            { DBConStrng.Close(); }
            //User input data Validation
            if (txtLoginID.Text.Length < 11 || txtPassword1.Text.Length < 6)
            {
                MessageBox.Show("Please check" + Environment.NewLine + "Mobile number minimum lenght 11 char" + Environment.NewLine + "Password minimum length 6 char", "Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPassword1.Text != txtPassword2.Text)
            {
                MessageBox.Show("Retype password not matched!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("Name can't null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPassword1.Text == txtLoginID.Text)
            {
                MessageBox.Show("Mobile number and Password Can't Same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    //SQL command
                    string SQL = @"insert into UserInfo (LoginID,LoginPassword,UserName,UserMail,UserMobile,UserAddress,IsActive,CDT) values (@LoginID,@LoginPassword,@UserName,@UserMail,@UserMobile,@UserAddress,@IsActive,@CDT)";
                    //Assgin Command to Database
                    SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                    //Assign Parameters
                    SQLiteParameter LoginID = SqlCommand.Parameters.Add("@LoginID", DbType.String);
                    SQLiteParameter LoginPassword = SqlCommand.Parameters.Add("@LoginPassword", DbType.String);
                    SQLiteParameter UserName = SqlCommand.Parameters.Add("@UserName", DbType.String);
                    SQLiteParameter UserMail = SqlCommand.Parameters.Add("@UserMail", DbType.String);
                    SQLiteParameter UserMobile = SqlCommand.Parameters.Add("@UserMobile", DbType.String);
                    SQLiteParameter UserAddress = SqlCommand.Parameters.Add("@UserAddress", DbType.String);
                    SQLiteParameter IsActive = SqlCommand.Parameters.Add("@IsActive", DbType.Int32);
                    SQLiteParameter CDT = SqlCommand.Parameters.Add("@CDT", DbType.DateTime);
                    //Get parameter values from UI
                    LoginID.Value = txtLoginID.Text;
                    LoginPassword.Value = txtPassword1.Text;
                    UserName.Value = txtUserName.Text;
                    UserMail.Value = txtMail.Text;
                    UserMobile.Value = txtMobile.Text;
                    UserAddress.Value = txtAddress.Text;
                    IsActive.Value = chkActiveUser.CheckState;
                    CDT.Value = System.DateTime.Now;
                    //Define Command
                    SqlCommand.CommandType = CommandType.Text;
                    //Open Database Connection
                    DBConStrng.Open();
                    //Execute Command
                    SqlCommand.ExecuteNonQuery();
                    //Close Database Connection
                    DBConStrng.Close();
                    //Show Success Messages
                    MessageBox.Show("Hi! " + txtUserName.Text + Environment.NewLine + "Keep remember your Mobile number and Password", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ClearText(); //Clear Form
                    _LoadGridView(); //Reload Grid Data
                    this.Close();
                    frmMain.ForceLogin();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Somthing went wrong, " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    if (DBConStrng.State == ConnectionState.Open)
                    {
                        DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                    }
                }
            }
        }
        private void _UpdateUser()
        {

            int Status;
            if (chkActiveUser.Checked) //Convert Checkbox Status to integer value
            {
                Status = 1;
            }
            else
            {
                Status = 0;
            }
            string SQL = @"update UserInfo Set UserName='" + txtUserName.Text + "', UserMail='" + txtMail.Text + "',UserMobile='" + txtMobile.Text + "',UserAddress='" + txtAddress.Text + "',IsActive='" + Status + "', UDT='" + System.DateTime.Now + "' where ID='" + WHOuser + "'";
            try
            {
                SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                DBConStrng.Open();
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.ExecuteNonQuery();
                DBConStrng.Close();
                MessageBox.Show("Record updated", "User Info");
                _ClearText(); //Clear UI
                _LoadGridView(); //Reload Grid Data
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong, " + Ex.Message, "Error");
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                }
            }
        }
        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            WHOuser = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells[0].Value);
            txtUserName.Text = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMail.Text = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMobile.Text = dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (dgvUsers.Rows[e.RowIndex].Cells[5].Value.ToString() == "1")
            {
                chkActiveUser.Checked = true;

            }
            else
            {
                chkActiveUser.Checked = false;
            }
            btnSignup.Enabled = true;
            btnSignup.Text = "Update";
        }
        private void txtLoginID_Click(object sender, EventArgs e)
        {
            btnSignup.Enabled = false;
            btnSignup.Text = "Create";
            _ClearText();
        }
        private void _ClearText()
        {
            txtLoginID.Text = "";
            txtPassword1.Text = "";
            txtPassword2.Text = "";
            txtUserName.Text = "";
            txtMail.Text = "";
            txtMobile.Text = "";
            txtAddress.Text = "";
            chkActiveUser.Checked = false;
        }
    }
}
