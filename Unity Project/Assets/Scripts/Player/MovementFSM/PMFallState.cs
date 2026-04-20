using UnityEngine;

public class PMFallState : PMState
{
    public PMFallState(PlayerMovementFSM _stateMachine) : base(_stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        if (stateMachine.playerRigidbody2D.linearVelocity.y == 0)
        {
            stateMachine.ChangeState(new PMIdleState(stateMachine));
        }
        stateMachine.IdleStateCheck();
    }

    public override void FixedExecute()
    {
        
    }

    public override void Exit()
    {
        
    }
}
