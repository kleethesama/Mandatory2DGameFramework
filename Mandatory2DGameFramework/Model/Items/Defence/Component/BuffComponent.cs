using Mandatory2DGameFramework.Model.Items.BuffTree;

namespace Mandatory2DGameFramework.Model.Items.Defence.Component;

public abstract class BuffComponent : IContainer
{
    public virtual bool IsContainer => false;

    public abstract void ApplyBuff(DefenceItem defenceItem, int defencePoints);
}
