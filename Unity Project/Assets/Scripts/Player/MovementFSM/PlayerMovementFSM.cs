using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementFSM : MonoBehaviour
{
    public InputActionReference moveAction;
    public InputActionReference crouchAction;
    public InputActionReference jumpAction;
    
    public Rigidbody2D playerRigidbody2D;
    
    private PMState _currentState;

    public TextMeshProUGUI playerStateText;
    
    public float jumpHeight = 2.0f;
    public float moveSpeed = 5.0f;

    private void Awake()
    {
        playerRigidbody2D  = GetComponent<Rigidbody2D>();
        _currentState = new PMIdleState(this);
    }

    public void ChangeState(PMState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.Execute();
            playerStateText.text = _currentState.ToString();
        }
    }

    public void FixedUpdate()
    {
        if (_currentState != null)
        {
            _currentState.FixedExecute();
        }
    }

    /// <summary>
    /// Returns true if registering player input
    /// </summary>
    /// <returns></returns>
    public PMState CheckInput()
    {
        if (playerRigidbody2D.linearVelocity.magnitude == 0)
        {
            return null;
        }
        if (moveAction.action.WasPressedThisFrame())
        {
            return new PMSprintState(this);
        }
        
        if (jumpAction.action.WasPressedThisFrame())
        {
            return new PMJumpState(this);
        }
        
        if (crouchAction.action.WasPressedThisFrame())
        {
            return new PMCrouchState(this);
        }

        return null;
    }

    public void IdleStateCheck()
    {
        PMState stateInputCheck = CheckInput();
        
        if (stateInputCheck == null)
        {
            ChangeState(new PMIdleState(this));
        }
    }
}
