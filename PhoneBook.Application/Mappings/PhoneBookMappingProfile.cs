using AutoMapper;
using PhoneBook.Application.PhoneBook;
using PhoneBook.Application.PhoneBook.Commands.EditPhoneBook;
using PhoneBook.Domain.Entities;


namespace PhoneBook.Application.Mappings
{
    public class PhoneBookMappingProfile : Profile
    {
        public PhoneBookMappingProfile()
        {
            CreateMap<PhoneBookDto, Domain.Entities.PhoneBook>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new PhoneBookContactDetails()
                {
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode,
                }));

            CreateMap<Domain.Entities.PhoneBook, PhoneBookDto>()
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));

            CreateMap<PhoneBookDto, EditPhoneBookCommand>();

        }
    }
}
