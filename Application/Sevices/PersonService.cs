using Application.Dtos.Person;
using Application.Interface;
using AutoMapper;
using Domain.Entities;

namespace Application.Sevices
{
    public class PersonService
    {
        private readonly IPersonRepository _personService;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public PersonResponse Create(PersonCreateRequest request)
        {
            var person = _mapper.Map<Person>(request);
            _personService.Create(person);
            return _mapper.Map<PersonResponse>(person);
        }

        public PersonResponse Update(PersonUpdateRequest request)
        {
            var person = _personService.GetById(request.Id);

            if (person == null)
                throw new Exception();

            person.Update(request.FirstName, request.LastName, request.MiddleName, request.PhoneNumber!);
            _personService.Update(person);

            return _mapper.Map<PersonResponse>(person);
        }

        public PersonResponse GetById(Guid id)
        {
            var person = _personService.GetById(id);
            return _mapper.Map<PersonResponse>(person);
        }

        public List<PersonItemList> GetAll()
        {
            var persons = _personService.GetAll();
            return _mapper.Map<List<PersonItemList>>(persons);
        }

        public object GetCustomFields(Guid id)
        {
           return _personService.GetCustomFields(id);
        }

        public List<PersonItemList> GetBirthdaysToday()
        {
            var person = _personService.GetBirthdaysToday();
            return _mapper.Map<List<PersonItemList>>(person);
        }

        public void Delete(Guid id)
        {
            _personService.Delete(id);
        }
    }
}
