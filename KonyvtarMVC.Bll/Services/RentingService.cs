using KonyvtarMVC.Bll.Abstraction.Services;
using KonyvtarMVC.Bll.Exceptions;
using KonyvtarMVC.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarMVC.Bll.Services
{
    public class RentingService : BaseService, IRentingService
    {
        public RentingService(IBaseServiceAggregate aggregate) : base(aggregate)
        {
        }

        public async Task Rent(string bookBarcode, int userCardNumber)
        {
            var bookItem = await context.BookItems.SingleOrDefaultAsync(i => i.Barcode == bookBarcode);
            if (bookItem == null || bookItem.Rents.Any(i => i.End == null))
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest, Source = nameof(bookBarcode) };
            }

            var user = await context.Users.SingleOrDefaultAsync(i => i.CardNumber == userCardNumber);
            if (user == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest, Source = nameof(userCardNumber) };
            }

            var rent = new Rent
            {
                Id = Guid.NewGuid().ToString(),
                Start = DateTime.Now,
                BookItemId = bookItem.Id,
                UserId = user.Id
            };

            context.Rents.Add(rent);
            await context.SaveChangesAsync();
        }

        public async Task Return(string bookBarcode)
        {
            var bookItem = await context.BookItems.SingleOrDefaultAsync(i => i.Barcode == bookBarcode);
            if (bookItem == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest, Source = nameof(bookBarcode) };
            }

            var lastRent = bookItem.Rents.SingleOrDefault(r => r.End == null);
            if (lastRent == null)
            {
                throw new BllException { ErrorCode = ErrorCode.BadRequest };
            }

            lastRent.End = DateTime.Now;

            await context.SaveChangesAsync();
        }
    }
}
