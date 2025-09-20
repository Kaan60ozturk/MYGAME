using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootForce = 500f; // Topa uygulanacak kuvvet
    private GameObject soccer; // �n�m�zdeki top

    void Update()
    {
        // F tu�una bas�ld�ysa
        if (Input.GetKeyDown(KeyCode.F) && soccer != null)
        {
            Rigidbody ballRb = soccer.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                // Karakterin �n�ndeki y�nde force uygula
                Vector3 forceDirection = transform.forward;
                ballRb.AddForce(forceDirection * shootForce);
            }
        }
    }

    // Top karakterin �n�ne geldi�inde
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soccer") // Topun ad� soccer
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
