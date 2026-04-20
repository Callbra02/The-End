using UnityEngine;

public class PMJumpState : PMState
{
    public PMJumpState(PlayerMovementFSM _stateMachine) : base(_stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Execute()
    {

        if (stateMachine.jumpAction.action.WasPressedThisFrame())
        {
            stateMachine.playerRigidbody2D.AddForce(stateMachine.transform.up * stateMachine.jumpHeight, ForceMode2D.Impulse);
        }

        if (stateMachine.playerRigidbody2D.linearVelocity.y < 0)
        {
            stateMachine.ChangeState(new PMFallState(stateMachine));
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
