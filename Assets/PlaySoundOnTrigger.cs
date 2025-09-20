using UnityEngine;

public class DistanceBasedSound : MonoBehaviour
{
    [Header("Referanslar")]
    [SerializeField] private Transform player;       // Player referans� (Inspector�dan ata)
    [SerializeField] private AudioSource audioSource; // AudioSource (Inspector�dan ata veya ayn� objede olmal�)

    [Header("Mesafe Ayarlar�")]
    public float minDistance = 2f;   // tam ses ��kaca�� mesafe
    public float maxDistance = 15f;  // sesin tamamen kaybolaca�� mesafe

    private bool coinCollected = false;

    public static DistanceBasedSound Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.loop = true;
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0f; // biz volume�u elle kontrol edece�iz
            audioSource.volume = 0f;
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (coinCollected || audioSource == null || player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= maxDistance)
        {
            float t = Mathf.InverseLerp(maxDistance, minDistance, distance);
            audioSource.volume = Mathf.Clamp01(t);
        }
        else
        {
            audioSource.volume = 0f;
        }
    }

    public void OnStarCoinCollected()
    {
        coinCollected = true;
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.volume = 0f;
        }
    }
}
