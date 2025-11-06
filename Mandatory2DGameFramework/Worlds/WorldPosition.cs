using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Worlds;

public readonly struct WorldPosition
{
    public int X { get; init; }
    public int Y { get; init; }

    public WorldPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{{{nameof(X)} = {X}, {nameof(Y)} = {Y}}}";
    }
}
