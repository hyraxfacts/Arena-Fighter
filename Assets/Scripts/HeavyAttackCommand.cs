using UnityEngine;

public class HeavyAttackCommand : ICommand
{
    private Unit _attacker;
    private Unit _target;

    public HeavyAttackCommand(Unit attacker, Unit target)
    {
        _attacker = attacker;
        _target = target;
    }

    public void Execute()
    {
        _attacker.HeavyAttack(_target);
    }
}