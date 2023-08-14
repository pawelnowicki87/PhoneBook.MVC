using PhoneBook.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.Seeders
{
    public class PhoneBookSeeder
    {
        private readonly PhoneBookDbContext _dbContext;

        public PhoneBookSeeder(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.PhoneBooks.Any())
                {
                    var FirstContact = new Domain.Entities.PhoneBook()
                    {
                        FirstName = "Irena",
                        LastName = "Pawlicka",
                        Description = "Curious task solved",
                        ContactDetails = new()
                        {
                            Street = "Chłapowskiego",
                            City = "Wroclaw",
                            PostalCode = "55-330"
                        }
                    };
                    _dbContext.PhoneBooks.Add(FirstContact);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
