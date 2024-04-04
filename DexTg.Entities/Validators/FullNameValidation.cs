using DexTg.Entities.Primitives;
using DexTg.Entities.ValueObjects;
using FluentValidation;

namespace DexTg.Entities.Validators
{
    public class FullNameValidation : AbstractValidator<FullName>
    {
        public FullNameValidation()
        {
            RuleFor(fullName => fullName.FirstName)
                .NotEmpty().WithMessage(p => string.Format(ValidetorsMessages.IsNullOrEmpty, nameof(FullName.FirstName)))
                .Must(BaseValidation.BeValidString).WithMessage(p => string.Format(ValidetorsMessages.IsValidString, nameof(FullName.FirstName)))
                .When(fullName => !string.IsNullOrEmpty(fullName.FirstName));

            RuleFor(fullName => fullName.LastName)
                .NotEmpty().WithMessage(p => string.Format(ValidetorsMessages.IsNullOrEmpty, nameof(FullName.LastName)))
                .Must(BaseValidation.BeValidString).WithMessage(p => string.Format(ValidetorsMessages.IsValidString, nameof(FullName.LastName)))
                .When(fullName => !string.IsNullOrEmpty(fullName.LastName));

            RuleFor(fullName => fullName.MiddleName)
                .Must(BaseValidation.BeValidString!).WithMessage(p => string.Format(ValidetorsMessages.IsValidString, nameof(p.MiddleName)))
                .When(p => p != null && !string.IsNullOrEmpty(p?.MiddleName));
        }
    }
}
