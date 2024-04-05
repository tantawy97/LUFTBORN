using FluentValidation;

namespace Application.BussinessLogic.Items.Command.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().NotNull().WithMessage("Name is Required");

            RuleFor(e => e.Price)
           .NotNull()
           .WithMessage("Price is required")
           .GreaterThanOrEqualTo(0)
           .WithMessage("Invalid Price"); 

            RuleFor(e => e.Quantity)
           .NotNull()
           .WithMessage("Quantity is required")
           .GreaterThanOrEqualTo(0)
           .WithMessage("Invalid quantity");
        }
    }
}
