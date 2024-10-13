using System;
using GHashes;
using UnityEditor.Animations;
using UnityEngine;

// It is shared class between Player and NonPlayer.
public class BaseCharacterController : MonoBehaviour
{
    protected Rigidbody2D _rigidBody;
    protected SpriteRenderer _spriteRenderer;
    protected Animator _animator;
    
    [SerializeField]
    protected Stats _stats;
    
    protected Vector2 _direction;
    protected float _jumpForce = 1.0f;

    protected virtual void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        
        _stats = new Stats();
        _direction = new Vector2();
    }

    public void UpdateDirection()
    {
        if (_direction.x != 0)
        {
            Vector2 scale;
            if (_direction.x > 0)
            {
                scale = Vector2.one;
            }
            else
            {
                scale = new Vector2(-1, 1);
            }

            transform.localScale = scale;
        }
    }
    
    void FixedUpdate()
    {
        UpdateMovement();
        UpdateDirection();
    }

    public void UpdateMovement()
    {
        SetAnimatorFloat(GStatNameHashes.MOVE_SPEED, _direction.magnitude * _stats.speed);
        _rigidBody.linearVelocityX = _direction.x * _stats.speed;
        
        Logger.Log($"UpdateMovement() direction: {_direction.magnitude}");
    }

    public bool IsAnimationPlaying(int nameHash)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).shortNameHash == nameHash;
    }

    public void SetAnimatorTrigger(int nameHash)
    {
        _animator.SetTrigger(nameHash);
    }

    public void SetAnimatorFloat(int nameHash, float value)
    {
        _animator.SetFloat(nameHash, value);
    }
}