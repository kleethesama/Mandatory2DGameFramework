using Mandatory2DGameFramework.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Worlds;

public class WorldObject : WorldEntityBase
{
    public bool Lootable { get; set; }
    public bool Removeable { get; set; }

    public WorldObject()
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
