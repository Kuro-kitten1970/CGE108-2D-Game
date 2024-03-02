using UnityEngine;

public interface IEnemy
{
    public void Attack(Collision2D collision, Rigidbody2D rigidbody);
    public void Attack(Collision2D collision);
}
