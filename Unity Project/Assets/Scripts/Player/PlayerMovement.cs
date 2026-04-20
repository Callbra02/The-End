using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input")] 
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _crouchAction;
    [SerializeField] private InputActionReference _jumpAction;
    [SerializeField] private InputActionReference _sprintAction;
    
    [Header("Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityMultiplier;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    
    private Vector2 _wishVelocity;
    private Vector2 _moveInput;
    private Vector2 _defaultColliderSize;
    private Vector2 _defaultColliderOffset;
    private float crouchHeightMultiplier = 0.5f;

    private bool _isGrounded = false;
    private bool _doJump = false;
    private bool _isCrouching = false;
    public bool canMove = true;

    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        _crouchAction.action.started += ctx => _isCrouching = true;
        _crouchAction.action.canceled += ctx => _isCrouching = false;
        
        //_defaultColliderSize = _collider.size;
        //_defaultColliderOffset = _collider.offset;
        
    }

    private void Update()
    {
        HandleInput();
        CheckGround();
        HandleJump();
        HandleCrouch();
        HandleSprint();
    }

    private void HandleInput()
    {
        _moveInput = Vector2.zero;
        _moveInput = _moveAction.action.ReadValue<Vector2>();
    }
    
    private void FixedUpdate()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        if (!canMove)
        {
            _rigidbody.linearVelocity = new Vector2(0.0f, _rigidbody.linearVelocity.y);
            return;
        }

        _wishVelocity = new Vector2(_moveInput.x * _moveSpeed * Time.deltaTime, _rigidbody.linearVelocity.y);
        
        _rigidbody.linearVelocity = _wishVelocity;

        if (_doJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _doJump = false;
        }
    }

    private void HandleCrouch()
    {
        if (!_isGrounded)
        {
            return;
        }

        if (_isCrouching)
        {
            canMove = false;
            //_collider.size = new Vector2(_defaultColliderSize.x, _defaultColliderSize.y * crouchHeightMultiplier);
            //_collider.offset = new Vector2(_defaultColliderOffset.x, -0.79086f);
        }
        else
        {
            canMove = true;
            //_collider.size = _defaultColliderSize;
            //_collider.offset = _defaultColliderOffset;
        }
    }

    private void HandleJump()
    {
        if (!_isGrounded)
        {
            return;
        }

        if (_jumpAction.action.WasPressedThisFrame())
        {
            _doJump = true;
        }
    }

    private void HandleSprint()
    {
        
    }

    private void CheckGround()
    {
        _isGrounded = _rigidbody.linearVelocity.y == 0;

        if (!_isGrounded)
        {
            _wishVelocity.y -= (float)9.15 * _gravityMultiplier * Time.deltaTime;
        }
    }
    
}
