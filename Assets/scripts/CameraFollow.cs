using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign Doofus here
    public Vector3 offset; // Set this based on your desired camera position
    public float smoothSpeed;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
