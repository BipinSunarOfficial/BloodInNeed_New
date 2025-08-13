using BloodInNeed.Data.Models;
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Models.ViewModels;

namespace BloodInNeed.UI.Services
{
    public class ProfileService
    {
        private readonly ProfileDBCtx _profileDBCtx;

        public ProfileService(ProfileDBCtx profileDBCtx)
        {
            _profileDBCtx = profileDBCtx;
        }


        //public PagedDataEditProfile<Country, BloodGroups> GetCountryList()
        //{
        //    return _profileDBCtx.GetCountryList();
        //}




        public IEnumerable<Cities> CitybyCountryId(int CountryId)
        {
           return _profileDBCtx.CitybyCountryId(CountryId);
        }


        public IEnumerable<Cities> CitybyUserId(int UserId)
        {
            return _profileDBCtx.CitybyUserId(UserId);
        }



        public UserInfo GetUserInfo(int UserId)
        {
            var data =  _profileDBCtx.GetUserInfo(UserId);
            return data;
        }

        public IEnumerable<Country> GetCountryList()
        {
            return _profileDBCtx.GetCountryList();
        }

        public IEnumerable<BloodGroups> GetBloodGroups()
        {
            return _profileDBCtx.GetBloodGroupsAll();
        }


        public DbMessage saveProfile(UserInfo model)
        {
            return _profileDBCtx.saveProfile(model);
        }


    }
}
