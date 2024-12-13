using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using Dapper;
using System.Buffers;
using System.Data;

namespace BloodInNeed.UI.DBCtx
{
    public class BaseDBCtx : SqlDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;


        public BaseDBCtx(IConfiguration config, ISqlDataAccess dataAccess) : base(config)
        {
            _dataAccess = dataAccess;
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
