using DevFreela.Application.Models;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Invalid e-mail");

            RuleFor(bd => bd.BirthDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                .WithMessage("Invalid birth date");
        }
    }
}
