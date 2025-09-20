using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    public GameObject starCoin6; // Inspector�dan StarCoin6�y� buraya s�r�kle

    private void Start()
    {
        if (starCoin6 != null)
        {
            starCoin6.SetActive(false); // oyun ba��nda coin gizli
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // E�er Player (ara�) park alan�na girerse
        if (other.CompareTag("car1") && CompareTag("park"))
        {
            if (starCoin6 != null)
            {
                starCoin6.SetActive(true); // coin g�r�n�r hale gelsin
            }
        }
    }
}
