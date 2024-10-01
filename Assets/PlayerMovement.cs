using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float speed = 1.0f;
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private InputSystem_Actions _inputActions;
    private InputAction _move;
    private InputAction _attack1;
    private InputAction _attack2;
    private InputAction _bowAttack;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        InitInput();
        EnableInput(true);
    }

    private void InitInput()
    {
        _inputActions = new InputSystem_Actions();
        _move = _inputActions.Player.Move;
        _attack1 = _inputActions.Player.Attack1;
        _attack2 = _inputActions.Player.Attack2;
        _bowAttack = _inputActions.Player.BowAttack;
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

    void FixedUpdate()
    {
        UpdateMovement();
        UpdateAttack();
    }

    private void UpdateMovement()
    {
        // It need to check current animation is walking for preventing moving on atack.
        // After implementing state machine, it should be refactored.
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Walk_Soldier"))
        {
            Vector2 direction = _move.ReadValue<Vector2>();
            transform.Translate(new Vector2(1, 0) * direction * speed * Time.fixedDeltaTime);
        }
    }

    private void UpdateAttack()
    {
        float attack1 = _attack1.ReadValue<float>();
        if (attack1 > 0)
        {
            _animator.SetTrigger("Attack1");
        }

        float attack2 = _attack2.ReadValue<float>();
        if (attack2 > 0)
        {
            _animator.SetTrigger("Attack2");
        }

        float bowAttack = _bowAttack.ReadValue<float>();
        if (bowAttack > 0)
        {
            _animator.SetTrigger("BowAttack");
        }
    }

    void LateUpdate()
    {
        Vector2 direction = _move.ReadValue<Vector2>();

        _animator.SetFloat("Speed", direction.magnitude);

        if (direction.x != 0)
        {
            _spriteRenderer.flipX = direction.x > 0 ? false : true;
        }
    }

    private void OnAttack1()
    {
        _animator.SetTrigger("Attack1");
    }

    private void OnAttack2()
    {
        _animator.SetTrigger("Attack2");
    }

    private void OnBowAttack()
    {
        _animator.SetTrigger("BowAttack");
    }

    private void OnDamaged()
    {
        _animator.SetTrigger("Damaged");
    }

    private void OnDeath()
    {
        _animator.SetTrigger("Death");
    }
}