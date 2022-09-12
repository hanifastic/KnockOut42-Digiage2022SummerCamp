using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideAndJump : Character
{
    private bool facingRight = true;

    [Header("For WallSliding")]
    [SerializeField] float wallSlideSpeed;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Vector2 wallCheckSize;
    public bool isTouchingWall;
    public bool isWallSliding;

    [Header("For WallJumping")]
    [SerializeField] float walljumpforce;
    [SerializeField] Vector2 walljumpAngle;
    [SerializeField] float walljumpDirection = -1;
    private Jump _jumped;
    private Rigidbody2D rb;

    private Ground _ground;
    private new void Start()
    {
        Initialization();
        _jumped = GetComponent<Jump>();
        walljumpAngle.Normalize();
        rb = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
    }

    private void Update()
    {
        CheckWorld();
    }

    private void CheckWorld()
    {
        isTouchingWall = Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, wallLayer);
        if (isTouchingWall) _jumped._jumpPhase = 0;
    }

    private void FixedUpdate()
    {
        if (_CharacterController.HorizontalMovement<0 && facingRight)
        {
            Flip();
        }
        else if (_CharacterController.HorizontalMovement > 0 && !facingRight)
        {
            Flip();
        }
        WallSlide();
    }
    void WallSlide()
    {
        if (isTouchingWall && !_ground.OnGround && rb.velocity.y<0 )
        {
            isWallSliding = true;
            _animator.SetTrigger("Slide");
        }
        else
        {
            //_animator.SetTrigger("Jump");
            isWallSliding = false;
        }
        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }
    }
    
    public Vector2 WallJump(Vector2 velocity)
    {
        if ((isWallSliding) && _jumped._desiredJump)
        {
            velocity += new Vector2(rb.velocity.x + (walljumpforce * walljumpAngle.x * walljumpDirection),
                rb.velocity.y + (walljumpforce * walljumpAngle.y));
            Flip();
            _animator.SetTrigger("Jump");
        }

        return velocity;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);

    }
    
    void Flip()
    {
        walljumpDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);


    }
}
