using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KonyvtarMVC.Bll.Abstraction.Services;

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
        public async Task<IActionResult> Rent(string bookBarcode, int userCardNumber)
        {
            await rentingService.Rent(bookBarcode, userCardNumber);
            return Ok();
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return(string bookBarcode)
        {
            await rentingService.Return(bookBarcode);
            return Ok();
        }
    }
}