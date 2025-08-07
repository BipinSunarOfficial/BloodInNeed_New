using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using Dapper;
using System.Data;
using System.Reflection;
using Microsoft.Extensions.Options;
using BloodInNeed.Data.DataAccess;
using BloodInNeed.UI.DBCtx;
namespace BloodInNeed.UI.Services
{
    public class SendCodeService
    {
        private readonly IConfiguration _config;

        private readonly SendCodeDBCtx _sendcodedbCtx;

        public SendCodeService(IConfiguration config, SendCodeDBCtx sendcodedbCtx)
        {
            _config = config;
            _sendcodedbCtx = sendcodedbCtx;
        }

        public async Task<DbMessageWithValue> SendCode(SendCode model)
        {
            var data = await _sendcodedbCtx.SendCode(model);
            return data;
        }


    }

}