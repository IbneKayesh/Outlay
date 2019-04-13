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
    public partial class frmDashboard : Form
    {

        SQLiteConnection DBConStrng = new SQLiteConnection(@"Data Source =.\OutlayDB.db;Version=3;");
        int R;
        DataSet DS;
        DataTable DT;
        SQLiteDataAdapter SqlDataAdapter;
        DataTable ExpDataTable = new DataTable { TableName = "Cost" };
        string DefaultFileName;
        public frmDashboard()
        {
            InitializeComponent();
        }
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            if (DBConnection.LoginUserID == null)
            {
                MessageBox.Show("Please Login first", "No Credential", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.BeginInvoke(new MethodInvoker(Close));
            }
            else
            {
                _LoadSummary();
            }
        }
        public void _LoadSummary()
        {
            try
            {
                SqlDataAdapter = new SQLiteDataAdapter("SELECT SUM(Amount) FROM Trnsaction WHERE IsActive='1' AND Type='CO' AND UserId='" + DBConnection.LoginUserID + "'", DBConStrng);
                DS = new DataSet();
                SqlDataAdapter.Fill(DS, "Cost");
                lblCost.Text = DS.Tables[0].Rows[R][0].ToString();

                SqlDataAdapter = new SQLiteDataAdapter("SELECT SUM(Amount) FROM Trnsaction WHERE IsActive='1' AND Type='IN' AND UserId='" + DBConnection.LoginUserID + "'", DBConStrng);
                DataSet DS1 = new DataSet();
                SqlDataAdapter.Fill(DS1, "Income");
                lblIncome.Text = DS1.Tables[0].Rows[R][0].ToString();

                double Bit1 = Convert.ToDouble(DS1.Tables[0].Rows[R][0].ToString());
                double Bit2 = Convert.ToDouble(DS.Tables[0].Rows[R][0].ToString());

                lblRemining.Text = (Bit1 - Bit2).ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("No Data Found Or Somthing went wrong......" + Environment.NewLine + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();
                }
            }
        }
        private void cmbTrnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrnType.Text == "Cost")
            {
                _LoadCategoryCost();
            }
            else
            {
                _LoadCategoryIncome();
            }
        }
        private void _LoadCategoryCost()
        {
            if (cmbTrnCat.Items != null)
            {
                cmbTrnCat.DataSource = null;
                cmbTrnCat.Items.Clear();
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
                cmbTrnCat.ValueMember = "ID";// DT.Columns[0].Table.Rows[0].ToString();
                cmbTrnCat.DisplayMember = "CostTypeName";
                cmbTrnCat.DataSource = DT;
                DBConStrng.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong " + Ex.Message);
            }
        }
        private void _LoadCategoryIncome()
        {
            if (cmbTrnCat.Items != null)
            {
                cmbTrnCat.DataSource = null;
                cmbTrnCat.Items.Clear();
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
                cmbTrnCat.ValueMember = "ID";
                cmbTrnCat.DisplayMember = "IncomeTypeName";
                cmbTrnCat.DataSource = DT;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Somthing went wrong " + Ex.Message);
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (cmbTrnType.Text == "Cost")
            {
                _LoadCostAmount();
            }
            else if (cmbTrnType.Text == "Income")
            {
                _LoadIncomeAmount();
            }
            else
            {
                lblReport.Text = "Please Select Type and Category";
            }
        }
        private void _LoadCostAmount()
        {
            try
            {
                if (DS != null)
                {
                    DS.Clear(); //clear data set if exists
                }
                var FD = frmPick.Value.ToString("yyyy-MM-dd");
                var TD = toPick.Value.ToString("yyyy-MM-dd");
                var CatVal = cmbTrnCat.SelectedValue;
                SqlDataAdapter = new SQLiteDataAdapter("SELECT SUM(Amount) FROM Trnsaction WHERE IsActive='1' AND Type='CO' AND UserId='" + DBConnection.LoginUserID + "' AND date(WhenDate) between '" + FD + "' AND '" + TD + "' AND Category='" + CatVal + "'", DBConStrng);
                DS = new DataSet();
                SqlDataAdapter.Fill(DS, "Cost");
                lblReport.Text = cmbTrnCat.Text + " Sum: " + DS.Tables[0].Rows[R][0].ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("No Data Found Or Somthing went wrong......" + Environment.NewLine + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();
                }
            }
        }
        private void _LoadIncomeAmount()
        {
            try
            {
                if (DS != null)
                {
                    DS.Clear(); //clear data set if exists
                }
                var FD = frmPick.Value.ToString("yyyy-MM-dd");
                var TD = toPick.Value.ToString("yyyy-MM-dd");
                var CatVal = cmbTrnCat.SelectedValue;
                SqlDataAdapter = new SQLiteDataAdapter("SELECT SUM(Amount) FROM Trnsaction WHERE IsActive='1' AND Type='IN' AND UserId='" + DBConnection.LoginUserID + "' AND date(WhenDate) between '" + FD + "' AND '" + TD + "' AND Category='" + CatVal + "'", DBConStrng);
                DS = new DataSet();
                SqlDataAdapter.Fill(DS, "Income");
                lblReport.Text = cmbTrnCat.Text + " Sum: " + DS.Tables[0].Rows[R][0].ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("No Data Found Or Somthing went wrong......" + Environment.NewLine + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();
                }
            }
        }
        private void btnReportType_Click(object sender, EventArgs e)
        {
            if (cmbTrnType.Text == "Cost")
            {
                _LoadCostByType();
            }
            else if (cmbTrnType.Text == "Income")
            {
                _LoadIncomeByType();
            }
            else
            {
                lblReport.Text = "Please Select Type and Date";
            }
        }
        private void _LoadCostByType()
        {
            try
            {
                if (DS != null)
                {
                    DS.Clear(); //clear data set if exists
                }
                var FD = frmPick.Value.ToString("yyyy-MM-dd");
                var TD = toPick.Value.ToString("yyyy-MM-dd");
                SqlDataAdapter = new SQLiteDataAdapter("SELECT SUM(Amount) FROM Trnsaction WHERE IsActive='1' AND Type='CO' AND UserId='" + DBConnection.LoginUserID + "' AND date(WhenDate) between '" + FD + "' AND '" + TD + "'", DBConStrng);
                DS = new DataSet();
                SqlDataAdapter.Fill(DS, "Cost");
                lblReport.Text = "Total Cost: " + DS.Tables[0].Rows[R][0].ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("No Data Found Or Somthing went wrong......" + Environment.NewLine + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();
                }
            }
        }
        private void _LoadIncomeByType()
        {
            try
            {
                if (DS != null)
                {
                    DS.Clear(); //clear data set if exists
                }
                var FD = frmPick.Value.ToString("yyyy-MM-dd");
                var TD = toPick.Value.ToString("yyyy-MM-dd");
                SqlDataAdapter = new SQLiteDataAdapter("SELECT SUM(Amount) FROM Trnsaction WHERE IsActive='1' AND Type='IN' AND UserId='" + DBConnection.LoginUserID + "' AND date(WhenDate) between '" + FD + "' AND '" + TD + "'", DBConStrng);
                DS = new DataSet();
                SqlDataAdapter.Fill(DS, "Income");
                lblReport.Text = "Total Income: " + DS.Tables[0].Rows[R][0].ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("No Data Found Or Somthing went wrong......" + Environment.NewLine + Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (DBConStrng.State == ConnectionState.Open)
                {
                    DBConStrng.Close();
                }
            }
        }
        private void _ReadyForExportCO()
        {
            try
            {
                var FD = frmPick.Value.ToString("yyyy-MM-dd");
                var TD = toPick.Value.ToString("yyyy-MM-dd");
                string SQL = @"SELECT CostType.CostTypeName Category,Trnsaction.Amount,Trnsaction.Detail,Trnsaction.whenDate Date,UserInfo.UserName User
FROM Trnsaction, UserInfo, CostType
WHERE Trnsaction.IsActive='1'
AND Trnsaction.Type='CO' 
AND CostType.ID = Trnsaction.Category
AND UserInfo.ID = Trnsaction.UserId
AND date(WhenDate) between '" + FD + "' AND '" + TD + 
@"' AND Trnsaction.UserID = '" + DBConnection.LoginUserID + "'";
              //  DataTable ExpDataTable = new DataTable { TableName = "Cost" };
                //Database Open
                DBConStrng.Open();
                SqlDataAdapter = new SQLiteDataAdapter(SQL, DBConStrng); //Execute  Query
                ExpDataTable.Clear(); //Clear Old Data
                SqlDataAdapter.Fill(ExpDataTable); //store data into data table
               // ExpDataTable.WriteXml("D:\\report.xls");
                //Database Close
                DBConStrng.Close();
                DefaultFileName = "MyCost";
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
        private void _ReadyForExportIN()
        {
            try
            {
                var FD = frmPick.Value.ToString("yyyy-MM-dd");
                var TD = toPick.Value.ToString("yyyy-MM-dd");
                string SQL = @"SELECT CostType.CostTypeName Category,Trnsaction.Amount,Trnsaction.Detail,Trnsaction.whenDate Date,UserInfo.UserName User
FROM Trnsaction, UserInfo, CostType
WHERE Trnsaction.IsActive='1'
AND Trnsaction.Type='IN' 
AND CostType.ID = Trnsaction.Category
AND UserInfo.ID = Trnsaction.UserId
AND date(WhenDate) between '" + FD + "' AND '" + TD +
@"' AND Trnsaction.UserID = '" + DBConnection.LoginUserID + "'";
                //  DataTable ExpDataTable = new DataTable { TableName = "Cost" };
                //Database Open
                DBConStrng.Open();
                SqlDataAdapter = new SQLiteDataAdapter(SQL, DBConStrng); //Execute  Query
                ExpDataTable.Clear(); //Clear Old Data
                SqlDataAdapter.Fill(ExpDataTable); //store data into data table
                                                   // ExpDataTable.WriteXml("D:\\report.xls");
                                                   //Database Close
                DBConStrng.Close();
                DefaultFileName = "MyIncome";
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
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbTrnType.Text == "Cost")
            {
                _ReadyForExportCO();
                _UserFileSave();
            }
            else if (cmbTrnType.Text == "Income")
            {
                _ReadyForExportIN();
                _UserFileSave();
            }
            else
            {
                lblReport.Text = "Please Select Type and Date";
            }
        }
        private void _UserFileSave()
        {
            SaveFileDialog savefile = new SaveFileDialog();// set a default file name
            savefile.FileName = DefaultFileName +".xls";
            // set filters - this can be done in properties as well
            savefile.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                ExpDataTable.WriteXml(savefile.FileName);
                //using (StreamWriter sw = new StreamWriter(savefile.FileName))
                //   sw.WriteLine("Hello World!");
            }
        }
    }
}

