using GHashes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Stat _stat;
    private Character _character;
    private InputSystem_Actions _inputActions;

    private Vector2 _direction;

    void Awake()
    {
        _stat = new Stat();
        _character = GetComponent<Character>();
        _direction = Vector2.zero;

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
        _inputActions.Player.BowAttack.performed += OnBowAttack;
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
    }

    private void OnStopMove(InputAction.CallbackContext context)
    {
        _direction = Vector2.zero;
    }
    
    private void OnAttack1(InputAction.CallbackContext context)
    {
        _character.SetAnimatorTrigger(GCharacterNameHashes.ATTACK_1);
    }

    private void OnAttack2(InputAction.CallbackContext context)
    {
        _character.SetAnimatorTrigger(GCharacterNameHashes.ATTACK_2);
    }

    private void OnBowAttack(InputAction.CallbackContext context)
    {
        _character.SetAnimatorTrigger(GCharacterNameHashes.BOW_ATTACK);
    }

    private void OnDamaged()
    {
        _character.SetAnimatorTrigger(GCharacterNameHashes.DAMAGED);
    }

    private void OnDeath()
    {
        _character.SetAnimatorTrigger(GCharacterNameHashes.DEATH);
    }

    void FixedUpdate()
    {
        if (_character.CompareAnimationNameHash(GCharacterNameHashes.WALK))
        {
            _character.UpdateMovement(new Vector2(1, 0) * _direction * _stat.speed * Time.fixedDeltaTime);
        }
    }

    void LateUpdate()
    {
        _character.SetAnimatorFloat(GStatNameHashes.SPEED, _direction.magnitude);
        if (_direction.x != 0)
        {
            _character.UpdateFlipX(_direction.x > 0 ? false : true);
        }
    }
}
