using UnityEngine;
using System.Collections;

public class Opponent2 : Enemy
{
    void Awake()
    {
        enemyStrength = 10;
        damageRange = 0.2f;
        heavyDamageMult = 1.15f;
    }

    private void Update()
    {
        if (battleManager.isBattleActive && !battleManager.isPlayerTurn)
        {
            StartCoroutine("PauseTurn");
        }
    }

    public void EnemyTurn()
    {
        if (!battleManager.isPlayerTurn)
        {
            battleManager.isEnemyDefending = false;

            // Attack and heavy attack alternate turns
            if (battleManager.turnCount % 2 == 0)
            {
                HeavyAttack();
            }
            else
            {
                Attack();
            }

            battleManager.turnCount += 1;
            battleManager.isPlayerTurn = true;
        }
    }

    IEnumerator PauseTurn()
    {
        yield return new WaitForSeconds(2);

        EnemyTurn();
    }
}
