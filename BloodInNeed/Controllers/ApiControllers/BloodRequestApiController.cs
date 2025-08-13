using BloodInNeed.Data.Models;
using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers.ApiControllers
{
    [Route("api/BloodRequest")]
    [ApiController]
    public class BloodRequestApiController : ControllerBase
    {

        private readonly BloodRequestService _bloodRequestService;

        public BloodRequestApiController(BloodRequestService bloodRequestService)
        {
            _bloodRequestService = bloodRequestService;
        }

        [HttpPost("CreateRequest")]
        public DbMessage CreateRequest(BloodRequest model)
        {
            var data = _bloodRequestService.CreateRequest(model);
            return data;
        }


        [HttpPost("RequestViewDetails/{requestId}")]
        public MyRequests RequestViewDetails(int requestId)
        {
            var data = _bloodRequestService.RequestViewDetails(requestId);
            return data;
        }



        [HttpPost("CancelRequest/{requestId}/{userId}")]
        public DbMessage CancelRequest(int requestId, int userId)
        {
            var data = _bloodRequestService.CancelRequest(requestId, userId);
            return data;
        }

        

        [HttpPost("DonorCancelRequest/{requestId}/{userId}")]
        public DbMessage DonorCancelRequest(int requestId, int userId)
        {
            var data = _bloodRequestService.DonorCancelRequest(requestId, userId);
            return data;
        }


        [HttpPost("AcceptRequest/{requestId}/{userId}")]
        public DbMessage AcceptRequest(int requestId, int userId)
        {
            var data = _bloodRequestService.AcceptRequest(requestId, userId);
            return data;
        }


        
        [HttpPost("CompleteRequest/{requestId}/{userId}")]
        public DbMessage CompleteRequest(int requestId, int userId)
        {
            var data = _bloodRequestService.CompleteRequest(requestId, userId);
            return data;
        }





    }
}
