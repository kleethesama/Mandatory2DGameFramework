using Mandatory2DGameFramework.Model.Creatures;

namespace Mandatory2DGameFramework.Model.GameObjectCreation;

public abstract class CreatureFactory
{
    public abstract Creature CreateRandom();

    public List<Creature> CreateRandoms(int creatureCount)
    {
        List<Creature> createdCreatures = [];
        for (int i = 0; i < creatureCount; i++)
        {
            createdCreatures.Add(CreateRandom());
        }
        return createdCreatures;
    }
}
