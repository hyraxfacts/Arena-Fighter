using UnityEngine;

public abstract class BattleState
{
    protected BattleManager BattleManager;

    public BattleState(BattleManager battleManager)
    {
        BattleManager = battleManager;
    }

    public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}
