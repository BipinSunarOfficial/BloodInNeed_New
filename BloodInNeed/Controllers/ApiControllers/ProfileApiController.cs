using BloodInNeed.UI.Models;
using BloodInNeed.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodInNeed.UI.Controllers.ApiControllers
{
    [Route("api/editProfile")]
    [ApiController]
    public class ProfileApiController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public ProfileApiController(ProfileService profileService)
        {
            _profileService = profileService;
        }


        [HttpGet("CitybyCountryId")]
        public IActionResult CitybyCountryId(int CountryId)
        {

            var result = _profileService.CitybyCountryId(CountryId);
           
            return Ok(result);

        }


        [HttpPost("saveProfile")]
        public IActionResult saveProfile(UserInfo model)
        {

            var result = _profileService.saveProfile(model);

            return Ok(result);

        }






    }
}
