using MediatR;
using PhoneBook.Application.PhoneBook.Queries.GetContactDetailsByPhoneNumber;
using PhoneBook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.PhoneBook.Commands.EditPhoneBook
{
    public class EditPhoneBookCommandHandler : IRequestHandler<EditPhoneBookCommand>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public EditPhoneBookCommandHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public  async Task<Unit> Handle(EditPhoneBookCommand request, CancellationToken cancellationToken)
        {
            var phoneBookContact = await _phoneBookRepository.GetByPhoneNumber(request.PhoneNumber);

            phoneBookContact.FirstName = request.FirstName;
            phoneBookContact.LastName = request.LastName;
            phoneBookContact.PhoneNumber = request.PhoneNumber;
            phoneBookContact.Description = request.Description;
            phoneBookContact.ContactDetails.Street = request.Street;
            phoneBookContact.ContactDetails.City = request.City;
            phoneBookContact.ContactDetails.PostalCode = request.PostalCode;

            await _phoneBookRepository.Commit();
            return Unit.Value;
        }
    }
}
