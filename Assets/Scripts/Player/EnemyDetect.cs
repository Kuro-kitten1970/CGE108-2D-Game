using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    private ScoreDisplay display;

    private void Start()
    {
        display = FindAnyObjectByType<ScoreDisplay>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy == null) return;

        if (enemy.GetComponent<Slime>() == null)
        {
            enemy.Attack(collision);
            display.UpdateHealth(GameManager.PlayerHealth);
            return;
        }

        enemy.Attack(collision, collision.otherRigidbody);
        display.UpdateHealth(GameManager.PlayerHealth);
    }
}
