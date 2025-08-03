using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;

namespace BloodInNeed.UI.DBCtx
{
    public class SignupDBCtx: SqlDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        private readonly EmailService _emailService;

        private readonly IConfiguration _config;

        private readonly ILogger<SignupDBCtx> _logger;

        public SignupDBCtx(IConfiguration config, ISqlDataAccess dataAccess, EmailService emailService, ILogger<SignupDBCtx> logger) : base(config)
        {
            _dataAccess = dataAccess;
            _emailService = emailService;
            _config = config;
            _logger = logger;
        }



        public async Task<DbMessageWithValue> SignUpUser(UserRegistrarionModel model)
        {

            _logger.LogInformation("Signnig up User: " + model.Email);
            try
            {

                // Generate 6-digit code
                var code = new Random().Next(100000, 999999).ToString();


                // send email and save the code after response.

                var Subject = "Verify Your Email to continue on " + _config["Application:Name"];

                var emailbody = $"<p>Your " + _config["Application:Name"] + " verification code is: <strong>"+code+"</strong></p>";


                bool emailResponse = await _emailService.SendEmailAsync(model.Email, Subject, emailbody);

                if (emailResponse)
                {

                    DynamicParameters p = new DynamicParameters();

                p.Add("@FirstName", model.FirstName);
                p.Add("@MiddleName", model.MiddleName);
                p.Add("@LastName", model.LastName);
                p.Add("@Email", model.Email);
                p.Add("@Password", model.Password);
                p.Add("@IsDonorSeeker", model.IsDonorSeeker);
                p.Add("@Code", code);

                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);
                p.Add("@Value", direction: ParameterDirection.Output, size: 50);

                var result = ExecuteNonQueryResult("[dbo].[User.Save]", p);

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
                    Msg = "Failed to send verification email. Please try again.",
                    Value = ""
                };
            }

        }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }



        public DbMessage VerifyEmail(string Email, int code)
        {
            try 
            {
                _logger.LogInformation("Verifying Email address: " + Email);

                DynamicParameters p = new DynamicParameters();

               
                p.Add("@Email", Email);
                p.Add("@Code", code);

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
