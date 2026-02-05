using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Students;
using Asp.Versioning;

namespace Lection43.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class StudentController(StudentFeatures studentFeatures) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<StudentDto>>> Get()
    {
        return Ok(await studentFeatures.GetAllAsync());
    }

    [ApiVersion("2.0")]
    [HttpGet("{Id}")]
    public async Task<ActionResult<StudentDto>> Get(int Id)
    {

        try
        {
            var student = await studentFeatures.GetStudent(Id);
            return Ok(student);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
        
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Add(StudentDto student)
    {
        return Ok(await studentFeatures.CreateStudent(student));
    }

}
