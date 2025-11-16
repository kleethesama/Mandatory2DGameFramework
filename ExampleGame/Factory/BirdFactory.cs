using ExampleGame.AI;
using Mandatory2DGameFramework.Model.Creatures;
using Mandatory2DGameFramework.Model.GameObjectCreation;
using Mandatory2DGameFramework.Worlds;

namespace ExampleGame.Factory;

internal sealed class BirdFactory(World world) : CreatureFactory
{
    private readonly string[] _birdNames = ["", "", ""];

    public override World World => world;

    public override Creature CreateRandom(World world)
    {
        return new Bird(GetFunnyBirdName(), GetRandomWorldPosition(world), world);
    }

    private string GetFunnyBirdName()
    {
        var random = new Random();
        int number = random.Next(_birdNames.Length);
        return _birdNames[number];
    }

    private static WorldPosition GetRandomWorldPosition(World world)
    {
        var random = new Random();
        int xPos = random.Next(world.MaxX + 1);
        int yPos = random.Next(world.MaxY + 1);
        return new WorldPosition(xPos, yPos);
    }
}
