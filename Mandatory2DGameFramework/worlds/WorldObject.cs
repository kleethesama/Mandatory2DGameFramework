namespace Mandatory2DGameFramework.Worlds;

public class WorldObject : WorldEntityBase
{
    public bool Lootable { get; set; }
    public bool Removeable { get; set; }

    public WorldObject() : base()
    {
    }

    public WorldObject(string name, bool lootable, bool removeable) : base(name)
    {
        Lootable = lootable;
        Removeable = removeable;
    }

    public WorldObject(string name, WorldPosition position, bool lootable, bool removeable) : base(name, position)
    {
        Lootable = lootable;
        Removeable = removeable;
    }

    public override string ToString()
    {
        return base.ToString() +
            $", {nameof(Lootable)} = {Lootable}, " +
            $"{nameof(Removeable)} = {Removeable}}}";
    }
}
