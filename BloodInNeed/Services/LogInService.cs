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


        public DbMessage CheckLogIn(string UserName, string Password)
        {
            var data = _logInDBCtx.CheckLogIn(UserName, Password);

            return data;
        }


    }
}
