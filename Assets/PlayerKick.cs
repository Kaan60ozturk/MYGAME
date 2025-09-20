using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    public Transform kickPoint;   // Karakterin ayaðý hizasýnda boþ obje
    public float kickForce = 500f; // Tekme kuvveti
    public float kickRange = 2f;   // Tekmenin etki mesafesi

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // E ile þut
        {
            KickBall();
        }
    }

    void KickBall()
    {
        // KickPoint çevresinde top ara
        Collider[] hits = Physics.OverlapSphere(kickPoint.position, kickRange);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Ball")) // Topa "Ball" tag ver
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = (hit.transform.position - kickPoint.position).normalized;
                    rb.AddForce(direction * kickForce);
                }
            }
        }
    }
}
