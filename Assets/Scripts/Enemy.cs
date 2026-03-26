using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int enemyStrength;
    protected int enemyDamage;
    protected float damageRange;
    protected float heavyDamageMult;
    public BattleManager battleManager;

<<<<<<< Updated upstream
    protected virtual void EnemyTurn()
=======
    private void Start()
>>>>>>> Stashed changes
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }

    // Rolls random damage based on enemy stats
    protected void RandomDamage()
    {
        int damageMin = Mathf.RoundToInt(enemyStrength - (enemyStrength * damageRange));
        int damageMax = Mathf.RoundToInt(enemyStrength + (enemyStrength * damageRange));

        enemyDamage = Random.Range(damageMin, damageMax);
    }

    protected virtual void Attack()
    {
        RandomDamage();

        battleManager.playerHealth -= enemyDamage;

        battleManager.battleConsoleText.text = "Enemy deals " + enemyDamage + " damage!";
    }

    protected virtual void Defend()
    {
        battleManager.isEnemyDefending = true;

        battleManager.battleConsoleText.text = "Enemy is defending!";
    }

    protected virtual void HeavyAttack()
    {
        float tempDamage;

        RandomDamage();

        // Increases damage by a factor of the heavy damage multiplier
        tempDamage = enemyDamage;
        enemyDamage = Mathf.RoundToInt(tempDamage * heavyDamageMult);

        battleManager.playerHealth -= enemyDamage;

        battleManager.battleConsoleText.text = "Enemy deals " + enemyDamage + " damage!";
    }
}
