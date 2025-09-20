using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // Top prefab
    public Transform spawnPoint;  // Topun spawn olaca�� nokta

    void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }
}
