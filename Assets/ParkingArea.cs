using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    public GameObject starCoin6; // Inspector’dan StarCoin6’yý buraya sürükle

    private void Start()
    {
        if (starCoin6 != null)
        {
            starCoin6.SetActive(false); // oyun baþýnda coin gizli
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eðer Player (araç) park alanýna girerse
        if (other.CompareTag("car1") && CompareTag("park"))
        {
            if (starCoin6 != null)
            {
                starCoin6.SetActive(true); // coin görünür hale gelsin
            }
        }
    }
}
