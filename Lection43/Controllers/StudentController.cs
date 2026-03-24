using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Students;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Lection43.Filters;
using Application.Commons;
using Application.Requests;

namespace Lection43.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class StudentController(StudentFeatures studentFeatures) : ControllerBase
{
    [HttpGet]
    [ServiceFilter(typeof(TimerFilter))]
    public async Task<ActionResult<IReadOnlyList<StudentDto>>> Get()
    {
        Console.WriteLine("From Action ");
        return Ok(await studentFeatures.GetAllAsync());
    }

    [ApiVersion("2.0")]
    [ApiVersion("1.0")]
    [HttpGet("{Id}")]
    public async Task<ActionResult<StudentDto>> Get(int Id)
    {

        var result = await studentFeatures.GetStudent(Id);
        if (result.IsSuccess)
            return Ok(result);

        return NotFound(new ProblemDetails
            {
                Title = "Student not found",
                Detail = result.Error,
                Status = StatusCodes.Status404NotFound,
                Instance = HttpContext.Request.Path
            }
        );

    }

    [HttpPost]
    public async Task<ActionResult<bool>> Add([FromForm] StudentRequest student)
    {
        var result = await studentFeatures.CreateStudent(student);
        if (result)
        {
            return Created();
        }
        return BadRequest();
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> Delete(int Id)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Result<int>>> UpdateStudent(int id)
    {

        if (id < 0)
        {
            return BadRequest(Result<int>.Failed("Id should not be negative"));
        }

        var student = await studentFeatures.GetStudent(id);

        if (student is null)
        {
            return NotFound(Result<int>.Failed("Student was not found"));
        }

        return Ok(Result<int>.Success(id));
    }
}
