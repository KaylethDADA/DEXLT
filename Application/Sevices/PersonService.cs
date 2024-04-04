using Application.Interface;
using Application.xs.Person;
using AutoMapper;
using DexTg.Entities.Entities;
using DexTg.Entities.ValueObjects;

namespace Application.Sevices
{
    /// <summary>
    /// Сервис Person
    /// </summary>
    public class PersonService
    {
        private readonly IPersonRepository _personService;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonResponse GetById(Guid id)
        {
            var person = _personService.GetById(id);
            return _mapper.Map<PersonResponse>(person);
        }
        /// <summary>
        /// Получить список Person
        /// </summary>
        /// <returns></returns>
        public List<PersonResponse> GetAll()
        {
            var persons = _personService.GetList();
            return _mapper.Map<List<PersonResponse>>(persons);
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PersonResponse Create(PersonCreateRequest request)
        {
            var person = _mapper.Map<Person>(request);
            _personService.Create(person);
            return _mapper.Map<PersonResponse>(person);
        }
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PersonResponse Update(PersonUpdateRequest request)
        {
            var person = _personService.GetById(request.Id);

            person.FullName = new FullName(
                request.FirstName,
                request.LastName,
                request.MiddleName ?? null
                );

            person.BirthDay = request.BirthDate;
            person.Gender = request.Gender;
            person.PhoneNumber = request.PhoneNumber;
            person.Telegram = request.Telegram;

            _personService.Update(person);

            return _mapper.Map<PersonResponse>(person);
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            _personService.Delete(id);
        }
    }
}
