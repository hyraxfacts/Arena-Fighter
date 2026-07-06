using UnityEngine;

public class ChargeCommand : ICommand
{
    private Unit _unit;

    public ChargeCommand(Unit unit)
    {
        _unit = unit;
    }

    public void Execute()
    {
        _unit.Charge();
    }
}
