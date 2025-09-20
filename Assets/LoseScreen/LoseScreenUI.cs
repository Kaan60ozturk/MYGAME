using UnityEngine;
using UnityEngine.UI;

public class LoseScreenUI : MonoBehaviour
{
    public Text coinText; // Inspector'den ba�layaca��z

    void Start()
    {
        // GameManager'dan coin say�s�n� al ve Text UI'ye yaz
        coinText.text = GameManager.coinsCollectedOnLose.ToString();
    }
}
