using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Character Properties")]
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;

    [Header("Other Properties")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rb2D;
    private GroundChecker _groundChecker;
    private Animator _animator;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("isGrounded", _groundChecker.isGrounded);
        _animator.SetBool("isJump", !_groundChecker.isGrounded);
        _animator.SetBool("isFalling", _rb2D.velocity.y < 0);

        JumpHandler();
    }

    private void FixedUpdate()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        float x = Input.GetAxis("Horizontal") * _walkSpeed;

        _spriteRenderer.flipX = x < 0 || (x <= 0 && _spriteRenderer.flipX);

        if (x != 0) 
        {
            _animator.SetBool("isRun", true);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }

        _rb2D.velocity = new Vector2(x, _rb2D.velocity.y);
    }

    private void JumpHandler()
    {
        if (!_groundChecker.isGrounded)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x , _rb2D.velocity.y);
            return;
        }

        if (Input.GetButton("Jump"))
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce);
        }
    }
}
