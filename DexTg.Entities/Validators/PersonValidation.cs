using DexTg.Entities.Entities;
using DexTg.Entities.Primitives;
using FluentValidation;

namespace DexTg.Entities.Validators
{
    public class PersonValidation : AbstractValidator<Person>
    {
        public PersonValidation()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(string.Format(ValidetorsMessages.IsNullOrEmpty, nameof(Person)));

            RuleFor(p => p.FullName)
                    .SetValidator(new FullNameValidation());

            RuleFor(p => p.BirthDay)
                .Must(BaseValidation.BeValidAge).WithMessage(ValidetorsMessages.ValidAge);

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage(ValidetorsMessages.IsNullOrEmpty)
                .Must(BaseValidation.BeValidPhoneNumber).WithMessage(ValidetorsMessages.ValidPhoneNumber);

            RuleFor(p => p.Telegram)
                .NotEmpty().WithMessage(ValidetorsMessages.IsNullOrEmpty)
                .Must(BaseValidation.StartsWithAtSymbol).WithMessage(ValidetorsMessages.ValidTelegram);
        }
    }
}
