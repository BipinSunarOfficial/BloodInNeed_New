using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BloodInNeed.UI.Controllers.ApiControllers
{
    [Route("api/sendcode")]
    [ApiController]
    public class SendCodeApiController : ControllerBase
    {


        private readonly ISqlDataAccess _dataAccess;
        private readonly ILogger<SendCodeApiController> _logger;
        private readonly IConfiguration _config;
        private readonly EmailService _emailService;
        private readonly SendCodeService _sendCodeService;

        public SendCodeApiController(ISqlDataAccess dataAccess, ILogger<SendCodeApiController> logger, IConfiguration config, EmailService emailService, SendCodeService sendCodeService)
        {
            _dataAccess = dataAccess;
            _logger = logger;
            _config = config;
            _emailService = emailService;
            _sendCodeService = sendCodeService;
        }


        [HttpPost("SendCode")]
        public async Task<DbMessageWithValue> SendCode(SendCode model)
        {
            var data = await _sendCodeService.SendCode(model);
            return data;
        }
    }
}
