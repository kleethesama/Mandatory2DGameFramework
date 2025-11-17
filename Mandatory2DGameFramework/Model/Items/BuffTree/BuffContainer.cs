using Mandatory2DGameFramework.Model.Items.Defence;
using Mandatory2DGameFramework.Model.Items.Defence.Component;

namespace Mandatory2DGameFramework.Model.Items.BuffTree;

public class BuffContainer : BuffComponent
{
    protected List<BuffComponent> _children = [];

    public override bool IsContainer => true;

    public void Add(BuffComponent component)
    {
        _children.Add(component);
    }

    public bool Remove(BuffComponent component)
    {
        return _children.Remove(component);
    }

    public override void ApplyBuff(DefenceItem defenceItem, int defencePoints)
    {
        foreach (BuffComponent component in _children)
        {
            component.ApplyBuff(defenceItem, defencePoints);
        }
    }
}
