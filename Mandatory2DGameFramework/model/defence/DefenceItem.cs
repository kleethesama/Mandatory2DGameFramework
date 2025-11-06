using Mandatory2DGameFramework.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Model.Defence;

public class DefenceItem : WorldObject
{
    public int ReduceHitPoint { get; set; }

    public DefenceItem()
    {
        Name = string.Empty;
        ReduceHitPoint = 0;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)} = {Name}, {nameof(ReduceHitPoint)} = {ReduceHitPoint}}}";
    }
}
