namespace LearnRefletion;

public class Student
{


}

public class Animal
{
    private static int count=0;
    public string Name { get; set; } = String.Empty;
    public int Age { get; set; } = 0;
    public Breed Breed { get; set; } = Breed.taqsa;

    public Animal()
    {
        IncreaseCount();
    }

    public Animal(string name, int age) : this()
    {
        Name = name;
        Age = age;
    }

    public Animal(string name, int age, Breed breed) : this(name, age)
    {
        Breed = breed;
    }

    private void MakeSound()
    {
        Console.WriteLine("Bark");
    }

    public void Command(string Command)
    {
        Console.WriteLine($"Dog do out {Command}");
    }

    private static void IncreaseCount()
    {
        count++;
    }

    internal static int GetAnimalCount()
    {
        return count;
    }

    public override string ToString()
    {
        return $"Name:{Name} Age:{Age}";
    }
}

public enum Breed
{
    taqsa,
    nagazi,
    buldog
}

public interface IAnimalBehaivor
{
    public void MakeSound();
}

public class AnimalBehaivor : IAnimalBehaivor
{
    public void MakeSound()
    {
        Console.WriteLine("Make Some Sound");
    }
}