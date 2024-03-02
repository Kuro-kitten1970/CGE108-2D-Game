using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private PlayerController _playerController;
    private Camera _camera;

    private void Awake()
    {
        _playerController = FindAnyObjectByType<PlayerController>();
        _camera = Camera.main;
    }

    protected void BackToSavePoint()
    {
        if (!_playerController.gameObject.CompareTag("Player")) return;
        _playerController.gameObject.transform.position = GameManager.SavePoint;
        _camera.transform.position = new Vector3(GameManager.SavePoint.x + 5.5f, _camera.transform.position.y, _camera.transform.position.z);
    }
}
