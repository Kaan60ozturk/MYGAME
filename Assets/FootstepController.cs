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
        audioSource.loop = true;       // loop a��k, tu� bas�l�ysa devam eder
        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        // Tu� kontrol�
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
                audioSource.Play(); // tu�a bas�l�ysa �almaya ba�la
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop(); // tu� b�rak�ld�ysa hemen dur
        }
    }
}
