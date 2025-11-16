using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.GameObjectCreation;

public abstract class CreatureFactory
{
    public abstract World World { get; }

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
