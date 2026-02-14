using Application.Dtos;
using Application.Features.Students;
using Application.Interfaces;
using AutoMapper;
using Domain.Model;
using NSubstitute;

namespace TestLection43.Features.Students;

[Trait("Category", "StudentFeatures")]
public class StudentFeaturesShould
{
    [Fact]
    public async void GetAllAsync_Should()
    {
        //Arrange
        var studentRepositorySub = Substitute.For<IStudentRepository>();
        var mapperSub = Substitute.For<IMapper>();
        StudentFeatures sut = new StudentFeatures(studentRepositorySub, mapperSub);


        var studentsFromRepo = new List<Student>
        {
            new Student ("nikoloz", "Chaduneli", 16)
        };

        var expectedDtos = new List<StudentDto>
        {
            new StudentDto("Nikoloz", "Chaduneli", 16)
        };

        studentRepositorySub
            .GetStudentsAsync()
            .Returns(studentsFromRepo);

        mapperSub
            .Map<IReadOnlyList<StudentDto>>(Arg.Any<List<Student>>())
            .Returns(expectedDtos);


        //Act

        var studnets = await sut.GetAllAsync();

        //Assert
        Assert.NotNull(studnets);
        Assert.Single(studnets);
        Assert.Equal(expectedDtos[0].Name, studnets[0].Name);
        Assert.Equal(expectedDtos[0].Lastname, studnets[0].Lastname);
        Assert.Equal(expectedDtos[0].Age, studnets[0].Age);

    }


}
