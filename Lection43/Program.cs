using Application.Features.Students;
using Application.Interfaces;
using Application.Profiles;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Lection43DBContext>(dbContextOptions => dbContextOptions.UseSqlServer(
    builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
}).AddMvc();


builder.Services.AddScoped<StudentFeatures>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfiles));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
