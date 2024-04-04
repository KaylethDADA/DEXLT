using System.Text.RegularExpressions;

namespace DexTg.Entities.Validators
{
    public static class BaseValidation
    {
        /// <summary>
        /// Проверка на корректный id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ValidatorId(this Guid id)
        {
            return id != Guid.Empty;
        }
        /// <summary>
        /// Проверка на возраст
        /// </summary>
        /// <param name="birthDay"></param>
        /// <returns></returns>
        public static bool BeValidAge(DateTime birthDay)
        {
            return (DateTime.Today - birthDay).TotalDays / 365 <= 150;
        }
        /// <summary>
        /// Проверка номера телефона для ПМР
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool BeValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber.Replace(" ", ""), @"^\+37377[4-9][0-9]{5}$");
        }
        /// <summary>
        /// Проверка ника tg
        /// </summary>
        /// <param name="telegram"></param>
        /// <returns></returns>
        public static bool StartsWithAtSymbol(string telegram)
        {
            return !string.IsNullOrEmpty(telegram) && telegram.StartsWith("@");
        }
        /// <summary>
        /// Проверка того, что строка содержит только буквы
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool BeValidString(string str)
        {
            return Regex.IsMatch(str, @"^[a-zа-я]+$", RegexOptions.IgnoreCase);
        }
    }
}
