using Mandatory2DGameFramework.Model.Items.Defence.Component;

namespace Mandatory2DGameFramework.Model.Items.Defence.Decorators;

public abstract class BuffDecorator(BuffComponent buffComponent) : BuffComponent
{
    public BuffComponent BuffComponent { protected get; set; } = buffComponent;

    public override void ApplyBuff(DefenceItem defenceItem, int defencePoints)
    {
        BuffComponent.ApplyBuff(defenceItem, defencePoints);
    }
}
