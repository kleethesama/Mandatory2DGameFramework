using ExampleGame.AI;
using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Model.GameObjectCreation;
using Mandatory2DGameFramework.Worlds;

namespace ExampleGame.Factory;

internal sealed class BirdFactory(World world) : CreatureFactory
{
    private readonly string[] _birdNames = ["Crow", "Duck", "Owl"];

    public override World World => world;

    public override Creature CreateRandom()
    {
        return new Bird(GetRandomBirdName(), GetRandomWorldPosition(), World);
    }

    private string GetRandomBirdName()
    {
        var random = new Random();
        int number = random.Next(_birdNames.Length);
        return _birdNames[number];
    }

    private WorldPosition GetRandomWorldPosition()
    {
        var random = new Random();
        int xPos = random.Next(World.MaxX + 1);
        int yPos = random.Next(World.MaxY + 1);
        return new WorldPosition(xPos, yPos);
    }
}
