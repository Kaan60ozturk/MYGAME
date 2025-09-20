using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioClip collectSound; // Inspector'dan ekle
    public float volume = 1f;      // Ses �iddeti

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player tag'ine sahip objeyle �arp��t���nda
        {
            GameManager.instance.AddCoin(); // coin say�s�n� art�r

            // Ses �alma
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
            }

            Destroy(gameObject); // coin topland�ktan sonra yok et
        }
    }
}
