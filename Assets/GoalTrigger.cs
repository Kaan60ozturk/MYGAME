using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject starCoin; // Inspector'dan baðla

    private void OnTriggerEnter(Collider other)
    {
        // Sadece top temas ederse çalýþsýn
        if (other.CompareTag("Soccer"))
        {
            starCoin.SetActive(true); // Gol olunca görünür
        }
    }
}
