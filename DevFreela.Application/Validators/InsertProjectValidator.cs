using DevFreela.Application.Commands.Project.InsertProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Cannot be empty")
                .MaximumLength(50).WithMessage("Max length is 50");

            RuleFor(p => p.TotalCost)
                .GreaterThanOrEqualTo(1000).WithMessage("The project should cost at least 10000");
        }
    }
}
