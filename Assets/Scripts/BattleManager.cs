using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private bool isPlayerTurn;
    private bool isBattleGoing;
    public int turnCount;

    public TextMeshProUGUI turnIndicatorText;
    public GameObject gameOverScreen;

    public Enemy enemy;

    private int playerDamage;

    private void Start()
    {
        turnCount = 0;
        isBattleGoing = true;
    }


    void Update()
    {
        if (isPlayerTurn)
        {
            turnIndicatorText.text = "Your Turn";
        }
        else
        {
            turnIndicatorText.text = "Opponent's Turn";
        }

        if (!isBattleGoing)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void RandomDamage()
    {
        playerDamage = Random.Range(10, 20);
    }

    public void Attack()
    {
        RandomDamage();

        if (enemy.isDefending)
        {
            playerDamage /= 2;
        }

        enemy.enemyHealth -= playerDamage;

    }
}
