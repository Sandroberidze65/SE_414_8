using Application.Dtos;
using AutoMapper;
using Domain.Model;

namespace Application.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Studentname))
            .ReverseMap();

        CreateMap<University, UniversityDto>().ReverseMap();
    }
}
