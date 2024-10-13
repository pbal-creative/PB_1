using GHashes;
using UnityEngine;
using UnityEngine.InputSystem;

// Based on player's input
public class PlayerController : BaseCharacterController
{
    private InputSystem_Actions _inputActions;

    protected override void Awake()
    {
        base.Awake();
        
        InitInput();
        EnableInput(true);
    }

    private void InitInput()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled += OnStopMove;
        _inputActions.Player.Attack1.performed += OnAttack1;
        _inputActions.Player.Attack2.performed += OnAttack2;
        _inputActions.Player.Jump.performed += OnJump;
    }

    private void EnableInput(bool enable)
    {
        if (enable == true)
        {
            _inputActions.Enable();
        }
        else
        {
            _inputActions.Disable();
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
        Logger.Log($"OnMove() direction: {_direction.magnitude}");
    }

    private void OnStopMove(InputAction.CallbackContext context)
    {
        _direction = Vector2.zero;
        Debug.Log($"OnStopMove() direction: {_direction.magnitude}");
    }
    
    private void OnAttack1(InputAction.CallbackContext context)
    {
        SetAnimatorTrigger(GCharacterNameHashes.SLASH_ATTACK_1);
    }

    private void OnAttack2(InputAction.CallbackContext context)
    {
        SetAnimatorTrigger(GCharacterNameHashes.SLASH_ATTACK_2);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        //SetAnimatorTrigger(GCharacterNameHashes.SPIN_ATACK);
    }

    private void OnDamaged()
    {
        SetAnimatorTrigger(GCharacterNameHashes.DAMAGED);
    }

    private void OnDeath()
    {
        SetAnimatorTrigger(GCharacterNameHashes.DEATH);
    }

    void Update()
    {
        bool isJumpPressed = _inputActions.Player.Jump.ReadValue<float>() > 0.01f ? true : false;
        bool isDashPressed = _inputActions.Player.Dash.ReadValue<float>() > 0.01f ? true : false;
        bool isRollPressed = _inputActions.Player.Roll.ReadValue<float>() > 0.01f ? true : false;

        if (isJumpPressed)
        {
            _rigidBody.AddForceY(_jumpForce, ForceMode2D.Impulse);
        }
    }

    void LateUpdate()
    {
       
    }
}
