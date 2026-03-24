using Application.Features.Students;
using Application.Interfaces;
using Application.Profiles;
using Asp.Versioning;
using Lection43.Filters;
using Lection43.Middleware;
using Lection43.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance;
using Persistance.Repositories;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<ConnectionOptions>(
    builder.Configuration.GetSection("ConnectionStrings")
);

builder.Services.Configure<AuthenticationOptions>(
    builder.Configuration.GetSection("Authentification")
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Input a valid token to access this api"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiBearerAuth"
                }
            }, new List<string>()
        }
    });
});

var connection = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionOptions>();

//if (builder.Environment.IsDevelopment())
//{
//    builder.Services.AddDbContext<Lection43DBContext>(dbContextOptions => dbContextOptions.UseSqlServer(connection!.DefaultConnection));
//}
//else
//{
    builder.Services.AddDbContext<Lection43DBContext>(dbContextOptions => dbContextOptions.UseSqlite(connection!.DefaultConnection));
//}



builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
}).AddMvc();

var auth = builder.Configuration.GetSection("Authentification").Get<AuthenticationOptions>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = auth!.Issuer,
        ValidAudience = auth!.Audiance,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth!.SecretKeyFor))
    };
});


builder.Services.AddScoped<StudentFeatures>();
builder.Services.AddScoped<TimerFilter>();
builder.Services.AddScoped<LogFilter>();
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
app.UseCostomMiddleware();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();



app.Run();
