using Application.Dtos.Person;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mappings
{
    public class PersonMappingProfile : Profile
    {
        ///TODO: Вложеные сущности мапить   
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

            CreateMap<Person, PersonItemList>()
                .ForMember(dest => dest.Id, 
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FullName.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.FullName.LastName))
                .ForMember(dest => dest.MiddleName,
                    opt => opt.MapFrom(src => src.FullName.MiddleName))
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(src => src.Age));
        }
    }
}
