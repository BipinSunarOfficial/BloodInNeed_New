using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using Dapper;
using System.Data;

namespace BloodInNeed.UI.DBCtx
{
    public class LogInDBCtx : SqlDataAccess
    {

        private readonly ISqlDataAccess _dataAccess;


        public LogInDBCtx(IConfiguration config, ISqlDataAccess dataAccess) : base(config)
        {
            _dataAccess = dataAccess;
        }

        public DbMessage CheckLogIn(string UserName, string Password)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@Username", UserName);
                p.Add("@Password", Password);
                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[LogIn.Check]", p);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }




    }
}
