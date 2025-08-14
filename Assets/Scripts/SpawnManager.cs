using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ghostPrefabs;
    private float spawnRangeX = 10;
    private float spawnPosZ = 30;
    private float startDelay = 2;
    private float spawnInterval = 3.0f;

    void Start()
    {
        InvokeRepeating("SpawnRandomGhost", startDelay, spawnInterval);
    }

    void SpawnRandomGhost()
    {
        int ghostIndex = Random.Range(0, ghostPrefabs.Length);
        Vector3 spawnPosTop = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(ghostPrefabs[ghostIndex], spawnPosTop, ghostPrefabs[ghostIndex].transform.rotation);
    }
}
