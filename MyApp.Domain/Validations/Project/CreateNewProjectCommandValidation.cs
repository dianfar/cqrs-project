using FluentValidation;
using MyApp.Domain.Queries;

namespace MyApp.Domain.Validations
{
    public class CreateNewProjectCommandValidation : AbstractValidator<CreateNewProjectCommand>
    {
        public CreateNewProjectCommandValidation()
        {
            ValidateName();
        }

        protected void ValidateName()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 100).WithMessage("The Name must have between 2 and 100 characters");
        }
    }
}
