using Application.Dtos.Person;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mapping
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<PersonCreateRequest, Person>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Telegram, opt => opt.MapFrom(src => src.Telegram))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.CustomFields, opt => opt.Ignore());

            CreateMap<Person, PersonResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.FullName.MiddleName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDay))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Telegram, opt => opt.MapFrom(src => src.Telegram));

            CreateMap<PersonUpdateRequest, Person>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            CreateMap<Person, PersonItemList>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.LastName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
        }
    }
}
