using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds;

public class World
{
    private List<WorldObject> _worldObjects;
    private List<Creature> _creatures;

    public int MaxX { get; set; }
    public int MaxY { get; set; }

    public World(int maxX, int maxY)
    {
        MaxX = maxX;
        MaxY = maxY;
        _worldObjects = [];
        _creatures = [];
    }

    public override string ToString()
    {
        return $"{{{nameof(MaxX)}={MaxX}, {nameof(MaxY)}={MaxY}}}";
    }
}
