using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Inventory;

public abstract class Loot
{
    private readonly WorldObject? _worldObject;

    public int Id { get; private set; }
    public string Name { get; private set; }
    public LootTypes.Type Type { get; private set; }

    public Loot(int id, string name, LootTypes.Type type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    public Loot(WorldObject worldObject, int id, string name, LootTypes.Type type)
    {
        if (!worldObject.Lootable)
        {
            throw new ArgumentException("A loot's world object must be lootable.", nameof(worldObject));
        }
        _worldObject = worldObject;
        Id = id;
        Name = name;
        Type = type;
    }
}
