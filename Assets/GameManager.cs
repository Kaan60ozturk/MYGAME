using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Sahne geçiþi için gerekli

public class GameManager : MonoBehaviour
{
    public static int coinsCollectedOnLose = 0;
    public static GameManager instance;

    public float timeLeft = 60f; // Baþlangýç süresi
    public int coinCount = 0; // Toplanan coin sayýsý
    public Text timerText; // Kalan süreyi gösterecek UI Text
    public Text coinText; // Coin sayýsýný gösterecek UI Text

    private bool gameEnded = false; // Oyunun bittiðini kontrol için

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (gameEnded) return; // Oyun bitmiþse geri kalan kod çalýþmaz

        // Süreyi azalt
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            GameOver(); // Süre bittiðinde LoseScreen'e geç
        }

        // Kalan süreyi yazdýr
        timerText.text = "Kalan Süre: " + Mathf.Ceil(timeLeft).ToString() + "s";

        // Coin sayýsýný yazdýr
        coinText.text = "Toplanan Altýn 7'de = " + coinCount;
    }

    public void AddTime(float amount)
    {
        timeLeft += amount;
    }

    public void AddCoin()
    {
        coinCount++;

        // Eðer coin sayýsý 7’ye eþit ise WinScreen sahnesine geç
        if (coinCount >= 7)
        {
            WinGame();
        }
    }
    public static float elapsedTime = 0f; // WinScreen için geçici süre

    private void WinGame()
    {
        gameEnded = true;

        // Sahnede kalan Clock sayýsý
        int remainingClocks = GameObject.FindGameObjectsWithTag("Clock").Length;
        int collectedClocks = 11 - remainingClocks; // Toplanan Clock sayýsý

        // Formül: (Toplanan Clock x 30) + 60 - timeLeft
        GameManager.elapsedTime = (collectedClocks * 30f) + 60f - timeLeft;

        SceneManager.LoadScene("WinScreen");
    }

    private void GameOver()
    {
        gameEnded = true;
        coinsCollectedOnLose = coinCount;
        SceneManager.LoadScene("LoseScreen");
    }


}
