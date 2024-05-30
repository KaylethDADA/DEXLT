using Application.Dtos.Person;
using Application.Interface;
using AutoMapper;
using Domain.Entities;

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
        public List<PersonItemList> GetAll()
        {
            var persons = _personService.GetList();
            return _mapper.Map<List<PersonItemList>>(persons);
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

            if (person == null)
                throw new Exception();

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
