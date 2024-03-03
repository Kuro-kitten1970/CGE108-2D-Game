using UnityEngine;

public class Slime : EnemyBehavior
{
    private SpriteRenderer _sprite;
    private Animator _animator;
    private Rigidbody2D _slime;
    private ObjectsTranform _tranform;
    private ScoreDisplay _display;

    private void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
        _slime = gameObject.GetComponent<Rigidbody2D>();
        _tranform = GetComponent<ObjectsTranform>();
        _display = FindAnyObjectByType<ScoreDisplay>();
    }

    private void Update()
    {
        if (_tranform.GetXDirection < 0)
        {
            _sprite.flipX = _tranform._isGoingOpposite;
        }
        else
        {
            _sprite.flipX =! _tranform._isGoingOpposite;
        }
    }

    public bool CheckPlayerHit(Collision2D collision, Rigidbody2D rigidbody)
    {
        ContactPoint2D contact = collision.GetContact(0);

        if (Vector2.Dot(contact.normal, Vector2.up) >= 0.875f && rigidbody.gameObject.CompareTag("Player"))
        {
            _tranform._isStop = true;
            _animator.SetTrigger("IsDead");

            Destroy(gameObject.GetComponent<Collider2D>());
            Destroy(_slime);
            Invoke(nameof(DestroySlime), 3f);

            GameManager.Score += 500;
            _display.UpdateScore(GameManager.Score);

            return true;
        }
        else
        {
            return false;
        }
    }

    private void DestroySlime() => Destroy(gameObject);
}
