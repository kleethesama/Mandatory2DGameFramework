using Mandatory2DGameFramework.Worlds;

namespace Mandatory2DGameFramework.Model.Inventory;

// Strategy for generating loot?
public class Inventory
{
    private readonly List<Loot> _loot;
    private readonly ILootGenerator? _lootGenerator;

    public Inventory(List<Loot> loot)
    {
        _loot = loot;
    }

    public Inventory(ILootGenerator lootGenerator)
    {
        _loot = [];
        _lootGenerator = lootGenerator;
    }

    public Inventory(ILootGenerator lootGenerator, List<Loot> loot)
    {
        _lootGenerator = lootGenerator;
        _loot = loot;
    }

    public List<Loot> GetLoot()
    {
        return [.. _loot];
    }

    public void AddLoot(Loot loot)
    {
        _loot.Add(loot);
    }

    public bool RemoveLoot(Loot loot)
    {
        return _loot.Remove(loot);
    }

    public void ClearLoot()
    {
        _loot.Clear();
    }

    // Should probably be put in the creature itself, but alas.
    public List<WorldObject> GenerateRandomLoot()
    {
        if (_lootGenerator == null) { return []; }
        throw new NotImplementedException();
    }
}
