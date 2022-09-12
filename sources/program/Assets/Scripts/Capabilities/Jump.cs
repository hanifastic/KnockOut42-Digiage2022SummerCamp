using System;
using UnityEngine;


public class Jump : Character
{
    [SerializeField, Range(0f, 10f)] private float _jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int _maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float _downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float _upwardMovementMultiplier = 1.7f;

    private CharacterInputController _controller;
    private WallSlideAndJump _wallSlide;
    private Rigidbody2D _body;
    private Ground _ground;
    private Vector2 _velocity;

    public int _jumpPhase;
    private float _defaultGravityScale, _jumpSpeed;

    public bool _desiredJump, _onGround;


    // Start is called before the first frame update
    void Awake()
    {
        Initialization();
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
        _controller = GetComponent<CharacterInputController>();
        _wallSlide = GetComponent<WallSlideAndJump>();

        _defaultGravityScale = 1f;
    }
    

    private void FixedUpdate()
    {
        _onGround = _ground.OnGround;
        _velocity = _body.velocity;

        if (_onGround)
        {
            _animator.SetTrigger("Ground");
            _jumpPhase = 0;
        }

        if (_desiredJump)
        {
            _animator.SetTrigger("Jump");
            if (_wallSlide.isWallSliding) _velocity =_wallSlide.WallJump(_velocity);
            else
            {
                _desiredJump = false;
                JumpAction();
            }

            _desiredJump = false;
        }

        if (_body.velocity.y > 0)
        {
            _body.gravityScale = _upwardMovementMultiplier;
        }
        else if (_body.velocity.y < 0)
        {
            _body.gravityScale = _downwardMovementMultiplier;
        }
        else if(_body.velocity.y == 0)
        {
            _body.gravityScale = _defaultGravityScale;
        }

        _body.velocity = _velocity;
    }
    private void JumpAction()
    {
        if (_onGround || _jumpPhase < _maxAirJumps)
        {
            _jumpPhase += 1;
            
            _jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * _jumpHeight);
            
            if (_velocity.y > 0f)
            {
                _jumpSpeed = Mathf.Max(_jumpSpeed - _velocity.y, 0f);
            }
            else if (_velocity.y < 0f)
            {
                _jumpSpeed += Mathf.Abs(_body.velocity.y);
            }
            _velocity.y += _jumpSpeed;
        }
    }
}


