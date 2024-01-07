using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Models;

namespace StoreServices.Api.Book.Persistence
{
    public class BookContext: DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<BookMaterial> BookMaterial { get; set; }
    }
}
