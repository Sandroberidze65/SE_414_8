using Application.Interfaces;
using Domain.Model;

namespace Persistance;

public class TestStudnetRepository : IStudentRepository
{
    private static List<Student> stundents = new();
    public async Task<bool> AddStudnetAsync(Student student)
    {
        stundents.Add(student);
        return true;
    }

    public async Task<Student?> GetStudentAsync(int id)
    {
        return stundents.FirstOrDefault(s => s.Id == id);
    }

    public async Task<IReadOnlyList<Student>> GetStudentsAsync()
    {
        return stundents.ToList();
    }
}
