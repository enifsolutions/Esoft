using BankApplication.Controllers;
using BankApplication.Models.User;
using Banking.Data;
using Banking.Models;
using Banking.Models.CommonModels.ResponseModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Banking.Business.AppUserBo
{
    public class AppUserBo
    {
        private readonly DatabaseUtility _databaseUtility;   
        public IConfiguration _configuration { get; }  

        string conString = string.Empty;
        
        public AppUserBo(IConfiguration configuration, DatabaseUtility databaseUtilit)
        {
            this._configuration = configuration;
            this._databaseUtility = databaseUtilit;
            this.conString = configuration.GetConnectionString("ConString");
        }

        #region CreateAppUser

        public CommonResponseModel CreateAppUser(UserViewModel request)
        {
            CommonResponseModel res = new CommonResponseModel();

            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[7];

                param[0] = new SqlParameter ("UserId", request.userid);
                param[1]= new SqlParameter("Username", request.username);
                param[2] = new SqlParameter("Password", request.password);
                param[3] = new SqlParameter("Status", "A");
                param[4] = new SqlParameter("Action", "ADD");
                param[5] = new SqlParameter("User", request.createduser);
                param[6] = new SqlParameter("VOut", SqlDbType.Int);
                param[6].Direction = ParameterDirection.Output;

                _databaseUtility.executeInsertQuary("CreateAppUser", commandType, param, conString);

                string response = param[6].Value.ToString();

                res.code = "1";
                res.massage = "User adding successfull";

                // we can use this method also. but it occurs redundency 

                /*using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("ConString")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("CreateAppUser", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("UserId", request.userid);
                    sqlCmd.Parameters.AddWithValue("Username", request.username);
                    sqlCmd.Parameters.AddWithValue("Password", request.password);
                    sqlCmd.Parameters.AddWithValue("Status", "A");
                    sqlCmd.Parameters.AddWithValue("Action", "ADD");
                    sqlCmd.Parameters.AddWithValue("User", request.createduser);
                    sqlCmd.Parameters.Add("VOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlCmd.ExecuteNonQuery();

                }*/

            }
            catch (Exception ex)
            {

                throw;
            }


            return res;
        }

        #endregion
       
    }
}
