using UnityEngine;

public class Enemy : EnemyBehavior, IEnemy
{
    private Slime slime;

    public void Attack(Collision2D collision, Rigidbody2D rigidbody)
    {
        slime = collision.gameObject.GetComponent<Slime>();

        if (slime != null && slime.CheckPlayerHit(collision, rigidbody)) return;

        GameManager.PlayerGotAttack();

        if (GameManager.IsDead) return;

        BackToSavePoint();
    }

    public void Attack(Collision2D collision)
    {
        GameManager.PlayerGotAttack();

        if (GameManager.IsDead) return;

        BackToSavePoint();
    }
}
