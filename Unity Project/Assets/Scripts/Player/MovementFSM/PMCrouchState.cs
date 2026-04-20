using UnityEngine;

public class PMCrouchState : PMState
{
    public PMCrouchState(PlayerMovementFSM _stateMachine) : base(_stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        stateMachine.IdleStateCheck();
    }

    public override void FixedExecute()
    {
        
    }

    public override void Exit()
    {
        
    }

}
