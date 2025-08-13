using BloodInNeed.Data.Models;
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;

namespace BloodInNeed.UI.Services
{
    public class LogInService
    {
        private readonly LogInDBCtx _logInDBCtx;

        public LogInService(LogInDBCtx logInDBCtx) // Inject dependency via constructor
        {
            _logInDBCtx = logInDBCtx ?? throw new ArgumentNullException(nameof(logInDBCtx));
        }


        public DbMessageUserName CheckLogIn(string Email, string Password)
        {
            var data = _logInDBCtx.CheckLogIn(Email, Password);

            return data;
        }



        public DbMessage CheckUser(string Email)
        {
            var data = _logInDBCtx.CheckUser(Email);

            return data;
        }
         public DbMessage VerifyResetCode(string Email, int Code)
        {
            var data = _logInDBCtx.VerifyResetCode(Email, Code);

            return data;
        }
        public DbMessage ResetPassword(string Email, string Password)
        {
            var data = _logInDBCtx.ResetPassword(Email, Password);

            return data;
        }

        public DbMessageWithValue CheckGoogleLogIn(string email, string firstName, string lastName, string username, string ip)
        {
            var data = _logInDBCtx.CheckGoogleLogIn(email, firstName, lastName, username, ip);

            return data;
        }


    }
}
