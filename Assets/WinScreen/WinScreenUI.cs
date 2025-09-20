using UnityEngine;
using UnityEngine.UI;

public class WinScreenUI : MonoBehaviour
{
    public Text elapsedTimeText; // Inspector'dan baðlayacaðýz

    private void Start()
    {
        // GameManager'dan geçen süreyi al ve Text UI'ye yaz
        elapsedTimeText.text = GameManager.elapsedTime.ToString("F2") + " sn";
    }
}
