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
        CreateMap<AddPersonCommand, Person>()
            .ForMember(dst => dst.BirthEvent, opt => opt.MapFrom(src => src.BirthEvent));
        CreateMap<RecordBirthCommand, Person>()
            .ForMember(dst => dst.BirthEvent, opt => opt.MapFrom(src => src.BirthEvent));
        CreateMap<EventDto, Event>()
            .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.LocationId.HasValue ? new Location { Id = (Guid)src.LocationId } : null))
            .ForMember(dst => dst.Id, opt => opt.Ignore());
    }
}
