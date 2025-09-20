using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip walkSound;  // Inspector'dan ekle
    public float volume = 0.3f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = walkSound;
        audioSource.volume = volume;
        audioSource.loop = true;       // loop açýk, tuþ basýlýysa devam eder
        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        // Tuþ kontrolü
        bool isMoving = Input.GetKey(KeyCode.W) ||
                        Input.GetKey(KeyCode.A) ||
                        Input.GetKey(KeyCode.S) ||
                        Input.GetKey(KeyCode.D) ||
                        Input.GetKey(KeyCode.UpArrow) ||
                        Input.GetKey(KeyCode.DownArrow) ||
                        Input.GetKey(KeyCode.LeftArrow) ||
                        Input.GetKey(KeyCode.RightArrow);

        if (isMoving)
        {
            if (!audioSource.isPlaying)
                audioSource.Play(); // tuþa basýlýysa çalmaya baþla
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop(); // tuþ býrakýldýysa hemen dur
        }
    }
}
