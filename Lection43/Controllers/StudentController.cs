using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Students;

namespace Lection43.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(StudentFeatures studentFeatures) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<StudentDto>>> Get()
    {
        return Ok(await studentFeatures.GetAllAsync());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<StudentDto>> Get(int Id)
    {
        var student = await studentFeatures.GetStudent(Id);

        if (student == null)
            return NotFound();


        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Add(StudentDto student)
    {
        return Ok(await studentFeatures.CreateStudent(student));
    }

}
