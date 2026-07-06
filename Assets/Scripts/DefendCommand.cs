using UnityEngine;

public class DefendCommand : ICommand
{
    private Unit _unit;

    public DefendCommand(Unit unit)
    {
        _unit = unit;
    }

    public void Execute()
    {
        _unit.Defend();
    }
}
