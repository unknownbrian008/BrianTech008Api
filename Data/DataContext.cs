
using BrianTech008Api.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BrianTech008Api.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) 
         : base(options)

        {

        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Identity> Identitys { get; set; }
        //public DbSet<Email> Emails { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

        }

    }
}
