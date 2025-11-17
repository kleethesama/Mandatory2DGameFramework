using Mandatory2DGameFramework.Model.Items.Defence;
using Mandatory2DGameFramework.Model.Items.Defence.Component;
using Mandatory2DGameFramework.Model.Items.Defence.Decorators;

namespace Mandatory2DGameFramework.Model.Items.BuffTree;

public class BuffTreeLeaf(BuffComponent buffComponent) : BuffDecorator(buffComponent)
{
    public override void ApplyBuff(DefenceItem defenceItem, int defencePoints)
    {
        throw new NotImplementedException();
    }
}
