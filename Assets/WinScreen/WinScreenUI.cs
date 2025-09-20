using UnityEngine;
using UnityEngine.UI;

public class WinScreenUI : MonoBehaviour
{
    public Text elapsedTimeText; // Inspector'dan ba�layaca��z

    private void Start()
    {
        // GameManager'dan ge�en s�reyi al ve Text UI'ye yaz
        elapsedTimeText.text = GameManager.elapsedTime.ToString("F2") + " sn";
    }
}
