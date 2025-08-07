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

        public DbMessageUserName CheckLogIn(string Email, string Password)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@Email", Email);
                p.Add("@Password", Password);
                p.Add("@UserName", dbType : DbType.String ,direction: ParameterDirection.Output, size: 100);
                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult2("[dbo].[LogIn.Check]", p);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }


        public DbMessage CheckUser(string Email)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@Email", Email);
                
                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[User.Check]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }



        public DbMessage VerifyResetCode(string Email, int Code)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@Email", Email);
                p.Add("@Code", Code);

                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[Reset.Password.Check]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }



        public DbMessage ResetPassword(string Email, string Password)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@Email", Email);
                p.Add("@Password", Password);

                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[Password.Reset.Update]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }




        public DbMessage CheckGoogleLogIn(string email, string firstName, string lastName, string username, string ip)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@EmailAddress", email);
                p.Add("@FirstName", firstName);
                p.Add("@LastName", lastName);
                p.Add("@Username", username);
                p.Add("@CreatedIP", ip);
                p.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[AddOrGetGoogleUser]", p);

                //return p.Get<int>("@UserId");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }





    }
}
