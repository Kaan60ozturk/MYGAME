using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioClip collectSound; // Inspector'dan ekle
    public float volume = 1f;      // Ses þiddeti

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player tag'ine sahip objeyle çarpýþtýðýnda
        {
            GameManager.instance.AddCoin(); // coin sayýsýný artýr

            // Ses çalma
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
            }

            Destroy(gameObject); // coin toplandýktan sonra yok et
        }
    }
}
