using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KonyvtarMVC.Bll.Abstraction.Services;
using KonyvtarMVC.Dal.Entities;
using KonyvtarMVC.Bll.Models;
using KonyvtarMVC.Web.Models.Books;

namespace KonyvtarMVC.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/bookItems")]
    public class BookItemsController : Controller
    {
        private readonly IBookItemService bookItemService;

        public BookItemsController(IBookItemService bookItemService)
        {
            this.bookItemService = bookItemService;
        }

        [HttpGet]
        public async Task<IActionResult> List(string bookId)
        {
            return Ok((await bookItemService.GetBookItemsByBookIdAsync(bookId)).Select(i => new BookItemListViewModel
            {
                Id = i.Id,
                Barcode = i.Barcode,
                State = i.State
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookItemEditViewModel model)
        {
            var bookItem = new BookItem
            {
                BookId = model.BookId,
                Barcode = model.Barcode,
                Condition = model.Condition
            };
            await bookItemService.CreateBookItemAsync(bookItem);
            return Ok(bookItem.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] BookItemEditViewModel model)
        {
            await bookItemService.EditBookItemAsync(id, new BookItemEditModel
            {
                Barcode = model.Barcode,
                Condition = model.Condition
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await bookItemService.DeleteBookItemAsync(id);
            return Ok();
        }
    }
}