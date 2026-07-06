using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Unit playerUnit;
    public Unit enemyUnit;

    public void AttackButton()
    {
        ICommand attackCommand = new AttackCommand(playerUnit, enemyUnit);
        attackCommand.Execute();
    }

    public void MagicAttackButton()
    {
        ICommand magicAttackCommand = new MagicAttackCommand(playerUnit, enemyUnit);
        magicAttackCommand.Execute();
    }

    public void DefendButton()
    {
        ICommand defendCommand = new DefendCommand(playerUnit);
        defendCommand.Execute();
    }
    
    public void ChargeButton()
    {
        ICommand chargeCommand = new ChargeCommand(playerUnit);
        chargeCommand.Execute();
    }
}
