using UnityEngine;

public class Collectibles : MonoBehaviour, ICollectible
{
    public float Collector(Collider2D collider)
    {
        Destroy(collider.gameObject);
        return 1;
    }
}
