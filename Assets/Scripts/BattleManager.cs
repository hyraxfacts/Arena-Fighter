using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public BattleState CurrentState { get; private set; }
    public PlayerTurnState PlayerTurnState { get; private set; }
    public EnemyTurnState EnemyTurnState { get; private set; }

    public Button attackButton;
    public Button chargeButton;
    public Button magicButton;
    public Button defendButton;

    [SerializeField]
    private GameObject[] opponent;
    public GameObject currentOpponent;


    private void Start()
    {
        // Initialize all states
        PlayerTurnState = new PlayerTurnState(this);
        EnemyTurnState = new EnemyTurnState(this);

        currentOpponent = opponent[GameManager.Instance.stagesCleared];

        Debug.Log("BattleManager is spawning the enemy.");
        // Loads current opponent
        currentOpponent.SetActive(true);

        // Start the battle
        ChangeState(PlayerTurnState);

    }

    void Update()
    {
        // We must update the current state every frame
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
