using UnityEngine;

public abstract class PMState
{
    public PlayerMovementFSM stateMachine;

    protected PMState(PlayerMovementFSM _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void FixedExecute();
    public abstract void Exit();
}
