using FluentValidation;
using System.Data;
using TransportApi.Domain.Dtos;

namespace TransportApi.Domain.Validators
{
    public class TransportValidator : AbstractValidator<TransportPostDTO>
    {
        public TransportValidator()
        {
            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model is not be empty or null.");

            RuleFor(x => x.Model)
                .NotEqual("Mustang 66")
                .WithMessage("This Vehicle is not be Mustang 66.");

            RuleFor(x => x.TypeTransport)
                .NotNull()
                .WithMessage("TypeTransport is not be null.");
        }
    }
}
