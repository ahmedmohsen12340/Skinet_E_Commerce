using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfraStucture.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}