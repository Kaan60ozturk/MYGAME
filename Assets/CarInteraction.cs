using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    [Header("References")]
    public GameObject player;                // 3. þahýs karakter (model + controller)
    public MonoBehaviour playerController;   // karakter kontrol scripti (3rd person controller)
    public Camera playerCamera;              // mevcut TPS kamera
    public Camera carCamera;                 // araba kamerasý
    public CarController carController;      // araba hareket scripti
    public Transform exitPoint;              // arabadan çýkýnca spawn noktasý

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

        // Karakteri devre dýþý býrak (ama gizlemek için sadece controller kapatýlabilir)
        player.SetActive(false);

        // Arabayý aktif et
        carController.enabled = true;

        // Kamera geçiþi
        playerCamera.enabled = false;
        carCamera.enabled = true;
    }

    void ExitCar()
    {
        isInCar = false;

        // Oyuncuyu arabadan çýkar
        player.transform.position = exitPoint.position;
        player.transform.rotation = exitPoint.rotation;
        player.SetActive(true);

        // Arabayý kapat
        carController.enabled = false;

        // Kamera geçiþi
        carCamera.enabled = false;
        playerCamera.enabled = true;
    }
}
