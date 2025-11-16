using Mandatory2DGameFramework.Model.Items.Attack;
using Mandatory2DGameFramework.Model.Items.Defence;

namespace Mandatory2DGameFramework.Model.Items;

public interface IItemHandler
{
    public void GetAttackItem(string name);
    public void GetDefenceItem(string name);
    public void GetAttackItem(int id);
    public void GetDefenceItem(int id);
    public void AddAttackItem(AttackItem attackItem);
    public void AddDefenceItem(DefenceItem defenceItem);
    public void RemoveAttackItem(string name);
    public void RemoveDefenceItem(string name);
    public void RemoveAttackItem(int id);
    public void RemoveDefenceItem(int id);
}
