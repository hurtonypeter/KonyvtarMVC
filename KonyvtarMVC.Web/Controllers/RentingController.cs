using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KonyvtarMVC.Bll.Abstraction.Services;
using Newtonsoft.Json.Linq;

namespace KonyvtarMVC.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/renting")]
    public class RentingController : Controller
    {
        private readonly IRentingService rentingService;

        public RentingController(IRentingService rentingService)
        {
            this.rentingService = rentingService;
        }

        [HttpPost("rent")]
        public async Task<IActionResult> Rent([FromBody]JObject model)
        {
            await rentingService.Rent(
                model["bookBarcode"].ToString(), 
                int.Parse(model["userCardNumber"].ToString()));
            return Ok();
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return([FromBody]JObject model)
        {
            await rentingService.Return(model["bookBarcode"].ToString());
            return Ok();
        }
    }
}