using Mandatory2DGameFramework.Model.Items.Defence.Component;

namespace Mandatory2DGameFramework.Model.Items.Defence.ComponentImplementation;

public class SubtractDefence : BuffComponent
{
    public override void ApplyBuff(DefenceItem defenceItem, int defencePoints)
    {
        defenceItem.ReduceHitPoint -= defencePoints;
    }
}
