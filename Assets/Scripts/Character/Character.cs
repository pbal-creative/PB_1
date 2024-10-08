using System;
using UnityEditor.Animations;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void UpdateDirection(ref Vector2 direction)
    {
        Vector2 scale;
        if (direction.x > 0)
        {
            scale = Vector2.one;
        }
        else
        {
            scale = new Vector2(-1, 1);
        }

        transform.localScale = scale;
    }

    public void UpdateMovement(Vector2 position)
    {
        transform.Translate(position);
    }

    public bool CompareAnimationNameHash(int nameHash)
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