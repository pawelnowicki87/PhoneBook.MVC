using AutoMapper;
using MediatR;
using PhoneBook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.PhoneBook.Queries.GetAllPhoneBooks
{
    public class GetAllPhoneBooksQueryHandler : IRequestHandler<GetAllPhoneBooksQuery, IEnumerable<PhoneBookDto>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IMapper _mapper;

        public GetAllPhoneBooksQueryHandler(IPhoneBookRepository phoneBookRepository, IMapper mapper)
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PhoneBookDto>> Handle(GetAllPhoneBooksQuery request, CancellationToken cancellationToken)
        {
            var phoneBookContacts = await _phoneBookRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<PhoneBookDto>>(phoneBookContacts);

            return dtos;
        }
    }
}
