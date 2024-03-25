using DexTg.Entities.Entities;
using DexTg.Entities.Extensions;
using DexTg.Entities.Primitives;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DexTg.Entities.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.FullName)
               .NotEmpty().WithMessage(p => ValidetorsMessages.IsNullOrEmpty.FormatError(nameof(p.FullName)))
               .DependentRules(() =>
               {
                   RuleFor(p => p.FullName.FirstName)
                       .Must(BeValidString).WithMessage(p => ValidetorsMessages.IsValidString.FormatError(nameof(p.FullName.FirstName)))
                       .When(p => !string.IsNullOrEmpty(p.FullName.FirstName));
                       
                   RuleFor(p => p.FullName.LastName)
                       .Must(BeValidString).WithMessage(p => ValidetorsMessages.IsValidString.FormatError(nameof(p.FullName.LastName)))
                       .When(p => !string.IsNullOrEmpty(p.FullName.LastName));

                   RuleFor(p => p.FullName.MiddleName)
                       .Must(BeValidString!).WithMessage(p => ValidetorsMessages.IsValidString.FormatError(nameof(p.FullName.MiddleName)))
                       .When(p => p.FullName != null && !string.IsNullOrEmpty(p.FullName?.MiddleName));
               });

            RuleFor(p => p.BirthDay)
                .Must(BeValidAge).WithMessage(ValidetorsMessages.ValidAge);

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage(ValidetorsMessages.IsNullOrEmpty)
                .Must(BeValidPhoneNumber).WithMessage(ValidetorsMessages.ValidPhoneNumber);

            RuleFor(p => p.Telegram)
                .NotEmpty().WithMessage(ValidetorsMessages.IsNullOrEmpty)
                .Must(StartsWithAtSymbol).WithMessage(ValidetorsMessages.ValidTelegram);
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
        /// <summary>
        /// Проверка на возраст
        /// </summary>
        /// <param name="birthDay"></param>
        /// <returns></returns>
        private bool BeValidAge(DateTime birthDay)
        {
            return (DateTime.Today - birthDay).TotalDays / 365 <= 150;
        }
        /// <summary>
        /// Проверка номера телефона для реалей ПМР
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private bool BeValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber.Replace(" ", ""), @"^\+37377[4-9][0-9]{5}$");
        }
        /// <summary>
        /// Проверка ника tg
        /// </summary>
        /// <param name="telegram"></param>
        /// <returns></returns>
        private bool StartsWithAtSymbol(string telegram)
        {
            return !string.IsNullOrEmpty(telegram) && telegram.StartsWith("@");
        }
    }
}
