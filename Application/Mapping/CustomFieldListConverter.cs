using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class CustomFieldListConverter : ITypeConverter<Person, List<CustomField<string>>>
    {
        /// <summary>
        /// Convert, который преобразовывает объекты типа Person в List<CustomField<string>>
        /// </summary>
        /// <param name="source">исходный объект, который нужно преобразовать</param>
        /// <param name="destination">объект, в который будет помещен результат преобразования (может быть пустым)</param>
        /// <param name="context">контекст маппинга, предоставляющий дополнительную информацию о маппинге (например, используемые профили и настройки)</param>
        /// <returns></returns>
        public List<CustomField<string>> Convert(Person source, List<CustomField<string>> destination, ResolutionContext context)
        {
            // получаем список пользовательских полей из объекта Person и преобразуем каждое поле в объект CustomField<string>
            var customFields = source.CustomFields
                .Select(cf => 
                new CustomField<string> 
                {
                    Name = cf.Name,
                    Value = cf.Value.ToString()
                })
                .ToList();

            return customFields;
        }
    }
}
