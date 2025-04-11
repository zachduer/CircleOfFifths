using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target to follow

    public float smoothSpeed = 8f; // Speed of the camera movement

    private Vector3 offset = new Vector3(0, 10f, -5f); // Offset from the target

    void Update()
    {
        if (target == null) return; // If no target, do nothing

        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

