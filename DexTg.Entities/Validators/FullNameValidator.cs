using DexTg.Entities.Primitives;
using DexTg.Entities.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DexTg.Entities.Validators
{
    public class FullNameValidator : AbstractValidator<FullName>
    {
        public FullNameValidator()
        {
            RuleFor(fullName => fullName.FirstName)
                .NotEmpty().WithMessage(p => string.Format(ValidetorsMessages.IsNullOrEmpty, nameof(FullName.FirstName)))
                .Must(BeValidString).WithMessage(p => string.Format(ValidetorsMessages.IsValidString, nameof(FullName.FirstName)))
                .When(fullName => !string.IsNullOrEmpty(fullName.FirstName));

            RuleFor(fullName => fullName.LastName)
                .NotEmpty().WithMessage(p => string.Format(ValidetorsMessages.IsNullOrEmpty, nameof(FullName.LastName)))
                .Must(BeValidString).WithMessage(p => string.Format(ValidetorsMessages.IsValidString, nameof(FullName.LastName)))
                .When(fullName => !string.IsNullOrEmpty(fullName.LastName));

            RuleFor(fullName => fullName.MiddleName)
                .Must(BeValidString!).WithMessage(p => string.Format(ValidetorsMessages.IsValidString, nameof(p.MiddleName)))
                .When(p => p != null && !string.IsNullOrEmpty(p?.MiddleName));
        }
        /// <summary>
        /// Проверка того, что строка содержит только буквы
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool BeValidString(string str)
        {
            return Regex.IsMatch(str, @"^[a-zа-я]+$", RegexOptions.IgnoreCase);
        }
    }
}
