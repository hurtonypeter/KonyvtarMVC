using KonyvtarMVC.Dal.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Dal
{
    public class BookStoreContext : IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<BookItem> BookItems { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
