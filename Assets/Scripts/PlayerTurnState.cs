using UnityEngine;

public class PlayerTurnState : BattleState
{
    public PlayerTurnState(BattleManager battleManager) : base(battleManager) { }

    private bool isVariableAssigned;
    private BattleManager battleManager;
    private Unit playerUnit;
    private Unit enemyUnit;

    public override void OnEnter()
    {
        Debug.Log("Player Turn: START");

        // Assigns unit variables and battle manager at the beginning of battle
        AssignVariables();

        // Resets player defense
        playerUnit.isDefending = false;

        // Allows player to take one action
        playerUnit.isTurnDone = false;

        // Increments turn count
        battleManager.turnCount++;

        // Turns on action buttons
        ActionUIInteractable();
    }

    public override void OnUpdate()
    {
        // Checks if the player has taken their action
        if (playerUnit.isTurnDone)
        {
            BattleManager.ChangeState(BattleManager.EnemyTurnState);
        }
    }

    public override void OnExit()
    {
        Debug.Log("Player Turn: END");

        ActionUIUninteractable();
    }

    // Turns on action buttons
    private void ActionUIInteractable()
    {
        battleManager.attackButton.interactable = true;
        battleManager.chargeButton.interactable = true;
        battleManager.defendButton.interactable = true;

        // Keeps the magic button off if magic is not charged
        if (playerUnit.isMagicCharged)
        {
            battleManager.magicButton.interactable = true;
        }
    }

    // Turns off action buttons
    private void ActionUIUninteractable()
    {
        battleManager.attackButton.interactable = false;
        battleManager.chargeButton.interactable = false;
        battleManager.magicButton.interactable = false;
        battleManager.defendButton.interactable = false;
    }

    // Assigns variables once
    private void AssignVariables()
    {
        if (isVariableAssigned == false)
        {
            battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
            playerUnit = battleManager.playerCurrentStance.GetComponent<Unit>();
            enemyUnit = battleManager.currentOpponent.GetComponent<Unit>();

            isVariableAssigned = true;
        }
    }
}
