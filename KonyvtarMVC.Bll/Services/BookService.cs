using KonyvtarMVC.Bll.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Text;
using KonyvtarMVC.Dal.Entities;
using System.Threading.Tasks;
using KonyvtarMVC.Dal;
using Microsoft.EntityFrameworkCore;
using KonyvtarMVC.Bll.Exceptions;
using KonyvtarMVC.Bll.Models;

namespace KonyvtarMVC.Bll.Services
{
    public class BookService : BaseService, IBookService
    {
        public BookService(IBaseServiceAggregate aggregate) : base(aggregate)
        {
        }

        public Task<List<Book>> GetAllBookAsync()
        {
            return context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
            var book = await context.Books.Include(b => b.BookItems).SingleOrDefaultAsync(b => b.Id == id);
            return book ?? throw new BllException { ErrorCode = ErrorCode.NotFound };
        }

        public Task CreateBookAsync(Book book)
        {
            book.Id = Guid.NewGuid().ToString();
            context.Books.Add(book);

            return context.SaveChangesAsync();
        }

        public async Task EditBookAsync(string id, BookEditModel book)
        {
            var current = await context.Books.SingleOrDefaultAsync(b => b.Id == id);
            if (current == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest };
            }

            context.Entry<Book>(current).CurrentValues.SetValues(book);

            await context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(string id)
        {
            var book = await context.Books.SingleOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest };
            }

            context.Books.Remove(book);

            await context.SaveChangesAsync();
        }
    }
}
