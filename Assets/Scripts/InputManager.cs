using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Unit playerUnit;
    private Unit enemyUnit;

    private BattleManager battleManager;

    private void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        playerUnit = battleManager.playerCurrentStance.GetComponent<Unit>();
        enemyUnit = battleManager.currentOpponent.GetComponent<Unit>();
    }

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
