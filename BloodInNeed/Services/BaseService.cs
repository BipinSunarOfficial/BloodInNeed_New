
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;

namespace BloodInNeed.UI.Services
{
    public class BaseService
    {
        private readonly BaseDBCtx _baseDBCtx;

        private readonly SidebarMenuService _sideBarMenuService;

        public BaseService(BaseDBCtx baseDBCtx, SidebarMenuService sidebarMenuService) 
        {
            _baseDBCtx = baseDBCtx ?? throw new ArgumentNullException(nameof(baseDBCtx));
            _sideBarMenuService = sidebarMenuService ?? throw new ArgumentNullException(nameof(sidebarMenuService));
        }

        public IEnumerable<AutoComplete> AutoCompleteGet(string SearchValue, string SearchType)
        {
            var data = _baseDBCtx.AutoCompleteGet(SearchValue, SearchType);
            return data;
        }

        public IEnumerable<BloodGroups> DonateDetail(int BGId)
        {
            var data = _baseDBCtx.DonateDetail(BGId);
            return data;
        }

        public IEnumerable<StatByCountry> GetStatByCountry(int CountryId)
        {
            var GetStatByCountry = _sideBarMenuService.GetStatByCountry(CountryId);

            return GetStatByCountry;
        }

    }
}
