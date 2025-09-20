using UnityEngine;
using UnityEngine.UI;

public class LoseScreenUI : MonoBehaviour
{
    public Text coinText; // Inspector'den baðlayacaðýz

    void Start()
    {
        // GameManager'dan coin sayýsýný al ve Text UI'ye yaz
        coinText.text = GameManager.coinsCollectedOnLose.ToString();
    }
}
