using UnityEngine;

public class Slime : EnemyBehavior
{
    private SpriteRenderer _sprite;
    private Animator _animator;
    private Rigidbody2D _slime;
    private ObjectsTranform _tranform;

    private void Awake()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
        _slime = gameObject.GetComponent<Rigidbody2D>();
        _tranform = GetComponent<ObjectsTranform>();
    }

    private void Update()
    {
        _sprite.flipX =! _tranform._isGoingOpposite;
    }

    public bool CheckPlayerHit(Collision2D collision, Rigidbody2D rigidbody)
    {
        ContactPoint2D contact = collision.GetContact(0);

        Debug.Log(Vector2.Dot(contact.normal, Vector2.up));
        if (Vector2.Dot(contact.normal, Vector2.up) >= 0.9f && rigidbody.gameObject.CompareTag("Player"))
        {
            _tranform._isStop = true;
            _animator.SetTrigger("IsDead");
            Invoke(nameof(DestroySlime), 3f);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DestroySlime() => Destroy(gameObject);
}
