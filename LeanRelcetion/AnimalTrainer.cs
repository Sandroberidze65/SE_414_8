using LearnRefletion;

namespace LeanRelcetion;

public class AnimalTrainer
{
    private IAnimalBehaivor _animalBehaiovor;

    public AnimalTrainer(IAnimalBehaivor animalBehaivor)
    {
        _animalBehaiovor = animalBehaivor;
    }


    public void Train()
    {
        _animalBehaiovor.MakeSound();
    }
}
