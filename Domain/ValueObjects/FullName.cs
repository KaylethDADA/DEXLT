﻿using Domain.Validators;
using System.Reflection;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Полное имя
    /// </summary>
    public class FullName : BaseValueObjects
    {
        public FullName(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;

            var validationService = new FullNameValidation();
            validationService.Validate(this);
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = null;
        /// <summary>
        /// Реализация DeepCompare с рефлексией
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool DeepCompare(FullName other)
        {
            if (other == null)
                return false;

            PropertyInfo[] properties = typeof(FullName).GetProperties();

            foreach (var property in properties)
            {
                var thisValue = property.GetValue(this);
                var otherValue = property.GetValue(other);

                if (!Equals(thisValue, otherValue))
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Реализация DeepClone для FullName
        /// </summary>
        /// <returns></returns>
        public FullName DeepClone()
        {
            return new FullName(FirstName, LastName, MiddleName);
        }
        public FullName Update(string? firstName, string? lastName, string? middleName)
        {
            if (firstName is not null)
            {
                FirstName = firstName;
            }
            if (lastName is not null)
            {
                LastName = lastName;
            }
            if (middleName is not null)
            {
                MiddleName = middleName;
            }

            var validator = new FullNameValidation();
            validator.Validate(this);
            return this;
        }
    }
}