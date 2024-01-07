using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Author.Models;

namespace StoreServices.Api.Author.Persistence
{
    public class AuthorContext: DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options): base(options) {}

        public DbSet<BookAuthor> BookAuthor { get; set; }

        public DbSet<AcademicDegree> AcademicDegree { get; set; }
    }
}
