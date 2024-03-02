using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;
    private float camPos;
    private void Start()
    {
        mainCamera = Camera.main;
        camPos = Camera.main.transform.position.x;
    }

    private void Update()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x >= 0.5)
        {
            camPos = gameObject.transform.position.x;
            mainCamera.transform.position = new Vector3(camPos, 0, -10);
        }
    }
}
