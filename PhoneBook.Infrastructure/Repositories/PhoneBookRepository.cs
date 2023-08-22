using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookDbContext _dbContext;

        public PhoneBookRepository(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
            => _dbContext.SaveChangesAsync();
       

        public async Task Create(Domain.Entities.PhoneBook phoneBook)
        {
            _dbContext.Add(phoneBook);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.PhoneBook>> GetAll()
        => await _dbContext.PhoneBooks.ToListAsync();

        public Task<Domain.Entities.PhoneBook?> GetByName(string name)

            => _dbContext.PhoneBooks.FirstOrDefaultAsync(pb => pb.FirstName.ToLower() == name.ToLower());

        public async Task<Domain.Entities.PhoneBook> GetByPhoneNumber(string phoneNumber)
            => await _dbContext.PhoneBooks.FirstAsync(c=> c.PhoneNumber == phoneNumber);
    }
}
       