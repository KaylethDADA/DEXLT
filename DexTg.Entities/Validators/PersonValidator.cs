using DexTg.Entities.Entities;
using DexTg.Entities.Primitives;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DexTg.Entities.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(string.Format(ValidetorsMessages.IsNullOrEmpty, nameof(Person)));

            RuleFor(p => p.FullName)
                    .SetValidator(new FullNameValidator());

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
