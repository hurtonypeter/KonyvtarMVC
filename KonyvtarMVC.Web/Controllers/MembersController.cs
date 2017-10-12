﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KonyvtarMVC.Bll.Abstraction.Services;
using KonyvtarMVC.Web.Models.Member;
using KonyvtarMVC.Dal.Entities;
using Microsoft.AspNetCore.Identity;

namespace KonyvtarMVC.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class MembersController : Controller
    {
        private readonly IUserService userService;

        public MembersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var book = await userService.GetByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MemberCreateViewModel model)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] MemberEditViewModel model)
        {
            await userService.EditAsync(id, new Bll.Models.UserEditModel
            {
                Address = model.Address,
                BirthDate = model.BirthDate,
                Name = model.Name,
                BirthPlace = model.BirthPlace,
                CardNumber = model.CardNumber,
                MothersName = model.MothersName
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await userService.DeleteAsync(id);
            return Ok();
        }
    }
}