using Mandatory2DGameFramework.Model.Items.Defence.Component;

namespace Mandatory2DGameFramework.Model.Items.Defence.Decorators;

public class FragileDefenceDebuff(BuffComponent buffComponent) : BuffDecorator(buffComponent)
{
    public override void ApplyBuff(DefenceItem defenceItem, int defencePoints)
    {
        base.ApplyBuff(defenceItem, -defencePoints / 2);
    }
}
