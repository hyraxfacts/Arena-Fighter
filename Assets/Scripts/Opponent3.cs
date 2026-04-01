using UnityEngine;
using System.Collections;

public class Opponent3 : Enemy
{
    void Awake()
    {
        enemyStrength = 20;
        damageRange = 0.1f;
        heavyDamageMult = 1.2f;
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

            RandomNumber();

            // Attack and defend alternate, but with 50% chance of heavy attack instead
            if (battleManager.turnCount % 2 == 0)
            {
                if (randomNum == 1)
                {
                    Attack();
                }
                else
                {
                    HeavyAttack();
                }
            }
            else
            {
                if (randomNum == 1)
                {
                    Defend();
                }
                else
                {
                    HeavyAttack();
                }
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
