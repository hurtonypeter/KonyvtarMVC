using KonyvtarMVC.Dal.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonyvtarMVC.Dal
{
    public class BookStoreContext : IdentityDbContext<User>, IDesignTimeDbContextFactory<BookStoreContext>
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<BookItem> BookItems { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public BookStoreContext()
        {

        }

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

        public BookStoreContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BookStoreContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-KonyvtarMVC.Web-1B2C53C6-DC25-4E73-B9BA-D92970A7D82E;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BookStoreContext(builder.Options);
        }
    }
}
