using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Save!");
            GameManager.SavePoint = new Vector2(transform.position.x, transform.position.y + 3);
        }
    }
}
