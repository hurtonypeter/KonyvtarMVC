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
    public class UserService : BaseService, IUserService
    {
        public UserService(IBaseServiceAggregate aggregate) : base(aggregate)
        {
        }

        public Task<List<User>> GetAllAsync()
        {
            return context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var user = await context.Users
                .Include(u => u.Rents)
                    .ThenInclude(r => r.BookItem)
                    .ThenInclude(bi => bi.Book)
                .SingleOrDefaultAsync(u => u.Id == id);
            return user ?? throw new BllException { ErrorCode = ErrorCode.NotFound };
        }

        public Task CreateAsync(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            context.Users.Add(user);

            return context.SaveChangesAsync();
        }

        public async Task EditAsync(string id, UserEditModel user)
        {
            var current = await context.Users.SingleOrDefaultAsync(b => b.Id == id);
            if (current == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest };
            }

            context.Entry<User>(current).CurrentValues.SetValues(user);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await context.Users.SingleOrDefaultAsync(b => b.Id == id);
            if (user == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest };
            }

            context.Users.Remove(user);

            await context.SaveChangesAsync();
        }
    }
}
