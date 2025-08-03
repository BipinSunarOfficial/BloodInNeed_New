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

        public async Task<DbMessageWithValue> SignUpUser(UserRegistrarionModel model)
        {
            var data = await _SignupDBCtx.SignUpUser(model);
            return data;
        }


        public DbMessage VerifyEmail(string Email, int code)
        {
            var data =  _SignupDBCtx.VerifyEmail(Email, code);
            return data;
        }



    }
}
