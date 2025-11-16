namespace Mandatory2DGameFramework.Worlds;

public abstract class WorldObject : WorldEntityBase
{
    public abstract bool Lootable { get; protected set; }
    public abstract bool Removeable { get; protected set; }

    public WorldObject(string name, World world, bool lootable, bool removeable) : base(name, world)
    {
        Lootable = lootable;
        Removeable = removeable;
    }

    public WorldObject(string name, WorldPosition position, World world, bool lootable, bool removeable) : base(name, position, world)
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
