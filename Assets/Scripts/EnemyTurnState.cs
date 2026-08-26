using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyTurnState : BattleState
{
    private float _enemyTurnTimer;

    public EnemyTurnState(BattleManager battleManager) : base(battleManager) { }

    private GameObject playerTurnIndicator;
    private GameObject enemyTurnIndicator;

    private bool isVariableAssigned;
    public BattleManager battleManager;

    private Unit playerUnit;
    private Unit enemyUnit;

    public override void OnEnter()
    {
        Debug.Log("Enemy Turn: START");

        AssignVariables();

        enemyUnit.isDefending = false;

        if (enemyUnit.enemyBehavior == ("Defensive"))
        {
            DefensiveBehavior();
        }

        if (enemyUnit.enemyBehavior == ("Aggressive"))
        {
            AggressiveBehavior();
        }

        if (enemyUnit.enemyBehavior == ("Magic"))
        {
            MagicBehavior();
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

    public override void OnExit()
    {
        playerTurnIndicator.SetActive(true);
        enemyTurnIndicator.SetActive(false);
    }

    private void AssignVariables()
    {
        if (isVariableAssigned == false)
        {
            battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
            playerUnit = battleManager.playerCurrentStance.GetComponent<Unit>();
            enemyUnit = battleManager.currentOpponent.GetComponent<Unit>();
            playerTurnIndicator = battleManager.playerTurnIndicator;
            enemyTurnIndicator = battleManager.enemyTurnIndicator;

            isVariableAssigned = true;
        }
    }

    private void DefensiveBehavior()
    {
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
    }

    private void AggressiveBehavior()
    {
        if (battleManager.turnCount % 2 == 0)
        {
            ICommand attackCommand = new AttackCommand(enemyUnit, playerUnit);
            attackCommand.Execute();
        }
        else
        {
            ICommand heavyAttackCommand = new HeavyAttackCommand(enemyUnit, playerUnit);
            heavyAttackCommand.Execute();
        }
    }

    private void MagicBehavior()
    {
        if (battleManager.turnCount % 2 == 0)
        {
            ICommand magicAttackCommand = new MagicAttackCommand(enemyUnit, playerUnit);
            magicAttackCommand.Execute();
        }
        else
        {
            ICommand chargeCommand = new ChargeCommand(enemyUnit);
            chargeCommand.Execute();
        }
    }
}
