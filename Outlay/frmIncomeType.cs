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
    public partial class frmIncomeType : Form
    {
        SQLiteConnection DBConStrng = new SQLiteConnection(@"Data Source =.\OutlayDB.db;Version=3;");
        SQLiteCommand SqlCommand;
        SQLiteDataAdapter SqlDataAdapter;
        int WHOid;
        public frmIncomeType()
        {
            InitializeComponent();
        }

        private void frmIncomeType_Load(object sender, EventArgs e)
        {
            if (DBConnection.LoginUserID == null)
            {
                MessageBox.Show("Please Login first", "No Credential", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
            _LoadGridView();
        }
        private void _LoadGridView()
        {
            try
            {
                string SQL = @"Select ID Sl,IncomeTypeName Category,IsActive Status  from IncomeType;";
                DataTable SqlDataTable = new DataTable();
                //Database Open
                DBConStrng.Open();
                SqlDataAdapter = new SQLiteDataAdapter(SQL, DBConStrng); //Execute  Query
                SqlDataAdapter.Fill(SqlDataTable); //store data into data table
                dgvIncomeTypes.DataSource = SqlDataTable; //load to data grid from data table
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                _SaveData();
            }
            else
            {
                _EditData();
            }
        }
        private void _SaveData()
        {

            if (txtIncomeType.Text == "" || chkActiveIncome.Checked == false)
            {
                MessageBox.Show("Some fields are empty", "Empty");
            }
            else
            {
                try
                {
                    //SQL command
                    string SQL = @"INSERT INTO INCOMETYPE (IncomeTypeName,IsActive,CDT) values (@IncomeTypeName,@IsActive,@CDT)";
                    //Assgin Command to Database
                    SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                    //Assign Parameters
                    SQLiteParameter CostTypeName = SqlCommand.Parameters.Add("@IncomeTypeName", DbType.String);
                    SQLiteParameter IsActive = SqlCommand.Parameters.Add("@IsActive", DbType.Int32);
                    SQLiteParameter CDT = SqlCommand.Parameters.Add("@CDT", DbType.DateTime);
                    //Get parameter values from UI
                    CostTypeName.Value = txtIncomeType.Text;
                    IsActive.Value = chkActiveIncome.CheckState;
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
                    MessageBox.Show("Income Type Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ClearText(); //Clear UI
                    _LoadGridView(); //Reload Grid Data
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Somthing went wrong, " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void _EditData()
        {
            int Status;
            if (chkActiveIncome.Checked) //Convert Checkbox Status to integer value
            {
                Status = 1;
            }
            else
            {
                Status = 0;
            }
            string SQL = @"update IncomeType Set IncomeTypeName='" + txtIncomeType.Text + "',IsActive='" + Status + "', UDT='" + System.DateTime.Now + "' where ID='" + WHOid + "'";
            try
            {
                SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                DBConStrng.Open();
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.ExecuteNonQuery();
                DBConStrng.Close();
                MessageBox.Show("Data updated", "Income Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ClearText(); //Clear UI
                _LoadGridView(); //Reload Grid Data
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong, " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtIncomeType.Text = "";
            chkActiveIncome.Checked = false;
            btnSave.Text = "Save";
        }
        private void dgvCostTypes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            WHOid = Convert.ToInt32(dgvIncomeTypes.Rows[e.RowIndex].Cells[0].Value);
            txtIncomeType.Text = dgvIncomeTypes.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (dgvIncomeTypes.Rows[e.RowIndex].Cells[2].Value.ToString() == "1")
            {
                chkActiveIncome.Checked = true;
            }
            else
            {
                chkActiveIncome.Checked = false;
            }
            btnSave.Text = "Update";
        }
    }
}
