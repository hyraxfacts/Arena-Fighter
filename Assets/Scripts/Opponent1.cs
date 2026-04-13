using System.Collections;
using UnityEngine;

public class Opponent1 : Enemy
{
    void Awake()
    {
        enemyStrength = 15;
        damageRange = 0.2f;
    }

    /*
    private void Update()
    {
        if (battleManager.isBattleActive && !battleManager.isPlayerTurn)
        {
            Invoke("EnemyTurn", 2);
        }
    }

    private void EnemyTurn()
    {
        if (!battleManager.isPlayerTurn)
        {
            battleManager.isEnemyDefending = false;

            // Attacks on even turns and defends on odd turns
            if (battleManager.turnCount % 2 == 0)
            {
                Attack();
            }
            else
            {
                Defend();
            }

            battleManager.turnCount += 1;
            battleManager.isPlayerTurn = true;
        }
    }
    */
}
