using FluentValidation;
using PhoneBook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.PhoneBook.Commands.CreatePhoneBook
{
    public class CreatePhoneBookCommandValidator : AbstractValidator<CreatePhoneBookCommand>
    {
        public CreatePhoneBookCommandValidator(IPhoneBookRepository repository)
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Pole nie może być puste")
                .MinimumLength(2).WithMessage("Imię powinno mieć minimum 2 znaki")
                .MaximumLength(20).WithMessage("Imię powinno mieć maksymalnie 20 znaków");


            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Pole nie może być puste")
                .MinimumLength(2).WithMessage("Imię powinno mieć minimum 2 znaki")
                .MaximumLength(20).WithMessage("Imię powinno mieć maksymalnie 20 znaków");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Pole nie może być puste")
                .MinimumLength(2).WithMessage("Imię powinno mieć minimum 2 znaki")
                .MaximumLength(20).WithMessage("Imię powinno mieć maksymalnie 20 znaków")
                .Custom((value, context) =>
                        {
                            var existingContact = repository.GetByName(value).Result;
                            if (existingContact != null)
                            {
                                context.AddFailure($"{value} już istnieje. Proszę podać inny");
                            }
                        });
        }
    }
}
