using System;
using UnityEngine;

public class Ground : Character
{
    public bool OnGround { get; private set; }
    public float Friction { get; private set; }
    private bool start = true;

    private Vector2 _normal;
    private PhysicsMaterial2D _material;

    private void Awake()
    {
        Initialization();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnGround = false;
        Friction = 0;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        if (start)
        {
            start = false;
            return;
        }
        if (OnGround)
        {
            _animator.SetTrigger("JumpExit");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
    }

    private void EvaluateCollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            _normal = collision.GetContact(i).normal;
            OnGround |= _normal.y >= 0.1f;
        }
    }

    private void RetrieveFriction(Collision2D collision)
    {
        _material = collision.rigidbody.sharedMaterial;

        Friction = 0;

        if(_material != null)
        {
            Friction = _material.friction;
        }
    }
}

