using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using Dapper;
using System.Data;

namespace BloodInNeed.UI.DBCtx
{
    public class SignupDBCtx: SqlDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;


        public SignupDBCtx(IConfiguration config, ISqlDataAccess dataAccess) : base(config)
        {
            _dataAccess = dataAccess;
        }

        public DbMessage SignUpUser(UserRegistrarionModel model)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@FirstName", model.FirstName);
                p.Add("@MiddleName", model.MiddleName);
                p.Add("@LastName", model.LastName);
                p.Add("@Email", model.Email);
                p.Add("@Password", model.Password);
                p.Add("@IsDonorSeeker", model.IsDonorSeeker);

                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[User.Save]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }

    }
}
