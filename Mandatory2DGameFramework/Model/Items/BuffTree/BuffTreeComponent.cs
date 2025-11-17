using Mandatory2DGameFramework.Model.Items.Defence.Component;

namespace Mandatory2DGameFramework.Model.Items.BuffTree;

public abstract class BuffTreeComponent : BuffComponent
{
    public virtual bool IsContainer => true;
}
