using Domain.Model;

namespace Application.Interfaces;

public interface IStudentRepository
{
    public Task<IReadOnlyList<Student>> GetStudentsAsync();
    public Task<Student?> GetStudentAsync(int id);
    public Task<bool> AddStudnetAsync(Student student);

}

