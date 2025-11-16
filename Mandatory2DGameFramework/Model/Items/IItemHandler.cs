using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;

namespace Mandatory2DGameFramework.Model.Items;

public interface IItemHandler
{
    public int MaxItems { get; }

    public bool IsAllowedAttackItem(AttackItem attackItem);
    public bool IsAllowedDefenceItem(DefenceItem defenceItem);
    public void GetAttackItem(string name, List<AttackItem> attackItems);
    public void GetDefenceItem(string name, List<DefenceItem> defenceItems);
    public void GetAttackItem(int id, List<AttackItem> attackItems);
    public void GetDefenceItem(int id, List<DefenceItem> defenceItems);
    public void AddAttackItem(AttackItem attackItem, List<AttackItem> attackItems);
    public void AddDefenceItem(DefenceItem defenceItem, List<DefenceItem> defenceItems);
    public void RemoveAttackItem(string name, List<AttackItem> attackItems);
    public void RemoveDefenceItem(string name, List<DefenceItem> defenceItems);
    public void RemoveAttackItem(int id, List<AttackItem> attackItems);
    public void RemoveDefenceItem(int id, List<DefenceItem> defenceItems);
}
