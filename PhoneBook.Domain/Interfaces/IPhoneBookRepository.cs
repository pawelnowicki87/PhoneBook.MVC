

namespace PhoneBook.Domain.Interfaces
{
    public interface IPhoneBookRepository
    {
        Task Create(Domain.Entities.PhoneBook phoneBook);
        Task<Domain.Entities.PhoneBook?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.PhoneBook>> GetAll();
        Task<Domain.Entities.PhoneBook> GetByPhoneNumber(string phoneNumber);
        Task Commit();
    }
}
