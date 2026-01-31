using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class Lection43DBContext : DbContext
{
    public Lection43DBContext(DbContextOptions<Lection43DBContext> options)
    : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<University> Universities { get; set; }


}
