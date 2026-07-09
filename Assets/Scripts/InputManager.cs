using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Unit playerUnit;
    public Unit enemyUnit;

    private BattleManager battleManager;

    private void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        playerUnit = battleManager.playerCurrentStance.GetComponent<Unit>();
        Debug.Log("InputManager is trying to find the enemy.");
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
