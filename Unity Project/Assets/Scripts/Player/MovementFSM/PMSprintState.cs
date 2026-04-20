using UnityEngine;

public class PMSprintState : PMState
{
    public PMSprintState(PlayerMovementFSM _stateMachine) : base(_stateMachine) { }

    private Vector2 movement;
    
    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        Vector2 playerInput = stateMachine.moveAction.action.ReadValue<Vector2>();
        
        movement = playerInput * stateMachine.moveSpeed * Time.deltaTime;
        
        
        stateMachine.IdleStateCheck();
    }

    public override void FixedExecute()
    {
        stateMachine.playerRigidbody2D.linearVelocity = new Vector2(movement.x, stateMachine.playerRigidbody2D.linearVelocity.y);
    }
    
    public override void Exit()
    {
        
    }
}
