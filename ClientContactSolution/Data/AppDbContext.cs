using Microsoft.EntityFrameworkCore;
using ClientContactSolution.Models;
using ClientContactSolution.Data;

namespace ClientContactSolution.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientContact>()
                .HasKey(cc => new { cc.ClientId, cc.ContactId });
        }
    }
}