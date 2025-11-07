using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Inventory;

public abstract class Loot
{
    private readonly WorldObject? _worldObject;

    public int Id { get; private set; }
    public string Name { get; private set; }

    public Loot(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Loot(WorldObject worldObject, int id, string name)
    {
        //if (!worldObject.Lootable)
        //{
        //    throw new ArgumentException("A loot's world object must be lootable.", nameof(worldObject));
        //}
        _worldObject = worldObject;
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{{{nameof(Id)} = {Id}, {nameof(Name)} = {Name}}}";
    }
}
