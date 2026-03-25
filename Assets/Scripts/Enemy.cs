using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public bool isAlive;
    public bool isDefending;
    public int enemyStrength;
    public int enemyDamage;
    public float damageRange;
    public BattleManager battleManager;

    public virtual void EnemyTurn()
    {
        if (battleManager.turnCount % 2 == 0)
        {
            Attack();
        }
        else
        {
            Defend();
        }
    }

    public void HealthCheck()
    {
        if (enemyHealth <= 0)
        {
            isAlive = false;
        }
    }

    protected void RandomDamage()
    {
        int damageMin = (int)Mathf.Round(enemyStrength - (enemyStrength / damageRange));
        int damageMax = (int)Mathf.Round(enemyStrength + (enemyStrength / damageRange));

        enemyDamage = Random.Range(damageMin, damageMax);
    }

    protected virtual void Attack()
    {
        RandomDamage();
    }

    protected virtual void Defend()
    {
        isDefending = true;
    }
}
