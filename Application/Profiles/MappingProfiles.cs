using Application.Dtos;
using AutoMapper;
using Domain.Model;

namespace Application.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Student,StudentDto>();
        CreateMap<University, UniversityDto>();
    }
}
