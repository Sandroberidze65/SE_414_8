using Application.Commons;
using Application.Dtos;
using Application.Interfaces;
using Application.Requests;
using AutoMapper;
using Domain.Model;

namespace Application.Features.Students;

public class StudentFeatures(IStudentRepository studentRepository, IMapper mapper)
{
    public async Task<IReadOnlyList<StudentDto>> GetAllAsync()
    {
        var student = await studentRepository.GetStudentsAsync();

        return student.Select(s => new StudentDto(s.Studentname, s.Lastname, s.Age, s.PhotoPath)).ToList();

    }

    public async Task<Result<StudentDto>> GetStudent(int id)
    {
        if (id <= 0)
            return Result<StudentDto>.Failed("Id should be greater that 0");

        var stundet = await studentRepository.GetStudentAsync(id);

        if (stundet == null)
            return Result<StudentDto>.Failed($"Student with id {id} was not found");


        return Result<StudentDto>.Success( new StudentDto(stundet.Studentname, stundet.Lastname, stundet.Age, stundet.PhotoPath));
    }

    public async Task<bool> CreateStudent(StudentRequest student)
    {
        string? filePath = null;

        if (student.Photo is not null && student.Photo.Length > 0)
        {
            var extension = Path.GetExtension(student.Photo.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var folder = Path.Combine("wwwroot", "uploads");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fullPath = Path.Combine(folder, fileName);

            await using var stream = new FileStream(fullPath, FileMode.Create);
            await student.Photo.CopyToAsync(stream);

            filePath = $"/uploads/{fileName}";
        }

        var entity = new Student
        {
            Studentname = student.Name,
            Lastname = student.Lastname,
            Age = student.Age,
            PhotoPath = filePath
        };

        return await studentRepository.AddStudnetAsync(entity);

    }

}
