using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
