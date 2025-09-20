using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Sahne ge�i�i i�in gerekli

public class GameManager : MonoBehaviour
{
    public static int coinsCollectedOnLose = 0;
    public static GameManager instance;

    public float timeLeft = 60f; // Ba�lang�� s�resi
    public int coinCount = 0; // Toplanan coin say�s�
    public Text timerText; // Kalan s�reyi g�sterecek UI Text
    public Text coinText; // Coin say�s�n� g�sterecek UI Text

    private bool gameEnded = false; // Oyunun bitti�ini kontrol i�in

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (gameEnded) return; // Oyun bitmi�se geri kalan kod �al��maz

        // S�reyi azalt
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            GameOver(); // S�re bitti�inde LoseScreen'e ge�
        }

        // Kalan s�reyi yazd�r
        timerText.text = "Kalan S�re: " + Mathf.Ceil(timeLeft).ToString() + "s";

        // Coin say�s�n� yazd�r
        coinText.text = "Toplanan Alt�n 7'de = " + coinCount;
    }

    public void AddTime(float amount)
    {
        timeLeft += amount;
    }

    public void AddCoin()
    {
        coinCount++;

        // E�er coin say�s� 7�ye e�it ise WinScreen sahnesine ge�
        if (coinCount >= 7)
        {
            WinGame();
        }
    }
    public static float elapsedTime = 0f; // WinScreen i�in ge�ici s�re

    private void WinGame()
    {
        gameEnded = true;

        // Sahnede kalan Clock say�s�
        int remainingClocks = GameObject.FindGameObjectsWithTag("Clock").Length;
        int collectedClocks = 11 - remainingClocks; // Toplanan Clock say�s�

        // Form�l: (Toplanan Clock x 30) + 60 - timeLeft
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
