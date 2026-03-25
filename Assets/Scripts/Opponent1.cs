using UnityEngine;

public class Opponent1 : Enemy
{
    private void Start()
    {
        enemyStrength = 10;
        damageRange = 0.3f;
        enemyHealth = 100;

        isAlive = true;
        isDefending = false;
    }
}
