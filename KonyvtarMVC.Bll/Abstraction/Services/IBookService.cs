using KonyvtarMVC.Bll.Models;
using KonyvtarMVC.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarMVC.Bll.Abstraction.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBookAsync();

        Task<Book> GetBookByIdAsync(string id);

        Task CreateBookAsync(Book book);

        Task EditBookAsync(string id, BookEditModel book);

        Task DeleteBookAsync(string id);
    }
}
