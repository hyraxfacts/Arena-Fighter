using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public BattleState CurrentState { get; private set; }
    public PlayerTurnState PlayerTurnState { get; private set; }
    public EnemyTurnState EnemyTurnState { get; private set; }

    public int turnCount;

    public Button attackButton;
    public Button chargeButton;
    public Button magicButton;
    public Button defendButton;

    [SerializeField]
    private GameObject[] opponent;
    public GameObject currentOpponent;

    [SerializeField]
    private GameObject[] player;
    public GameObject playerCurrentStance;


    private void Start()
    {
        // Initialize all states
        PlayerTurnState = new PlayerTurnState(this);
        EnemyTurnState = new EnemyTurnState(this);

        turnCount = 0;

        currentOpponent = opponent[GameManager.Instance.stagesCleared];

        Debug.Log("BattleManager is spawning the enemy.");
        // Loads current opponent
        Instantiate<GameObject>(currentOpponent, currentOpponent.transform.position, currentOpponent.transform.rotation);

        playerCurrentStance = player[GameManager.Instance.battleStance];
        //Loads player's chosen stance
        Instantiate<GameObject>(playerCurrentStance, playerCurrentStance.transform.position, playerCurrentStance.transform.rotation);

        // Start the battle
        ChangeState(PlayerTurnState);

    }

    void Update()
    {
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
}
