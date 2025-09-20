using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject starCoin; // Inspector'dan ba�la

    private void OnTriggerEnter(Collider other)
    {
        // Sadece top temas ederse �al��s�n
        if (other.CompareTag("Soccer"))
        {
            starCoin.SetActive(true); // Gol olunca g�r�n�r
        }
    }
}
