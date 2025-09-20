using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootForce = 500f; // Topa uygulanacak kuvvet
    private GameObject soccer; // Önümüzdeki top

    void Update()
    {
        // F tuþuna basýldýysa
        if (Input.GetKeyDown(KeyCode.F) && soccer != null)
        {
            Rigidbody ballRb = soccer.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                // Karakterin önündeki yönde force uygula
                Vector3 forceDirection = transform.forward;
                ballRb.AddForce(forceDirection * shootForce);
            }
        }
    }

    // Top karakterin önüne geldiðinde
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soccer") // Topun adý soccer
        {
            soccer = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "soccer")
        {
            if (other.gameObject == soccer)
            {
                soccer = null;
            }
        }
    }
}
