using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Dapper;
using System.Data;

namespace BloodInNeed.UI.DBCtx
{
    public class SendCodeDBCtx: SqlDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        private readonly ILogger<SignupDBCtx> _logger;
        private readonly IConfiguration _config;
        private readonly EmailService _emailService;

        public SendCodeDBCtx(IConfiguration config, ISqlDataAccess dataAccess, ILogger<SignupDBCtx> logger, EmailService emailService) : base(config)
        {
            _dataAccess = dataAccess;
            _logger = logger;
            _config = config;
            _emailService = emailService;
        }




        public async Task<DbMessageWithValue> SendCode(SendCode model)
        {

            _logger.LogInformation("Sending Code for " + model.Type + " to the email " + model.Email);
            try
            {

                // Generate 6-digit code
                var code = new Random().Next(100000, 999999).ToString();

                var Subject = "";
                var emailBody = "";

                if (model.Type == "Resend")
                {

                    Subject = "Verify Your Email to continue on " + _config["Application:Name"];
                    emailBody = $"<p>Your " + _config["Application:Name"] + " verification code is: <strong>" + code + "</strong></p>";

                }

                if (model.Type == "Forget Password")
                {

                    Subject = "Reset Password Code ";
                    emailBody = $"<p>Your " + _config["Application:Name"] + " password reset code is: <strong>" + code + "</strong></p>";
                }


                bool emailResponse = await _emailService.SendEmailAsync(model.Email, Subject, emailBody);

                if (emailResponse)
                {

                    DynamicParameters p = new DynamicParameters();


                    p.Add("@Type", model.Type);
                    p.Add("@Code", code);
                    p.Add("@Email", model.Email);

                    p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                    p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);
                    p.Add("@Value", direction: ParameterDirection.Output, size: 50);

                    var result = ExecuteNonQueryResult("[dbo].[Code.Send.Save]", p);

                    return (new DbMessageWithValue
                    {
                        MsgType = result.MsgType,
                        Msg = result.Msg,
                        Value = model.Email
                    });

                }
                else
                {
                    return new DbMessageWithValue
                    {
                        MsgType = "Error",
                        Msg = "Failed to send email. Please try again.",
                        Value = ""
                    };
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }





    }
}
