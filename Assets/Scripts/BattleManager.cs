using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BattleState CurrentState { get; private set; }
    public PlayerTurnState PlayerTurnState { get; private set; }
    public EnemyTurnState EnemyTurnState { get; private set; }


    private void Start()
    {
        // Initialize all states
        PlayerTurnState = new PlayerTurnState(this);
        EnemyTurnState = new EnemyTurnState(this);

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
