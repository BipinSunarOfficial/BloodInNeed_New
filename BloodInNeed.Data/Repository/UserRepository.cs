using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using Dapper;

namespace BloodInNeed.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public UserRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> AddDonorUser(DonorUsers donorUser)
        {
            try
            {
                //var p = new DynamicParameters();

                //p.Add("@FirstName", donorUser.FirstName, System.Data.DbType.String);
                //p.Add("@MiddleName", donorUser.MiddleName, System.Data.DbType.String);
                //p.Add("@LastName", donorUser.LastName, System.Data.DbType.String);
                //p.Add("@UserName", donorUser.UserName, System.Data.DbType.String);
                //p.Add("@EmailAddress", donorUser.EmailAddress, System.Data.DbType.String);
                //p.Add("@ContactNumber", donorUser.ContactNumber, System.Data.DbType.String);
                //p.Add("@LoginPassword", donorUser.LoginPassword, System.Data.DbType.String);
                //p.Add("@CountryId", donorUser.CountryId, System.Data.DbType.Int32);
                //p.Add("@IsActive", donorUser.IsActive, System.Data.DbType.Int32);
                //p.Add("@IsDeleted", donorUser.IsDeleted, System.Data.DbType.Int32);
                //p.Add("@CreatedOn", donorUser.CreatedOn, System.Data.DbType.DateTime);
                //p.Add("@CreatedDevice", donorUser.CreatedDevice, System.Data.DbType.String);
                //p.Add("@CreatedIp", donorUser.CreatedIp, System.Data.DbType.String);
                //p.Add("@DeletedBy", donorUser.DeletedBy, System.Data.DbType.String);
                //p.Add("@DeletedOn", donorUser.DeletedOn, System.Data.DbType.DateTime);
                //p.Add("@DeletedReason", donorUser.DeletedReason, System.Data.DbType.String);
                //p.Add("@IsDonor", donorUser.IsDonor, System.Data.DbType.Int32);
                //p.Add("@IsSeeker", donorUser.IsSeeker, System.Data.DbType.Int32);

                //await _dataAccess.SaveData("Donor.Details.Update", p);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex );
                //return false;
            }
        }


        //public async Task<DonorUsers> GetDonorById(int id)
        //{
        //    try
        //    {
               
        //        IEnumerable<DonorUsers> result = await _dataAccess.GetData<DonorUsers, dynamic>
        //                ("Donor.Detail.Get", new { Id = id});
        //        return result.FirstOrDefault();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception : " + ex);
        //        //return false;
        //    }
        //}




    }
}
