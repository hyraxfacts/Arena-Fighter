using UnityEngine;
using UnityEngine.UI;

public class EnemyTurnState : BattleState
{
    private float _enemyTurnTimer;

    public EnemyTurnState(BattleManager battleManager) : base(battleManager) { }

    public override void OnEnter()
    {
        Debug.Log("Enemy Turn: START");

        // Enemy decision-making logic goes here

        _enemyTurnTimer = 2f; // Simulate a 2-second turn
    }

    public override void OnUpdate()
    {
        _enemyTurnTimer -= Time.deltaTime;
        if (_enemyTurnTimer <= 0)
        {
            BattleManager.ChangeState(BattleManager.PlayerTurnState);
        }
    }
}
