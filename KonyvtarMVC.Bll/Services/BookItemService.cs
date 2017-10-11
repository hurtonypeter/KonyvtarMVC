using KonyvtarMVC.Bll.Abstraction.Services;
using KonyvtarMVC.Bll.Exceptions;
using KonyvtarMVC.Bll.Models;
using KonyvtarMVC.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarMVC.Bll.Services
{
    public class BookItemService : BaseService, IBookItemService
    {
        public BookItemService(IBaseServiceAggregate aggregate) : base(aggregate)
        {
        }

        public Task<List<BookItem>> GetBookItemsByBookIdAsync(string bookId)
        {
            return context.BookItems.Where(i => i.BookId == bookId).ToListAsync();
        }

        public Task CreateBookItemAsync(BookItem bookItem)
        {
            bookItem.Id = Guid.NewGuid().ToString();
            context.BookItems.Add(bookItem);

            return context.SaveChangesAsync();
        }

        public async Task EditBookItemAsync(string id, BookItemEditModel bookItem)
        {
            var current = await context.BookItems.SingleOrDefaultAsync(b => b.Id == id);
            if (current == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest };
            }

            context.Entry<BookItem>(current).CurrentValues.SetValues(bookItem);

            await context.SaveChangesAsync();
        }

        public async Task DeleteBookItemAsync(string id)
        {
            var current = await context.BookItems.SingleOrDefaultAsync(b => b.Id == id);
            if (current == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest };
            }

            context.BookItems.Remove(current);

            await context.SaveChangesAsync();
        }

        public Task<BookItem> GetBookItemById(string bookItemId)
        {
            return context.BookItems.SingleOrDefaultAsync(i => i.Id == bookItemId)
                ?? throw new BllException { ErrorCode = ErrorCode.NotFound };
        }
    }
}
