using KonyvtarMVC.Bll.Models;
using KonyvtarMVC.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarMVC.Bll.Abstraction.Services
{
    public interface IBookItemService
    {
        Task<List<BookItem>> GetBookItemsByBookIdAsync(string bookId);

        Task<BookItem> GetBookItemById(string bookItemId);

        Task CreateBookItemAsync(BookItem bookItem);

        Task EditBookItemAsync(string id, BookItemEditModel bookItem);

        Task DeleteBookItemAsync(string id);
    }
}
