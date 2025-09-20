using UnityEngine;
using UnityEngine.SceneManagement;

public class EscSceneSwitcher : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                // Oyun sahnesini durdur
                Time.timeScale = 0f;
                // Men� sahnesini �st�ne y�kle
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                isPaused = true;
            }
            else
            {
                // Men� sahnesini kapat
                SceneManager.UnloadSceneAsync("MainMenu");
                // Oyun sahnesini devam ettir
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}
