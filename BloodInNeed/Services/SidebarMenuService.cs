using BloodInNeed.Data.DataAccess;
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;

namespace BloodInNeed.UI.Services
{
    public class SidebarMenuService
    {
        private readonly SideBarDBCtx _sideBarDBCtx;

        public SidebarMenuService(SideBarDBCtx sideBarDBCtx)
        {
            _sideBarDBCtx = sideBarDBCtx;
        }


        public  IEnumerable<BloodGroups> GetBloodGroupsAll()
        {
            try
            {
                var data = _sideBarDBCtx.GetBloodGroupsAll();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in SidebarMenuService while fetching blood groups: " + ex);
                //return false;
            }
        }


    }
}
