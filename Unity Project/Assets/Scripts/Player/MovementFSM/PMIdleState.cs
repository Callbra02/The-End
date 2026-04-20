using UnityEngine;

public class PMIdleState : PMState
{
    public PMIdleState(PlayerMovementFSM _stateMachine) : base(_stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        PMState stateInputCheck = stateMachine.CheckInput();
        
        if (stateInputCheck != null)
        {
            stateMachine.ChangeState(stateInputCheck);
        }
    }

    public override void FixedExecute()
    {
        
    }

    public override void Exit()
    {
        
    }
}
