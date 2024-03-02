using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private ScoreDisplay _display;
    private void Start()
    {
        _display = FindAnyObjectByType<ScoreDisplay>();    
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Collectibles>())
        {
            if (!collider.gameObject.CompareTag(InteractionType.Coin.ToString())) return;

            Collectibles obj = collider.gameObject.GetComponent<Collectibles>();
            GameManager.Coin += obj.Collector(collider);
            _display.UpdateCoin(GameManager.Coin);
        }
    }
}
