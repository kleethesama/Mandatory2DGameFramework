using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Inventory;

public abstract class Loot
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public WorldObject? WorldObject { get; private set; }

    public Loot(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Loot(WorldObject worldObject, int id, string name)
    {
        WorldObject = worldObject;
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{{{nameof(Id)} = {Id}, {nameof(Name)} = {Name}}}";
    }
}
