using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Dapper;
using System.Buffers;
using System.Data;

namespace BloodInNeed.UI.DBCtx
{
    public class BaseDBCtx : SqlDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;
        private readonly ILogger<SignupDBCtx> _logger;
        private readonly IConfiguration _config;

        public BaseDBCtx(IConfiguration config, ISqlDataAccess dataAccess, ILogger<SignupDBCtx> logger) : base(config)
        {
            _dataAccess = dataAccess;
            _logger = logger;
            _config = config;
        }


        public IEnumerable<AutoComplete> AutoCompleteGet(string SearchValue, string SearchType)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@SearchValue", SearchValue);
                p.Add("@SearchType", SearchType);

                return ExecuteAsList<AutoComplete>("[dbo].[Auto.Complete.Get]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }


        public IEnumerable<BloodGroups> DonateDetail(int BGId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@BGId", BGId);               

                return ExecuteAsList<BloodGroups>("[dbo].[Blood.Group.Details.Get]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }



    }
}
