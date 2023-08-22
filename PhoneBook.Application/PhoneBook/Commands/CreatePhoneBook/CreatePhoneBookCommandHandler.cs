using AutoMapper;
using MediatR;
using PhoneBook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.PhoneBook.Commands.CreatePhoneBook
{
    public class CreatePhoneBookCommandHandler : IRequestHandler<CreatePhoneBookCommand>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IMapper _mapper;

        public CreatePhoneBookCommandHandler(IPhoneBookRepository phoneBookRepository, IMapper mapper)
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePhoneBookCommand request, CancellationToken cancellationToken)
        {
            var phoneBook = _mapper.Map<Domain.Entities.PhoneBook>(request);
            await _phoneBookRepository.Create(phoneBook);

            return Unit.Value;
        }
    }
}
