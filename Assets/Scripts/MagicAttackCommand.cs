using UnityEngine;

public class MagicAttackCommand : ICommand
{
    private Unit _attacker;
    private Unit _target;

    public MagicAttackCommand(Unit attacker, Unit target)
    {
        _attacker = attacker;
        _target = target;
    }

    public void Execute()
    {
        _attacker.Attack(_target);
    }
}
