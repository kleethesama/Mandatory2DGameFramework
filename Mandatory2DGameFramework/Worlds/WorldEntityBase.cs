namespace Mandatory2DGameFramework.Worlds;

public class WorldEntityBase
{
    public WorldPosition Position { get; set; }
    public string Name { get; set; }

    public WorldEntityBase()
    {
        Name = string.Empty;
    }
}
