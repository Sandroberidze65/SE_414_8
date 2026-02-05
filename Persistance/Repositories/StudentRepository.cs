using Application.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories;

public class StudentRepository(Lection43DBContext _dbContext) : IStudentRepository
{
    public async Task<bool> AddStudnetAsync(Student student)
    {
        await _dbContext.Students.AddAsync(student);
        var result = await _dbContext.SaveChangesAsync();

        return result > 0 ? true : false;
    }

    public async Task<Student?> GetStudentAsync(int id)
    {
        return await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IReadOnlyList<Student>> GetStudentsAsync()
    {
        return await _dbContext.Students.ToListAsync();
    }
}
