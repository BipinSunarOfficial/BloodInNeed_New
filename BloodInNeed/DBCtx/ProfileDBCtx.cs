using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Models.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace BloodInNeed.UI.DBCtx
{
    public class ProfileDBCtx : SqlDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;

        public ProfileDBCtx(IConfiguration config, ISqlDataAccess dataAccess) : base(config)
        {
            _dataAccess = dataAccess;
        }


        public PagedDataEditProfile<Country,BloodGroups> GetCountryList()
        {
            try
            {
              var reader = ExecuteMultiple("[dbo].[EditProfile.Data.GetAll]");

                return new PagedDataEditProfile<Country,BloodGroups>
                {
                    Data = reader.ReadAsList<Country>(),
                    Data2 = reader.ReadAsList<BloodGroups>()
                };

            }

            catch(Exception ex)
            {
                throw new Exception("Exception : " + ex);
            } 

        }


        public IEnumerable<Cities> CitybyCountryId(int CountryId)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("@CountryId", CountryId);

            return ExecuteAsList<Cities>("[dbo].[City.List.GetbyCountryId]", p);
        }




    }
}
