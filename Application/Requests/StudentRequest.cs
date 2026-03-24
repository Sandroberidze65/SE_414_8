using Microsoft.AspNetCore.Http;

namespace Application.Requests;

public record StudentRequest
(
    string Name,
    string Lastname,
    int Age,
    IFormFile? Photo
);
