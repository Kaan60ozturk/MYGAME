using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    [Header("References")]
    public GameObject player;                // 3. �ah�s karakter (model + controller)
    public MonoBehaviour playerController;   // karakter kontrol scripti (3rd person controller)
    public Camera playerCamera;              // mevcut TPS kamera
    public Camera carCamera;                 // araba kameras�
    public CarController carController;      // araba hareket scripti
    public Transform exitPoint;              // arabadan ��k�nca spawn noktas�

    bool isInCar = false;

    void Start()
    {
        carCamera.enabled = false;
        carController.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInCar && Vector3.Distance(player.transform.position, transform.position) < 3f)
            {
                EnterCar();
            }
            else if (isInCar)
            {
                ExitCar();
            }
        }
    }

    void EnterCar()
    {
        isInCar = true;

        // Karakteri devre d��� b�rak (ama gizlemek i�in sadece controller kapat�labilir)
        player.SetActive(false);

        // Arabay� aktif et
        carController.enabled = true;

        // Kamera ge�i�i
        playerCamera.enabled = false;
        carCamera.enabled = true;
    }

    void ExitCar()
    {
        isInCar = false;

        // Oyuncuyu arabadan ��kar
        player.transform.position = exitPoint.position;
        player.transform.rotation = exitPoint.rotation;
        player.SetActive(true);

        // Arabay� kapat
        carController.enabled = false;

        // Kamera ge�i�i
        carCamera.enabled = false;
        playerCamera.enabled = true;
    }
}
