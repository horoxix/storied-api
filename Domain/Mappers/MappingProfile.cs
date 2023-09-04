using AutoMapper;

using Data.Entities;
using Data.Filters;

using Domain.Commands;
using Domain.Queries;

namespace Domain.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetAllPeopleQuery, GetAllPeopleQueryFilters>();

        CreateMap<AddPersonCommand, PersonVersion>()
            .ForMember(dst => dst.BirthEvent, opt => opt.MapFrom(src => src.BirthEvent));

        CreateMap<UpdatePersonCommand, PersonVersion>()
            .ForMember(dst => dst.BirthEvent, opt => opt.MapFrom(src => src.BirthEvent))
            .ForMember(dst => dst.PersonId, opt => opt.MapFrom(src => src.Id));

        CreateMap<RecordBirthCommand, PersonVersion>()
            .ForMember(dst => dst.BirthEvent, opt => opt.MapFrom(src => src.BirthEvent))
            .ForMember(dst => dst.PersonId, opt => opt.MapFrom(src => src.Id));

        CreateMap<EventDto, Event>()
            .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.LocationId.HasValue ? new Location { Id = (Guid)src.LocationId } : null))
            .ForMember(dst => dst.Id, opt => opt.Ignore());

        CreateMap<PersonVersion, PersonDto>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.PersonId));

        CreateMap<Person, PersonHistoryDto>();
    }
}
