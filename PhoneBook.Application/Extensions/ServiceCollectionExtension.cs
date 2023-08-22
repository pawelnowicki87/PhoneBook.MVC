using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Mappings;
using PhoneBook.Application.PhoneBook.Commands.CreatePhoneBook;


namespace PhoneBook.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreatePhoneBookCommand));

            services.AddAutoMapper(typeof(PhoneBookMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreatePhoneBookCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
