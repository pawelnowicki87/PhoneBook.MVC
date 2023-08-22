using AutoMapper;
using MediatR;
using PhoneBook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.PhoneBook.Queries.GetContactDetailsByPhoneNumber
{
    public class GetContactDetailsByPhoneNumberQueryHandler : IRequestHandler<GetContactDetailsByPhoneNumberQuery, PhoneBookDto>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IMapper _mapper;

        public GetContactDetailsByPhoneNumberQueryHandler(IPhoneBookRepository phoneBookRepository, IMapper mapper)
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }
        public async Task<PhoneBookDto> Handle(GetContactDetailsByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var contactDetails = await _phoneBookRepository.GetByPhoneNumber(request.PhoneNumber);
            var dto = _mapper.Map<PhoneBookDto>(contactDetails);
            return dto;
        }
    }
}
