using Domain.Model;

namespace TestLection43.Domain;

[Trait("Category", "Domain")]
public class StudentShould
{

    [Fact]
    public void StudentConstructor_should_assign_Properties()
    {
        //arrange  + act
        Student sut = new Student("shalVA", "mindorashviLI", 19);


        //Assert
        Assert.NotNull(sut);
        Assert.Equal("Shalva", sut.Studentname);
        Assert.Equal("Mindorashvili", sut.Lastname);
        Assert.Equal(19, sut.Age);
        Assert.NotNull(sut.Subjects);
        Assert.NotNull(sut.Address);
        Assert.NotEqual("shalva", sut.Studentname);
        Assert.NotEqual("mindorashvili", sut.Lastname);
        Assert.NotEqual("shalVA", sut.Studentname);
        Assert.NotEqual("mindorashviLI", sut.Lastname);
    }

}
