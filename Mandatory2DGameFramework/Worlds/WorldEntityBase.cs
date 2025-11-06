namespace Mandatory2DGameFramework.Worlds;

public class WorldEntityBase
{
    public WorldPosition Position { get; set; }
    public string Name { get; set; }

    public WorldEntityBase()
    {
        Name = string.Empty;
    }

    public WorldEntityBase(string name)
    {
        Name = name;
    }

    public WorldEntityBase(string name, WorldPosition position)
    {
        Name = name;
        Position = position;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)} = {Name}, {nameof(Position)} = {Position}}}";
    }
}
