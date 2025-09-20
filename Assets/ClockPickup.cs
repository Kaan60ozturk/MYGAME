using UnityEngine;

public class ClockPickup : MonoBehaviour
{
    public float timeToAdd = 30f; // 30 saniye ekle
    public AudioClip collectSound; // Inspector'dan ekle
    public float volume = 1f; // Ses þiddeti

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player tag'ine sahip objeyle çarpýþtýðýnda
        {
            GameManager.instance.AddTime(timeToAdd); // süreyi artýr

            // Ses çalma
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);
            }

            Destroy(gameObject); // saati yok et
        }
    }
}
