using Application.Dtos.Person;
using AutoMapper;
using DexTg.Entities.ValueObjects;
using Domain.Entities;

namespace Application.Mappings
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonResponse>()
             .ForMember(x => x.FirstName,
                 o => o.MapFrom(s => s.FullName.FirstName))
             .ForMember(x => x.LastName,
                 o => o.MapFrom(s => s.FullName.LastName))
             .ForMember(x => x.MiddleName,
                 o => o.MapFrom(s => s.FullName.MiddleName));

            CreateMap<PersonCreateRequest, Person>()
                .ConstructUsing(x =>
                new Person()
                {
                    FullName = new FullName
                    (
                        x.FirstName,
                        x.LastName,
                        x.MiddleName
                    ),
                    Gender = x.Gender,
                    BirthDay = x.BirthDate,
                    PhoneNumber = x.PhoneNumber,
                    Telegram = x.Telegram,
                });

            CreateMap<PersonUpdateRequest, Person>()
                .ConstructUsing(x => 
                new Person()
                {
                    Id = x.Id,
                    FullName = new FullName
                    (
                        x.FirstName, 
                        x.LastName, 
                        x.MiddleName
                    ),
                    Gender = x.Gender,
                    BirthDay = x.BirthDate,
                    PhoneNumber = x.PhoneNumber,
                    Telegram = x.Telegram
                });
        }
    }
}
