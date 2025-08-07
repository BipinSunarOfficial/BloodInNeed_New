using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers.ApiControllers
{
    [Route("api/base")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly BaseService _baseService;

        public BaseApiController(BaseService baseService)
        {
            _baseService = baseService;
        }


        [HttpGet("AutoCompleteGet")]
        public IActionResult AutoCompleteGet(string SearchValue , string SearchType)
        {
            var data = _baseService.AutoCompleteGet(SearchValue, SearchType);
            return Ok(data);
        }

        [HttpGet("GetStatByCountry")]
        public IEnumerable<StatByCountry> GetStatByCountry(int CountryId)
        {
            var GetStatByCountry = _baseService.GetStatByCountry(CountryId);

            return GetStatByCountry;
        }





    }
}
