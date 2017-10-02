using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using KonyvtarMVC.Bll.Abstraction.Services;
using KonyvtarMVC.Web.Models.Books;
using KonyvtarMVC.Dal.Entities;
using KonyvtarMVC.Bll.Models;

namespace KonyvtarMVC.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/books")]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok((await bookService.GetAllBookAsync()).Select(b => new BookListViewModel
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Isbn = b.Isbn
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookEditViewModel model)
        {
            var book = new Book
            {
                Author = model.Author,
                Title = model.Title,
                Isbn = model.Isbn
            };
            await bookService.CreateBookAsync(book);
            return Ok(book.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] BookEditViewModel model)
        {
            await bookService.EditBookAsync(id, new BookEditModel
            {
                Author = model.Author,
                Title = model.Title,
                Isbn = model.Isbn
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await bookService.DeleteBookAsync(id);
            return Ok();
        }
    }
}