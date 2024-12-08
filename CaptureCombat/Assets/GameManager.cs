using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject creaturePrefab;
    public Transform spawnArea;
    public int maxCreatures = 5;

    void Start()
    {
        SpawnCreatures();
    }

    void SpawnCreatures()
    {
        for (int i = 0; i < maxCreatures; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.localScale.x / 2, spawnArea.localScale.x / 2),
                Random.Range(-spawnArea.localScale.y / 2, spawnArea.localScale.y / 2),
                0);
            Instantiate(creaturePrefab, randomPosition, Quaternion.identity, spawnArea);
        }
    }
}