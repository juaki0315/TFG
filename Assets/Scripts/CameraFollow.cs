using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // El Transform del personaje que seguir� la c�mara
    public float smoothSpeed = 0.125f;  // La suavidad del seguimiento de la c�mara

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
