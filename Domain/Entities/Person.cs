using Domain.Primitives.Enums;
using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public Person() { }
        public Person(FullName fullName, DateTime birthDay, string phoneNumber, string telegram, Gender gender, List<CustomField<string>> customFields)
        {
            FullName = fullName;
            BirthDay = birthDay;
            PhoneNumber = phoneNumber;
            Telegram = telegram;
            Gender = gender;
            CustomFields = customFields;

            var validator = new PersonValidation();
            validator.Validate(this);
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
        /// Гендер
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Кастомные поля
        /// </summary>
        public List<CustomField<string>> CustomFields { get; set; }
        public Person Update(string? fistName, string? lastName, string? middleName, string phoneNumber)
        {
            FullName.Update(fistName, lastName, middleName);
            PhoneNumber = phoneNumber;

            var validator = new PersonValidation();
            validator.Validate(this);

            return this;
        }
    }
}
