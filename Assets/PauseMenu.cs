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
                // Menü sahnesini üstüne yükle
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                isPaused = true;
            }
            else
            {
                // Menü sahnesini kapat
                SceneManager.UnloadSceneAsync("MainMenu");
                // Oyun sahnesini devam ettir
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}
