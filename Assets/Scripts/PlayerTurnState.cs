using UnityEngine;

public class PlayerTurnState : BattleState
{
    public PlayerTurnState(BattleManager battleManager) : base(battleManager) { }

    public override void OnEnter()
    {
        Debug.Log("Player Turn: START");
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
    }
}
