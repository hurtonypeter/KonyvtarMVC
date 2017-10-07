using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonyvtarMVC.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        public UsersController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] object model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok();
        }
    }
}