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



        public IEnumerable<BloodGroups> GetBloodGroupsAll()
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

    }
}
