using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;   // Karakterin gövdesine eklenen CameraTarget objesi
    public float distance = 4.0f;
    public float height = 3.0f;
    public float smoothSpeed = 10.0f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Kamera biraz yukarýya baksýn (karakterin kafasýnýn üstü)
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
