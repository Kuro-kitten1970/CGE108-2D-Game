using UnityEngine;

public class WinCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameManager.IsWin = true;
            GameEventBus.Publish(GameEventsType.FINISH);
        }
    }
}
