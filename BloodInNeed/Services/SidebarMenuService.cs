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


        public async Task<IEnumerable<BloodGroups>> GetBloodGroupsAll()
        {
            try
            {
                var data = await _sideBarDBCtx.GetBloodGroupsAll();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in SidebarMenuService while fetching blood groups: " + ex);
                //return false;
            }
        }

        public BloodGroups DonateDetail(int BGId)
        {
            var data = _sideBarDBCtx.DonateDetail(BGId);
            return data;
        }


        public HighlightDataCounts HighlightData()
        {
            var data = _sideBarDBCtx.HighlightData();
            return data;
        }

        public SMTPSettings getSmtpSettings()
        {
            var data = _sideBarDBCtx.getSmtpSettings();
            return data;
        }

        public IEnumerable<StatByCountry> GetStatByCountry(int CountryId)
        {
            var data = _sideBarDBCtx.GetStatByCountry(CountryId);
            return data;
        }



    }
}
