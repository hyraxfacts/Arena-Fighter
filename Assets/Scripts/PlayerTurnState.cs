using TMPro;
using UnityEngine;

public class PlayerTurnState : BattleState
{
    public PlayerTurnState(BattleManager battleManager) : base(battleManager) { }

    private GameObject enemyTurnIndicator;
    private GameObject playerTurnIndicator;

    private bool isVariableAssigned;
    private BattleManager battleManager;
    private Unit playerUnit;
    private Unit enemyUnit;
    private float playerTurnTimer;

    public override void OnEnter()
    {
        Debug.Log("Player Turn: START");

        // Assigns unit variables and battle manager at the beginning of battle
        AssignVariables();

        // Resets player defense
        playerUnit.isDefending = false;

        // Allows player to take one action
        playerUnit.isTurnDone = false;

        // 2 second timer
        playerTurnTimer = 2f;

        // Increments turn count
        battleManager.turnCount++;

        // Turns on action buttons
        ActionUIInteractable();
    }

    public override void OnUpdate()
    {
        // Starts timer if the player has taken their action
        if (playerUnit.isTurnDone)
        {
            playerTurnTimer -= Time.deltaTime;

            ActionUIUninteractable();

            playerTurnIndicator.SetActive(false);
            enemyTurnIndicator.SetActive(true);

            if (playerTurnTimer <= 0)
            {
                BattleManager.ChangeState(BattleManager.EnemyTurnState);
            }
        }
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
            enemyTurnIndicator = battleManager.enemyTurnIndicator;
            playerTurnIndicator = battleManager.playerTurnIndicator;

            isVariableAssigned = true;
        }
    }
}
