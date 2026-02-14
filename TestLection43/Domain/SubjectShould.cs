using Domain.Model;

namespace TestLection43.Domain;

[Trait("Category", "Domain")]
public class SubjectShould
{
    [Fact]
    public void Subject_Should_have_empty_StudentList()
    {
        //Arrange
        Subject sut = new Subject();

        //act
        sut.Name = "C#";
        sut.Description = "Programin Course";

        //Assert
        Assert.NotNull(sut);
        Assert.NotNull(sut.Students);
        Assert.NotNull(sut.Name);
        Assert.NotNull(sut.Description);
        Assert.Equal(sut.Name, "C#");
        Assert.Equal(sut.Description, "Programin Course");
    }
}
