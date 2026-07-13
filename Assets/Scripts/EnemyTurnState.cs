using UnityEngine;

public class EnemyTurnState : BattleState
{
    private float _enemyTurnTimer;

    public EnemyTurnState(BattleManager battleManager) : base(battleManager) { }

    private bool isVariableAssigned;
    public BattleManager battleManager;

    private Unit playerUnit;
    private Unit enemyUnit;

    public override void OnEnter()
    {
        Debug.Log("Enemy Turn: START");

        AssignVariables();

        enemyUnit.isDefending = false;

        if (battleManager.turnCount % 2 == 0)
        {
            ICommand attackCommand = new AttackCommand(enemyUnit, playerUnit);
            attackCommand.Execute();
        }
        else
        {
            ICommand defendCommand = new DefendCommand(enemyUnit);
            defendCommand.Execute();
        }

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
