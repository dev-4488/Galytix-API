using GalytixAPI.Models;
using GalytixAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalytixAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly IGalytixLogic _galytixLogic;
        public CountryGwpController(IGalytixLogic galytixLogic)
        {
            _galytixLogic = galytixLogic;
        }

        [Route("server/api/gwp/avg")]
        [Authorize]
        [HttpPost]
        public async Task<IDictionary<string, double>> GetAverageGrossWrittenPremiums([FromBody] GWPRequest request)
        {
           return await _galytixLogic.GetAverageGrossWrittenPremiums(request);
        }
    }
}
