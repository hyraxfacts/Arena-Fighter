using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public BattleState CurrentState { get; private set; }
    public PlayerTurnState PlayerTurnState { get; private set; }
    public EnemyTurnState EnemyTurnState { get; private set; }

    public int turnCount;

    public bool isBattleActive;

    public Button attackButton;
    public Button chargeButton;
    public Button magicButton;
    public Button defendButton;

    [SerializeField]
    private GameObject[] opponent;
    public GameObject currentOpponent { get; private set; }
    public Unit enemyUnit { get; private set; }

    [SerializeField]
    private GameObject[] player;
    public GameObject playerCurrentStance { get; private set; }
    public Unit playerUnit { get; private set; }

    public GameObject playerTurnIndicator;
    public GameObject enemyTurnIndicator;

    [SerializeField]
    private GameObject gameOverScreen;
    private bool isGameOverActive = false;

    [SerializeField]
    private GameObject victoryScreen;
    private bool isVictoryActive = false;


    private void Start()
    {
        // Initialize all states
        PlayerTurnState = new PlayerTurnState(this);
        EnemyTurnState = new EnemyTurnState(this);

        turnCount = 0;

        currentOpponent = opponent[GameManager.Instance.stagesCleared];
        // Loads current opponent
        currentOpponent.SetActive(true);
        enemyUnit = currentOpponent.GetComponent<Unit>();

        playerCurrentStance = player[GameManager.Instance.battleStance];
        // Loads player's chosen stance
        playerCurrentStance.SetActive(true);
        playerUnit = playerCurrentStance.GetComponent<Unit>();

        // Start the battle
        ChangeState(PlayerTurnState);
    }

    void Update()
    {
        // Checks for lose condition
        if (playerUnit.currentHP <= 0 && isGameOverActive == false)
        {
            Defeat();
        }
        
        // Checks for victory condition
        if (enemyUnit.currentHP <= 0 && isVictoryActive == false)
        {
            Victory();
        }    

        // Updates the current state every frame
        CurrentState?.OnUpdate();
    }

    public void ChangeState(BattleState newState)
    {
        // Call OnExit on the current state before switching
        CurrentState?.OnExit();

        // Switch to the new state
        CurrentState = newState;

        // Call OnEnter on the new state
        CurrentState.OnEnter();
    }

    private void Defeat()
    {
        isBattleActive = false;
        gameOverScreen.SetActive(true);

        // Resets stages cleared
        GameManager.Instance.stagesCleared = 0;
        GameManager.Instance.UpdateCurrentStage();

        // Makes sure this method only happens once
        isGameOverActive = true;

    }

    private void Victory()
    {
        isBattleActive = false;
        victoryScreen.SetActive(true);

        // Updates the stages cleared
        GameManager.Instance.stagesCleared += 1;
        GameManager.Instance.UpdateCurrentStage();

        // Makes sure this method only happens once
        isVictoryActive = true;
    }
}
