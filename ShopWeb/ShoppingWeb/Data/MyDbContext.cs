using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingWeb.Models;

namespace ShoppingWeb.Data
{
    public class MyDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
          
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //从当前程序集加载所有IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
