using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Models;

namespace StoreServices.Api.ShoppingCart.Persistence
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options) { }

        public DbSet<ShoppingCartSession> ShoppingCartSession { get; set; }
        public DbSet<ShoppingCartSessionDetail> ShoppingCartSessionDetail { get; set; }
    }
}
