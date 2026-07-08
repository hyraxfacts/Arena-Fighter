using UnityEngine;

public class PlayerTurnState : BattleState
{
    public PlayerTurnState(BattleManager battleManager) : base(battleManager) { }

    private bool isBattleManagerSet;
    private BattleManager battleManager;

    public override void OnEnter()
    {
        Debug.Log("Player Turn: START");

        if (isBattleManagerSet == false)
        {
            battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
            isBattleManagerSet = true;
        }

        ActionUIInteractable();
    }

    public override void OnUpdate()
    {
        // Simple key check to switch between turns
        if (Input.GetKeyDown(KeyCode.Space))
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
        // Get isMagicCharged from Player
        //if (isMagicCharged)
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
}
