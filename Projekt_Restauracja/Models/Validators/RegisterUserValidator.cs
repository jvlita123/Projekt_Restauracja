using FluentValidation;
using Projekt_Restauracja.Data;
using System.Linq;

namespace Projekt_Restauracja.Models.Validators
{
    public class RegisterUserValidator : AbstractValidator<User>
    {
        public RegisterUserValidator(RestaurantDbContext dbContext)
        {
            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Year)
                .InclusiveBetween(1899, 2022)
                .WithMessage("Oczekiwana wartość {0} z zakresu {1} i {2}.");
                

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(50);

            RuleFor(x => x.ConfrimPassword)
                .Equal(e => e.Password);

            RuleFor(x => x.Name)
                .MaximumLength(50);

            RuleFor(x => x.Surname)
                .MaximumLength(100);

            RuleFor(x => x.email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.email == value);
                    if(emailInUse)
                    {
                        context.AddFailure("Email", "Ten adres e-mail jest zajety"); 
                    }

                });
        }

    }
}
