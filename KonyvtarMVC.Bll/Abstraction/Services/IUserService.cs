using KonyvtarMVC.Bll.Models;
using KonyvtarMVC.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarMVC.Bll.Abstraction.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync(string id);

        Task CreateAsync(User user);

        Task EditAsync(string id, UserEditModel user);

        Task DeleteAsync(string id);
    }
}
