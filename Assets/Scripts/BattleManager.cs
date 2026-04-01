using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public bool isPlayerTurn;
    public bool isBattleActive;

    public int turnCount;

    public TextMeshProUGUI turnIndicatorText;
    public TextMeshProUGUI battleConsoleText;
    public GameObject gameOverScreen;

    public GameObject victoryScreen;
    public GameObject[] opponent;
    public GameObject currentOpponent;

    public Button attackButton;
    public Button chargeButton;
    public Button magicButton;
    public Button defendButton;

    public bool isEnemyDefending;

    private int playerDamage;

    public int playerStrength;
    public float damageRange;
    private int magicDamage;
    public int magicStrength;
    public float magicDamageRange;
    private bool isMagicCharged;
    public float playerDefense;
    public int playerHealth;
    public int enemyHealth;
    public bool hasWon;


    private void Start()
    {
        turnCount = 0;

        isBattleActive= true;
        isPlayerTurn = true;
        hasWon = false;
        playerHealth = 100;
        enemyHealth = 100;
        battleConsoleText.text = ("The battle has begun!");

        currentOpponent = opponent[GameManager.Instance.stagesCleared];

        if (GameManager.Instance.battleStance == 0)
        {
            // Sets player stats for Martial stance
            playerStrength = 25;
            damageRange = 0.15f;
            magicStrength = 30;
            magicDamageRange = 0.3f;
            playerDefense = 0.8f;
        }
        else if (GameManager.Instance.battleStance == 1)
        {
            // Sets player stats for Balanced stance
            playerStrength = 17;
            damageRange = 0.25f;
            magicStrength = 40;
            magicDamageRange = 0.4f;
            playerDefense = 0.9f;
        }
        else if (GameManager.Instance.battleStance == 2)
        {
            // Sets player stats for Magic stance
            playerStrength = 10;
            damageRange = 0.3f;
            magicStrength = 50;
            magicDamageRange = 0.5f;
            playerDefense = 0.95f;
        }
        else
        {
            Debug.Log("Invalid battle stance");
        }

        // Loads current opponent
        Instantiate<GameObject>(currentOpponent, currentOpponent.transform.position, currentOpponent.transform.rotation);

        if (GameManager.Instance.currentStage > opponent.Length)
        {
            Debug.Log("Invalid stage");
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
            isBattleActive = false;
            gameOverScreen.SetActive(true);

            GameManager.Instance.stagesCleared = 0;
            GameManager.Instance.UpdateCurrentStage();

            ActionUIUninteractable();
        }

        // hasWon insures victory only happens once
        if (enemyHealth <= 0 && !hasWon)
        {
            Victory();
        }
    }
     
    // Generates random damage number based on player stats
    public void RandomDamage()
    {
        int damageMin = (int)Mathf.Round(playerStrength - (playerStrength * damageRange));
        int damageMax = (int)Mathf.Round(playerStrength + (playerStrength * damageRange));

        playerDamage = Random.Range(damageMin, damageMax);
    }

    // Generates random damage number based on magic stats
    public void RandomMagicDamage()
    {
        int damageMin = (int)Mathf.Round(magicStrength - (magicStrength * magicDamageRange));
        int damageMax = (int)Mathf.Round(magicStrength + (magicStrength * magicDamageRange));

        magicDamage = Random.Range(damageMin, damageMax);
    }

    public void Attack()
    {
        if (isPlayerTurn && isBattleActive)
        {

            // Rolls for damage
            RandomDamage();

            // Reduce damage dealt if enemy is defending
            if (isEnemyDefending)
            {
                playerDamage /= 2;
            }

            // Enemy takes damage
            enemyHealth -= playerDamage;

            battleConsoleText.text = ("You deal " + playerDamage + " damage!");

            isPlayerTurn = false;
        }
        else
        {
            Debug.Log("It is not your turn!");
        }
    }

    public void Charge()
    {
        if (isPlayerTurn && isBattleActive)
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
                if (isEnemyDefending)
                {
                    magicDamage /= 2;
                }

                // Enemy takes damage
                enemyHealth -= magicDamage;

                battleConsoleText.text = ("You deal " + magicDamage + " damage!");

                // Magic needs to be charged again
                isMagicCharged = false;

                isPlayerTurn = false;
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

    private void Victory()
    {
        isBattleActive = false;
        victoryScreen.SetActive(true);

        GameManager.Instance.stagesCleared += 1;
        GameManager.Instance.UpdateCurrentStage();

        ActionUIUninteractable();

        hasWon = true;
    }
}
