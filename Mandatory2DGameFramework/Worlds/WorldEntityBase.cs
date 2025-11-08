namespace Mandatory2DGameFramework.Worlds;

public class WorldEntityBase
{
    public World World { get; }
    public WorldPosition Position { get; set; }
    public string Name { get; set; }

    public WorldEntityBase(string name, World world)
    {
        Name = name;
        World = world;
    }

    public WorldEntityBase(string name, WorldPosition position, World world)
    {
        Name = name;
        Position = position;
        World = world;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)} = {Name}, " +
            $"{nameof(Position)} = {Position}, " +
            $"{nameof(World)} = {World}}}";
    }
}
