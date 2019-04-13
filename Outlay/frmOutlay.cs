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
    public partial class frmOutlay : Form
    {
        SQLiteConnection DBConStrng = new SQLiteConnection(@"Data Source =.\OutlayDB.db;Version=3;");
        SQLiteCommand SqlCommand;
        SQLiteDataAdapter SqlDataAdapter;
        DataTable DT;
        int WHOid, WHOcat;
        public frmOutlay()
        {
            InitializeComponent();
        }
        private void cmbTrn_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Reset1();
            if (cmbTrn.Text == "Cost")
            {
                _LoadCategoryCost();
                _LoadDataGridOutlayCO();
            }
            else
            {
                _LoadCategoryIncome();
                _LoadDataGridOutlayIN();
            }
        }
        private void _LoadCategoryCost()
        {
            if (cmbCat.Items != null)
            {
                cmbCat.DataSource = null;
                cmbCat.Items.Clear();
            }
            try
            {
                string SQL = @"select ID,CostTypeName from CostType WHERE IsActive='1' Order by ID;";
                SqlDataAdapter = new SQLiteDataAdapter(SQL, DBConStrng);
                DT = new DataTable();
                SqlDataAdapter.Fill(DT);
                //DataRow dr = DT.NewRow();
                //dr["CostTypeName"] = "-Select Cost-";
                //DT.Rows.InsertAt(dr, 0);
                cmbCat.ValueMember = "ID";// DT.Columns[0].Table.Rows[0].ToString();
                cmbCat.DisplayMember = "CostTypeName";
                cmbCat.DataSource = DT;
                DBConStrng.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong...." + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void _LoadCategoryIncome()
        {
            if (cmbCat.Items != null)
            {
                cmbCat.DataSource = null;
                cmbCat.Items.Clear();
            }
            try
            {
                string SQL = @"select * from IncomeType WHERE IsActive='1' Order by ID;";
                SqlDataAdapter = new SQLiteDataAdapter(SQL, DBConStrng);
                DT = new DataTable();
                SqlDataAdapter.Fill(DT);
                // DataRow dr = DT.NewRow();
                // dr["IncomeTypeName"] = "-Select Income-";
                // DT.Rows.InsertAt(dr, 0);
                cmbCat.ValueMember = "ID";
                cmbCat.DisplayMember = "IncomeTypeName";
                cmbCat.DataSource = DT;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong...." + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void frmOutlay_Load(object sender, EventArgs e)
        {
            if (DBConnection.LoginUserID == null)
            {
                MessageBox.Show("Please Login first", "No Credential", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.BeginInvoke(new MethodInvoker(Close));
                return;
            }
        }
        private void _LoadDataGridOutlayCO()
        {
            try
            {
                string SQL = @"SELECT CostType.CostTypeName Category,Trnsaction.Amount,Trnsaction.Detail,Trnsaction.whenDate Date,UserInfo.UserName User, Trnsaction.ID SL,Trnsaction.Category Cat
FROM Trnsaction, UserInfo, CostType
WHERE Trnsaction.IsActive='1'
AND Trnsaction.Type='CO' 
AND CostType.ID = Trnsaction.Category
AND UserInfo.ID = Trnsaction.UserId
AND Trnsaction.UserID = '" + DBConnection.LoginUserID + "'";
                DataTable SqlDataTable = new DataTable();
                //Database Open
                DBConStrng.Open();
                SqlDataAdapter = new SQLiteDataAdapter(SQL, DBConStrng); //Execute  Query
                SqlDataAdapter.Fill(SqlDataTable); //store data into data table
                dgvCommon.DataSource = SqlDataTable; //load to data grid from data table
                //Database Close
                DBConStrng.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Something went wrong " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                }
            }
        }
        private void _LoadDataGridOutlayIN()
        {
            try
            {
                string SQL = @"SELECT IncomeType.IncomeTypeName Category,Trnsaction.Amount,Trnsaction.Detail,Trnsaction.whenDate Date,UserInfo.UserName User, Trnsaction.ID SL,Trnsaction.Category Cat
FROM Trnsaction, UserInfo, IncomeType
WHERE Trnsaction.IsActive='1'
AND Trnsaction.Type='IN' 
AND IncomeType.ID = Trnsaction.Category
AND UserInfo.ID = Trnsaction.UserId
AND Trnsaction.UserID = '" + DBConnection.LoginUserID + "'";
                DataTable SqlDataTable = new DataTable();
                //Database Open
                DBConStrng.Open();
                SqlDataAdapter = new SQLiteDataAdapter(SQL, DBConStrng); //Execute  Query
                SqlDataAdapter.Fill(SqlDataTable); //store data into data table
                dgvCommon.DataSource = SqlDataTable; //load to data grid from data table
                //Database Close
                DBConStrng.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Something went wrong " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            if (cmbTrn.ValueMember == null || cmbCat.ValueMember == null || txtAmount.Text == "")
            {
                MessageBox.Show("Some fields are null", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Use Nested If Statements
                if (btnSave.Text == "Save")
                {
                    if (cmbTrn.Text == "Cost")
                    {
                        //Call Cost Insert SQL                        
                        _CostInsert();
                    }
                    else if (cmbTrn.Text == "Income")
                    {
                        //Call Income Insert SQL
                        _IncomeInsert();
                    }
                    else
                    {
                        //Show Warning
                        MessageBox.Show("Select a Transaction Type");
                    }
                }
                else
                {
                    if (cmbTrn.Text == "Cost")
                    {
                        //Call Cost update SQL
                        _CommonUpdate();
                        _LoadDataGridOutlayCO(); //Reload Grid Data
                    }
                    else if (cmbTrn.Text == "Income")
                    {
                        //Call Income update SQL
                        _CommonUpdate();
                        _LoadDataGridOutlayIN(); //Reload Grid Data
                    }
                    else
                    {
                        //Show Warning
                        MessageBox.Show("Select a Transaction Type");
                    }
                }

            }

        }
        private void _CostInsert()
        {
            try
            {
                var date = dtpWhen.Value.ToString();
                string DT = Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss").ToString();
                //SQL command
                string SQL = @"INSERT INTO TRNSACTION (Type,Category,Amount,Detail,WhenDate,IsActive,UserId,CDT) values (@Type,@Category,@Amount,@Detail,@WhenDate,@IsActive,@UserId,@CDT)";
                //Assgin Command to Database
                SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                //Assign Parameters
                SQLiteParameter Type = SqlCommand.Parameters.Add("@Type", DbType.String);
                SQLiteParameter Categry = SqlCommand.Parameters.Add("@Category", DbType.String);
                SQLiteParameter Amount = SqlCommand.Parameters.Add("@Amount", DbType.Double);
                SQLiteParameter Detail = SqlCommand.Parameters.Add("@Detail", DbType.String);
                SQLiteParameter WhenDate = SqlCommand.Parameters.Add("@WhenDate", DbType.DateTime);
                SQLiteParameter IsActive = SqlCommand.Parameters.Add("@IsActive", DbType.Int32);
                SQLiteParameter UserId = SqlCommand.Parameters.Add("@UserId", DbType.Int32);
                SQLiteParameter CDT = SqlCommand.Parameters.Add("@CDT", DbType.DateTime);
                //Get parameter values from UI
                Type.Value = "CO";
                Categry.Value = cmbCat.SelectedValue;
                Amount.Value = txtAmount.Text;
                Detail.Value = txtDetail.Text;
                WhenDate.Value = dtpWhen.Value;
                IsActive.Value = "1";
                UserId.Value = DBConnection.LoginUserID;
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
                MessageBox.Show("Cost Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Reset1(); //Clear UI
                _LoadDataGridOutlayCO(); //Reload Grid Data
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong..." + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                }
            }
        }
        private void _IncomeInsert()
        {
            try
            {
                var date = dtpWhen.Value.ToString();
                string DT = Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss").ToString();
                //SQL command
                string SQL = @"INSERT INTO TRNSACTION (Type,Category,Amount,Detail,WhenDate,IsActive,UserId,CDT) values (@Type,@Category,@Amount,@Detail,@WhenDate,@IsActive,@UserId,@CDT)";
                //Assgin Command to Database
                SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                //Assign Parameters
                SQLiteParameter Type = SqlCommand.Parameters.Add("@Type", DbType.String);
                SQLiteParameter Categry = SqlCommand.Parameters.Add("@Category", DbType.String);
                SQLiteParameter Amount = SqlCommand.Parameters.Add("@Amount", DbType.Double);
                SQLiteParameter Detail = SqlCommand.Parameters.Add("@Detail", DbType.String);
                SQLiteParameter WhenDate = SqlCommand.Parameters.Add("@WhenDate", DbType.DateTime);
                SQLiteParameter IsActive = SqlCommand.Parameters.Add("@IsActive", DbType.Int32);
                SQLiteParameter UserId = SqlCommand.Parameters.Add("@UserId", DbType.Int32);
                SQLiteParameter CDT = SqlCommand.Parameters.Add("@CDT", DbType.DateTime);
                //Get parameter values from UI
                Type.Value = "IN";
                Categry.Value = cmbCat.SelectedValue;
                Amount.Value = txtAmount.Text;
                Detail.Value = txtDetail.Text;
                WhenDate.Value = dtpWhen.Value;
                IsActive.Value = "1";
                UserId.Value = DBConnection.LoginUserID;
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
                MessageBox.Show("Income Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Reset1(); //Clear UI
                _LoadDataGridOutlayIN(); //Reload Grid Data
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong..." + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                }
            }
        }
        private void _CommonUpdate()
        {
            var date = dtpWhen.Value.ToString();
            string DT = Convert.ToDateTime(date).ToString("yyyy-MM-dd HH:mm:ss").ToString();
            string SQL = @"UPDATE Trnsaction Set Amount='" + txtAmount.Text + "', Category='" + WHOcat + "', Detail='" + txtDetail.Text + "', WhenDate='" + DT + "', UDT='" + System.DateTime.Now + "' where ID='" + WHOid + "'";
            try
            {
                SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                DBConStrng.Open();
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.ExecuteNonQuery();
                DBConStrng.Close();
                MessageBox.Show("Your data updated", "Edit Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Reset1(); //Clear UI              
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong..." + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                }
            }
        }
        private void dgvCommon_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbCat.Text = dgvCommon.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAmount.Text = dgvCommon.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDetail.Text = dgvCommon.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpWhen.Text = dgvCommon.Rows[e.RowIndex].Cells[3].Value.ToString();
            WHOid = Convert.ToInt32(dgvCommon.Rows[e.RowIndex].Cells[5].Value);
            WHOcat = Convert.ToInt32(dgvCommon.Rows[e.RowIndex].Cells[6].Value);
            btnSave.Text = "Update";

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please select a data", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbTrn.Text == "Cost")
            {
                //Call Delete
                _DeleteTransaction();
                _LoadDataGridOutlayCO(); //Reload Grid Data
            }
            else if (cmbTrn.Text == "Income")
            {
                //Call delete
                _DeleteTransaction();
                _LoadDataGridOutlayIN(); //Reload Grid Data
            }
            else
            {
                //Show Warning
                MessageBox.Show("Select a Transaction Type");
            }
        }
        private void _DeleteTransaction()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure delete this data?", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string SQL = @"UPDATE Trnsaction Set IsActive='0' where ID='" + WHOid + "'";
                try
                {
                    SqlCommand = new SQLiteCommand(SQL, DBConStrng);
                    DBConStrng.Open();
                    SqlCommand.CommandType = CommandType.Text;
                    SqlCommand.ExecuteNonQuery();
                    DBConStrng.Close();
                    MessageBox.Show("Your data deleted", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Reset1(); //Clear UI              
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Somthing went wrong..... " + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    if (DBConStrng.State == ConnectionState.Open)
                    {
                        DBConStrng.Close();  //Check Connection if opened, Close Database Connection
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;

            }
        }
        private void _Reset1()
        {
            btnSave.Text = "Save";
            txtAmount.Text = "";
            txtDetail.Text = "";
        }
    }
}
