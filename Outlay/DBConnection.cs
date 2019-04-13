using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outlay
{
    class DBConnection
    {
       
        string DBConnectionString = @"Data Source =.\OutlayDB.db;Version=3;";

        private static string _LoginValue = "N";
        private static string _LoginUserID;
        private static string _LoginUserName;
        public static string CheckuserLogin
        {
            get { return _LoginValue; }
            set { _LoginValue = value; }
        }        
        public static string LoginUserID
        {
            get { return _LoginUserID; }
            set { _LoginUserID = value; }
        }
        public static string LoginUserName
        {
            get { return _LoginUserName; }
            set { _LoginUserName = value; }
        }


        SQLiteConnection sqlCon;
        SQLiteCommand sqlCommand;       
      
       
        public bool DBActive()
        {
            try
            {
                sqlCon = new SQLiteConnection(DBConnectionString);
                sqlCon.Open();
                return true;
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                return false;

            }
            finally
            {
                sqlCon.Close();
            }
        }

        public void DBDeActive()
        {
            try
            {
                sqlCon.Close();
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }

        public void ExecuteQueries(string Query_)
        {
            sqlCommand = new SQLiteCommand(Query_, sqlCon);
            sqlCommand.ExecuteNonQuery();
        }
        //public OracleDataReader DataReader(string Query_)
        //{
        //    con = new OracleConnection(ChainCon);
        //    con.Open();

        //    OracleCommand cmd = new OracleCommand(Query_, con);
        //    OracleDataReader dr = cmd.ExecuteReader();
        //    return dr;
        //}

        public object ShowDataInGridView(string Query_)
        {
            SQLiteDataAdapter DA = new SQLiteDataAdapter(Query_, DBConnectionString);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            object DataMembers = DS.Tables[0];
            return DataMembers;
        }
        public object dgview(string Query_)
        {
            SQLiteDataAdapter DA = new SQLiteDataAdapter(Query_, DBConnectionString);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            //object DataMembers = dt.Tables[0];
            object DataMember = dt;
            return DataMember;
            
        }
    }
}
