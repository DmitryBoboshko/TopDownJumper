using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Reference to Player
    [SerializeField] private Transform target;

    // Configuration fields
    [SerializeField] [Range(0, 1)] private float smoothSpeed = 0.1f;
    [SerializeField] private float cameraOffsetY = 3.5f;

    // Const fields
    [SerializeField] private const float cameraOffsetZ = -10f;
    private const float initOffsetY = 0;

    // State fields
    private float currentOffsetY;

    void Update()
    {
        // Get current camera Y coordinate
        float cameraPosY = transform.position.y;

        // Calculate desired camera's Y coordinate: target Y coord + current camera Offset
        float desiredCameraPosY = target.position.y + currentOffsetY;

        // Smooth value
        float smoothedCameraPosY = Mathf.Lerp(cameraPosY, desiredCameraPosY, smoothSpeed);

        // Prepare new camera position
        Vector3 newCameraPos = new Vector3(0, smoothedCameraPosY, cameraOffsetZ);
        // Set new camera position
        transform.position = newCameraPos;
    }

    // Set predefined camera offset
    public void SetCameraOffsetY()
    {
        currentOffsetY = cameraOffsetY;
    }

    // Set initial camera offset
    public void SetInitCameraOffset()
    {
        currentOffsetY = initOffsetY;
    }
}
