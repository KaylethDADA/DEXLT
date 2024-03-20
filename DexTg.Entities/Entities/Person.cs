using DexTg.Entities.ValueObjects;
using System.Text.RegularExpressions;

namespace DexTg.Entities.Entities
{
    public class Person : BaseEntity
    {
        public Person()
        {

        }

        public Person(FullName fullName, DateTime birthDay, string phoneNumber, string telegram)
        {
            FullName = ValidateFullName(fullName);
            BirthDay = ValidateBirthDay(birthDay);
            PhoneNumber = ValidatePhoneNumber(phoneNumber);
            Telegram = ValidateTelegram(telegram);
        }

        /// <summary>
        /// Полное имя
        /// </summary>
        public FullName FullName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age => DateTime.Now.Year - BirthDay.Year;
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Ник tg
        /// </summary>
        public string Telegram { get; set; }

        /// <summary>
        /// Метод для проверки корректности ФИО
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private FullName ValidateFullName(FullName fullName)
        {
            if (!IsValidString(fullName.FirstName) ||
                    !IsValidString(fullName.LastName))
                        throw new ArgumentException();

            else if (fullName.MiddleName is not null)
            {
                if(fullName.MiddleName == string.Empty || !IsValidString(fullName.MiddleName))
                    throw new ArgumentException();
            }

            return fullName;
        }
        /// <summary>
        /// Проверка того, что строка не равна null и содержит только буквы
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsValidString(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException("");

            return Regex.IsMatch(str, @"^[a-zа-я]+$", RegexOptions.IgnoreCase);
        } 
        /// <summary>
        /// Проверка на возраст
        /// </summary>
        /// <param name="birthDay"></param>
        /// <returns></returns>
        private DateTime ValidateBirthDay(DateTime birthDay)
        {
            if((DateTime.Today - birthDay).TotalDays / 365 > 150)
                throw new ArgumentException();

            return birthDay;
        }
        /// <summary>
        /// Проверка номера телефона для реалей ПМР
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private string ValidatePhoneNumber(string phoneNumber)
        {
            if (!Regex.IsMatch(phoneNumber.Replace(" ", ""), @"^\+37377[4-9][0-9]{5}$"))
                throw new ArgumentException();

            return phoneNumber;
        }
        /// <summary>
        /// Проверка ника tg
        /// </summary>
        /// <param name="telegram"></param>
        /// <returns></returns>
        private string ValidateTelegram(string telegram)
        {
            if(string.IsNullOrEmpty(telegram) || !telegram.StartsWith("@"))
                throw new ArgumentException();

            return telegram;
        }
    }
}
