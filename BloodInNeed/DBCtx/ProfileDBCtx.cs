using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Models.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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


        public IEnumerable<Country> GetCountryList()
        {
            try
            {
              return ExecuteAsList<Country>("[dbo].[Country.GetAll]");


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



        public IEnumerable<Cities> CitybyUserId(int UserId)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("@UserId", UserId);

            return ExecuteAsList<Cities>("[dbo].[City.List.GetbyUserId]", p);
        }




        public UserInfo GetUserInfo(int UserId)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("@UserId", UserId);

            return ExecuteAsObject<UserInfo>("[dbo].[User.Details.Get]", p);
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


        public DbMessage saveProfile(UserInfo model)
        {

            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@UserId", model.UserId);
                p.Add("@Salutation", model.Salutation);
                p.Add("@FirstName", model.FirstName);
                p.Add("@MiddleName", model.MiddleName);
                p.Add("@LastName", model.LastName);
                p.Add("@Gender", model.Gender);
                p.Add("@Email", model.Email);
                p.Add("@DonorSeeker", model.DonorSeeker);
                p.Add("@DOB", model.DOB);
                p.Add("@Occupation", model.Occupation);
                p.Add("@FatherName", model.FatherName);
                p.Add("@MotherName", model.MotherName);
                p.Add("@Country", model.Country);
                p.Add("@City", model.City);
                p.Add("@Contact", model.Contact);
                p.Add("@Address1", model.Address1);
                p.Add("@Address2", model.Address2);
                p.Add("@Address3", model.Address3);
                p.Add("@BloodGroup", model.BloodGroup);
                p.Add("@DonatedBefore", model.DonatedBefore);
                p.Add("@DonationCount", model.DonationCount);
                p.Add("@DonationDate", model.DonationDateRecent);
                p.Add("@Inspiration", model.Inspiration);

                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[User.Profile.Save]", p);

            }

            catch (Exception ex) {

                throw new Exception("Exception : " + ex);
            }


        }




    }
}
