using Mandatory2DGameFramework.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Model.Attack;

public class AttackItem : WorldObject
{
    public int Hit { get; set; }
    public int Range { get; set; }

    public AttackItem()
    {
        Name = string.Empty;
        Hit = 0;
        Range = 0;
    }

    public override string ToString()
    {
        return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit}, {nameof(Range)}={Range}}}";
    }
}
