using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Creature> playerCreatures = new List<Creature>();
    public GameObject creaturePrefab;
    public Transform spawnArea;
    public int maxCreatures = 5;

    public void Start()
    {
        SpawnCreatures();
    }

    public void Update()
    {
        foreach (var creature in playerCreatures)
        {
            creature.Train();
            Debug.Log($"{creature.name} is now Level {creature.level}");
        }
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

    public void CaptureRandomCreature()
    {
        GameObject[] creatures = GameObject.FindGameObjectsWithTag("Creature");

        if (creatures.Length > 0)
        {
            GameObject creatureToCapture = creatures[Random.Range(0, creatures.Length)];
            Destroy(creatureToCapture); // Capture the creature
            Debug.Log("Creature Captured!");
        }
        else
        {
            Debug.Log("No creatures left to capture!");
        }
    }
}