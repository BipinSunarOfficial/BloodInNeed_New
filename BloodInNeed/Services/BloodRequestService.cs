
using BloodInNeed.Data.Models;
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;
using Dapper;
using System.Data;
using System.Web.Helpers;

namespace BloodInNeed.UI.Services
{
    public class BloodRequestService
    {
        private readonly BloodRequestDbctx _bloodRequestDBCtx;

        public BloodRequestService(BloodRequestDbctx bloodRequestDBCtx) 
        {
            _bloodRequestDBCtx = bloodRequestDBCtx ?? throw new ArgumentNullException(nameof(bloodRequestDBCtx));
        }

        public DbMessage CreateRequest(BloodRequest model)
        {
           
            var data = _bloodRequestDBCtx.CreateRequest(model);
            return data;

        }


        public  IEnumerable<MyRequests> MyRequests(int userId)
        {

            var data = _bloodRequestDBCtx.MyRequests(userId);
            return data;

        }

        
        public  IEnumerable<ViewRequests> ViewRequests(int userId)
        {

            var data = _bloodRequestDBCtx.ViewRequests(userId);
            return data;

        }
        
        public  IEnumerable<ViewRequests> MyDonations(int userId)
        {

            var data = _bloodRequestDBCtx.MyDonations(userId);
            return data;

        }

        public MyRequests RequestViewDetails(int requestId)
        {
            var data = _bloodRequestDBCtx.RequestViewDetails(requestId);
            return data;
        }

        
        public DbMessage CancelRequest(int requestId, int userId)
        {
            var data = _bloodRequestDBCtx.CancelRequest(requestId, userId);
            return data;
        }
        
        public DbMessage DonorCancelRequest(int requestId, int userId)
        {
            var data = _bloodRequestDBCtx.DonorCancelRequest(requestId, userId);
            return data;
        }


        public DbMessage AcceptRequest(int requestId, int userId)
        {
            var data = _bloodRequestDBCtx.AcceptRequest(requestId, userId);
            return data;
        }

        
        public DbMessage CompleteRequest(int requestId, int userId)
        {
            var data = _bloodRequestDBCtx.CompleteRequest(requestId, userId);
            return data;
        }





    }
}
