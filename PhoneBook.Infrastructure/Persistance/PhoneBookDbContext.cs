using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.Persistance
{
    public class PhoneBookDbContext : DbContext
    {
        public DbSet<Domain.Entities.PhoneBook> PhoneBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Sever=(localdb)\\mssqllocaldb;Database=PhoneBookDb;Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.PhoneBook>()
                .OwnsOne(c => c.ContactDetails);
        }
    }
}
