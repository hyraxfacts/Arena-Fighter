using UnityEngine;

public class Enemy : MonoBehaviour
{   // INHERITANCE
    protected int enemyStrength;
    protected int enemyDamage;
    protected int randomNum;
    protected float damageRange;
    protected float heavyDamageMult;
    protected BattleManager battleManager;

    private void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
    }

    // Rolls random damage based on enemy stats
    // ABSTRACTION
    protected void RandomDamage()
    {
        int damageMin = Mathf.RoundToInt(enemyStrength - (enemyStrength * damageRange));
        int damageMax = Mathf.RoundToInt(enemyStrength + (enemyStrength * damageRange));

        enemyDamage = Random.Range(damageMin, damageMax);
    }

    protected void RandomNumber()
    {
        randomNum = Random.Range(1, 2);
    }

    /*
    protected void Attack()
    {
        float tempDamage;

        RandomDamage();

        tempDamage = enemyDamage * battleManager.playerDefense;

        enemyDamage = Mathf.RoundToInt(tempDamage);

        // Reduce damage dealt if player is defending
        if (battleManager.isPlayerDefending)
        {
            enemyDamage /= 2;
        }

        battleManager.playerHealth -= enemyDamage;

        battleManager.battleConsoleText.text = "Enemy deals " + enemyDamage + " damage!";
    }

    protected void Defend()
    {
        battleManager.isEnemyDefending = true;

        battleManager.battleConsoleText.text = "Enemy is defending!";
    }

    public virtual void HeavyAttack()
    {
        float tempDamage;

        RandomDamage();

        // Increases damage by a factor of the heavy damage multiplier
        tempDamage = enemyDamage;
        enemyDamage = Mathf.RoundToInt(tempDamage * heavyDamageMult * battleManager.playerDefense);

        // Reduce damage dealt if player is defending
        if (battleManager.isPlayerDefending)
        {
            enemyDamage /= 2;
        }

        battleManager.playerHealth -= enemyDamage;

        battleManager.battleConsoleText.text = "Enemy heavy attack deals " + enemyDamage + " damage!";
    }
    */
}
