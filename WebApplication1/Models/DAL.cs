using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DAL
    {
        private SqlConnection con;
        private SqlCommand com;
        string status = "false";
        string conStr = string.Empty;
        string errorMessage = string.Empty;
        string errorLogStatus = Constants.errorLogStatusPath;




        public DataTable GetEmployeeData(string Username)
        {
            DataTable table = new DataTable { TableName = "MyTableName" };
            try
            {
                conStr = System.Configuration.ConfigurationManager.ConnectionStrings[Constants.connectionString].ToString();
                con = new SqlConnection(conStr);
                com = new SqlCommand(Constants.getEmpDataSTP, con);
                com.Parameters.AddWithValue("@Username", Username);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(com);
                objSqlDataAdapter.Fill(table);
                con.Close();
            }
          
            catch (Exception Ex)
            {
                File.AppendAllText(errorLogStatus, Ex.Message + DateTime.Now + Environment.NewLine);
            }
            return table;
        }
    }
}