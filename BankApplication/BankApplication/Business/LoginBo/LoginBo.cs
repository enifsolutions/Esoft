using BankApplication.Models.Login;
using BankApplication.Models.User;
using Banking.Data;
using Banking.Models.CommonModels.ResponseModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Banking.Business.LoginBo
{
    public class LoginBo
    {
        private readonly DatabaseUtility _databaseUtility;
        public IConfiguration _configuration { get; }

        string conString = string.Empty;

        public LoginBo(IConfiguration configuration, DatabaseUtility databaseUtilit)
        {
            this._configuration = configuration;
            this._databaseUtility = databaseUtilit;
            this.conString = configuration.GetConnectionString("ConString");
        }

        #region CreateAppUser

        public CommonResponseModel CheckUserCredentials(LoginViewModel request)
        {
            CommonResponseModel res = new CommonResponseModel();

            try
            {
                CommandType commandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("Username", request.username);
                param[1] = new SqlParameter("Password", request.password);
                param[2] = new SqlParameter("IsValid", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;

                _databaseUtility.executeInsertQuary("CheckCredentials", commandType, param, conString);

                string response = param[2].Value.ToString();

                res.code = response;
                res.massage = null;              

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
