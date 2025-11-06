namespace Mandatory2DGameFramework.Worlds;

public class WorldObject : WorldEntityBase
{
    public bool Lootable { get; set; }
    public bool Removeable { get; set; }

    public WorldObject() : base()
    {
        Lootable = false;
        Removeable = false;
    }

    public WorldObject(string name, bool lootable, bool removeable)
    {
        Name = name;
        Lootable = lootable;
        Removeable = removeable;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)}={Name}, {nameof(Lootable)}={Lootable}, {nameof(Removeable)}={Removeable}}}";
    }
}
