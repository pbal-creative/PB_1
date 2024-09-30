using System;
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
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 direction = _move.ReadValue<Vector2>();
        transform.Translate(new Vector2(1, 0) * direction * speed * Time.fixedDeltaTime);
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
}