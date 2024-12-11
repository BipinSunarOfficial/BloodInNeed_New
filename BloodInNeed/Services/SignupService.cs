using BloodInNeed.Data.Models;
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;

namespace BloodInNeed.UI.Services
{
    public class SignupService
    {
        private readonly SignupDBCtx _SignupDBCtx;

        public SignupService(SignupDBCtx signupDBCtx)
        {
            _SignupDBCtx = signupDBCtx ?? throw new ArgumentNullException(nameof(signupDBCtx));
        }

        public DbMessage SignUpUser(UserRegistrarionModel model)
        {
            var data = _SignupDBCtx.SignUpUser(model);
            return data;
        }



    }
}
