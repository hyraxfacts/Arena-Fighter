using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public bool isPlayerTurn;
    private bool isBattleGoing;
    public int turnCount;

    public TextMeshProUGUI battleConsoleText;
    public TextMeshProUGUI turnIndicatorText;
    public GameObject gameOverScreen;
    public GameObject opponent1;
    public GameObject opponent2;
    public GameObject opponent3;

    public Button attackButton;
    public Button chargeButton;
    public Button magicButton;
    public Button defendButton;

    public Enemy enemy;

    private int playerDamage;
    public int playerStrength;
    public float damageRange;
    private int magicDamage;
    public int magicStrength;
    public float magicDamageRange;
    private bool isMagicCharged;
    public float playerDefense;
    public int playerHealth;

    private void Start()
    {
        turnCount = 0;
        isBattleGoing = true;
        isPlayerTurn = true;
        playerHealth = 100;
        battleConsoleText.text = ("The battle has begun!");

        if (GameManager.Instance.battleStance == 0)
        {
            // Sets player stats for Martial stance
            playerStrength = 20;
            damageRange = 0.15f;
            magicStrength = 30;
            magicDamageRange = 0.6f;
            playerDefense = 0.3f;
        }
        else if (GameManager.Instance.battleStance == 1)
        {
            // Sets player stats for Agility stance
            playerStrength = 10;
            damageRange = 0.3f;
            magicStrength = 30;
            magicDamageRange = 0.6f;
            playerDefense = 0.2f;
        }
        else if (GameManager.Instance.battleStance == 2)
        {
            // Sets player stats for Magic stance
            playerStrength = 5;
            damageRange = 0.5f;
            magicStrength = 50;
            magicDamageRange = 0.2f;
            playerDefense = 0.15f;
        }
        else
        {
            Debug.Log("Invalid battle stance");
        }

        // Loads current opponent
        if (GameManager.Instance.currentStage == 1)
        {
            Instantiate<GameObject>(opponent1, opponent1.transform.position, opponent1.transform.rotation);
        }
        else if (GameManager.Instance.currentStage == 2)
        {
            Instantiate<GameObject>(opponent2, opponent2.transform.position, opponent2.transform.rotation);
        }
        else if (GameManager.Instance.currentStage == 3)
        {
            Instantiate<GameObject>(opponent3, opponent3.transform.position, opponent3.transform.rotation);
        }
        else
        {
            Debug.Log("Stage invalid");
        }
    }


    void Update()
    {
        if (isPlayerTurn)
        {
            turnIndicatorText.text = "Your Turn";

            ActionUIInteractable();
        }
        else
        {
            turnIndicatorText.text = "Opponent's Turn";

            ActionUIUninteractable();
        }

        if (playerHealth <= 0)
        {
            gameOverScreen.SetActive(true);

            ActionUIUninteractable();
        }
    }

    // Generates random damage number based on player stats
    public void RandomDamage()
    {
        int damageMin = (int)Mathf.Round(playerStrength - (playerStrength / damageRange));
        int damageMax = (int)Mathf.Round(playerStrength + (playerStrength / damageRange));

        playerDamage = Random.Range(damageMin, damageMax);
    }

    // Generates random damage number based on magic stats
    public void RandomMagicDamage()
    {
        int damageMin = (int)Mathf.Round(magicStrength - (magicStrength / magicDamageRange));
        int damageMax = (int)Mathf.Round(magicStrength + (magicStrength / magicDamageRange));

        magicDamage = Random.Range(damageMin, damageMax);
    }

    public void Attack()
    {
        if (isPlayerTurn)
        {
            // Rolls for damage
            RandomDamage();

            // Reduce damage dealt if enemy is defending
            if (enemy.isDefending)
            {
                playerDamage /= 2;
            }

            // Enemy takes damage
            enemy.enemyHealth -= playerDamage;

            battleConsoleText.text = ("You deal " + playerDamage + " damage!");

            isPlayerTurn = false;
        }
        else
        {
            Debug.Log("It is not your turn!");
        }
    }

    // Does nothing but allow magic to be used next turn
    public void ChargeMagic()
    {
        if (isPlayerTurn)
        {
            isMagicCharged = true;

            battleConsoleText.text = ("You charge your magic");

            isPlayerTurn = false;
        }
        else
        {
            Debug.Log("It is not your turn!");
        }
    }

    public void MagicAttack()
    {
        if (isPlayerTurn)
        {
            if (isMagicCharged)
            {
                // Rolls for damage
                RandomMagicDamage();

                // Reduce damage dealt if enemy is defending
                if (enemy.isDefending)
                {
                    magicDamage /= 2;
                }

                // Enemy takes damage
                enemy.enemyHealth -= magicDamage;

                battleConsoleText.text = ("You deal " + magicDamage + " damage!");

                // Magic needs to be charged again
                isMagicCharged = false;
            }
            else
            {
                battleConsoleText.text = ("Magic needs to be charged first!");
                Debug.Log("Magic needs to be charged first!");
            }
        }
        else
        {
            Debug.Log("It is not your turn!");
        }
    }

    // Increases defense
    // Needs to be turned off before next turn
    public void Defend()
    {
        if (isPlayerTurn)
        {
            playerDefense = 0.95f;
            battleConsoleText.text = ("You defend!");

            isPlayerTurn = false;
        }
        else
        {
            Debug.Log("It is not your turn!");
        }
    }

    // Turns on action buttons
    private void ActionUIInteractable()
    {
        attackButton.interactable = true;
        chargeButton.interactable = true;
        defendButton.interactable = true;
        
        // Keeps the magic button off if magic is not charged
        if (isMagicCharged)
        {
            magicButton.interactable = true;
        }    
    }

    // Turns off action buttons
    private void ActionUIUninteractable()
    {
        attackButton.interactable = false;
        chargeButton.interactable = false;
        magicButton.interactable = false;
        defendButton.interactable = false;
    }
}
