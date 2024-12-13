using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using Dapper;

namespace BloodInNeed.UI.DBCtx
{
    public class SideBarDBCtx : SqlDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;

        public SideBarDBCtx(IConfiguration config, ISqlDataAccess dataAccess) : base(config)
        {
            _dataAccess = dataAccess;
        }



        public async Task<IEnumerable<BloodGroups>> GetBloodGroupsAll()
        {
            try
            {

                return ExecuteAsList<BloodGroups>("[dbo].[Blood.Groups.GetAll]");

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }


        public BloodGroups DonateDetail(int BGId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@BGId", BGId);

                return ExecuteAsObject<BloodGroups>("[dbo].[Blood.Group.Details.Get]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }



    }
}
