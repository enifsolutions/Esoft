using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Banking.Data
{
    public class DatabaseUtility 
    {
        private readonly IConfiguration _configuration;

        public DatabaseUtility(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        #region OpenConnectin
        private SqlConnection OpenConnection(String ConString)
        {

            SqlConnection Con = new SqlConnection(ConString);

            if (Con.State==ConnectionState.Closed||Con.State==ConnectionState.Broken)
            {
                Con.Open();
            }
            return Con;

        }
        #endregion

        #region DbOperations

        public DataTable executeSelectQuary(string quary, CommandType commandType, SqlParameter[] sqlParameters, string conString)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = OpenConnection(conString);
                cmd.CommandText = quary;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);
                da.SelectCommand = cmd;
                da.Fill(ds);
                dataTable = ds.Tables[0];
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                string error = "Error - Database connection - Quary " + quary + "\n" + "Exception : " + ex.Message.ToString();
                throw;
            }
            finally
            {
                try
                {
                    cmd.Connection.Close();
                }
                catch (Exception)
                {

                }
            }

            return dataTable;
        }

        public int executeInsertQuary(string quary, CommandType commandType, SqlParameter[] sqlParameters, string conString)
        {
            int x = 0;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd.Connection = OpenConnection(conString);
                cmd.CommandText = quary;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);
                da.InsertCommand = cmd;
                x = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }
            catch (Exception ex)
            {
                string error = "Error - Database connection - Quary " + quary + "\n" + "Exception : " + ex.Message.ToString();
                throw;
            }
            finally
            {
                try
                {
                    cmd.Connection.Close();
                }
                catch (Exception)
                {

                }
            }

            return x;
        }
        #endregion
    }
}
