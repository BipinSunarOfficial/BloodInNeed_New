using BloodInNeed.Data.DataAccess;
using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using Dapper;
using System.Data;

namespace BloodInNeed.UI.DBCtx
{
    public class BloodRequestDbctx : SqlDataAccess
    {
        private readonly ISqlDataAccess _dataAccess;


        public BloodRequestDbctx(IConfiguration config, ISqlDataAccess dataAccess) : base(config)
        {
            _dataAccess = dataAccess;
        }


        public DbMessage CreateRequest(BloodRequest model)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@receipentId", model.receipentId);
                p.Add("@patientName", model.patientName);
                p.Add("@bloodGroup", model.bloodGroup);
                p.Add("@requiredUnits", model.requiredUnits);
                p.Add("@urgencyLevel", model.urgencyLevel);
                p.Add("@hospitalName", model.hospitalName);
                p.Add("@bloodCity", model.bloodCity);
                p.Add("@dueDate", model.dueDate);
                p.Add("@contactNumber", model.contactNumber);
                p.Add("@diagnosis", model.diagnosis);
                p.Add("@notes", model.notes);

                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[Blood.Request.Create]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }




        public IEnumerable<MyRequests> MyRequests(int userId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@userId", userId);
                

                return  ExecuteAsList<MyRequests>("[dbo].[My.Request.Get]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }



        public IEnumerable<ViewRequests> ViewRequests(int userId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@userId", userId);


                return ExecuteAsList<ViewRequests>("[dbo].[Requests.View]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }
        
        public IEnumerable<ViewRequests> MyDonations(int userId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@userId", userId);


                return ExecuteAsList<ViewRequests>("[dbo].[Requests.View.MyDonations]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }

        public MyRequests RequestViewDetails(int requestId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@requestId", requestId);


                return ExecuteAsObject<MyRequests>("[dbo].[Request.DetailById]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }



        public DbMessage CancelRequest(int requestId, int userId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@requestId", requestId);
                p.Add("@userId", userId);
                

                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[Blood.Request.Cancel]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }


        public DbMessage AcceptRequest(int requestId, int userId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@requestId", requestId);
                p.Add("@userId", userId);


                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[Blood.Request.Accept]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }


        public DbMessage CompleteRequest(int requestId, int userId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@requestId", requestId);
                p.Add("@userId", userId);


                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[Blood.Request.Complete]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }


        public DbMessage DonorCancelRequest(int requestId, int userId)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@requestId", requestId);
                p.Add("@userId", userId);


                p.Add("@MsgType", direction: ParameterDirection.Output, size: 20);
                p.Add("@Msg", direction: ParameterDirection.Output, size: 4000);

                return ExecuteNonQueryResult("[dbo].[Donor.Blood.Request.Cancel]", p);

            }
            catch (Exception ex)
            {
                throw new Exception("Exception : " + ex);
            }
        }





    }
}
