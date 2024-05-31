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

        public FullName FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age => DateTime.Now.Year - BirthDay.Year;
        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
        public Gender Gender { get; set; }
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
