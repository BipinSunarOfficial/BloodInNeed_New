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

        public HighlightDataCounts HighlightData()
        {
            try
            {
               
                return ExecuteAsObject<HighlightDataCounts>("[dbo].[HightLight.Data.Get]");

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }

        public SMTPSettings getSmtpSettings()
        {
            try
            {

                return ExecuteAsObject<SMTPSettings>("[dbo].[SMTPSettings.Get]");

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }

        public IEnumerable<StatByCountry> GetStatByCountry(int CountryId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@CountryId", CountryId);

                return ExecuteAsList<StatByCountry>("[dbo].[StatByCountry.Get]",p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }





    }
}
