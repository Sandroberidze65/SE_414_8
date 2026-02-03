using Application.Dtos;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Model;

namespace Application.Features.Students;

public class StudentFeatures(IStudentRepository studentRepository, IMapper mapper)
{

    public async Task<IReadOnlyList<StudentDto>> GetAllAsync()
    {
        var student = await studentRepository.GetStudentsAsync();

        return student.Select(s => new StudentDto(s.Studentname, s.Lastname, s.Age)).ToList();

    }

    public async Task<StudentDto> GetStudent(int id)
    {
        var stundet = await studentRepository.GetStudentAsync(id);

        if (stundet == null)
        {
            throw new StudentNotFoundException("Stundet Not Found");
        }

        return new StudentDto(stundet.Studentname, stundet.Lastname, stundet.Age);
    }

    public async Task<bool> CreateStudent(StudentDto student)
    {
        var temp = mapper.Map<Student>(student);
        return await studentRepository.AddStudnetAsync(temp);
    }

}
