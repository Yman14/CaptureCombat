using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreatureManager : MonoBehaviour
{
    public static CreatureManager Instance; // Singleton
    private List<Creature> playerCreatures = new List<Creature>();
    private string saveFilePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        saveFilePath = Application.persistentDataPath + "/creatures.json";
        LoadCreatures();
    }

    // Returns player's current creatures
    public List<Creature> GetPlayerCreatures()
    {
        return playerCreatures;
    }

    // Generates starter creatures if no data exists
    //name, level, type, hp, attack, defense, speed, criticalrate
    private void GenerateStarterCreatures()
    {
        playerCreatures.Add(new Creature("Glowpaw", 1, "Light", 100, 10, 5, 8, 0));
        playerCreatures.Add(new Creature("Darkfang", 1, "Shadow", 100, 12, 6, 7, 0));
        playerCreatures.Add(new Creature("Flame Whisk", 1, "Fire", 100, 8, 4, 10, 0));
        SaveCreatures();
    }

    // Saves creatures to a file
    public void SaveCreatures()
    {
        string json = JsonUtility.ToJson(new CreatureListWrapper(playerCreatures), true);
        File.WriteAllText(saveFilePath, json);
    }

    // Loads creatures from a file
    public void LoadCreatures()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            CreatureListWrapper wrapper = JsonUtility.FromJson<CreatureListWrapper>(json);
            playerCreatures = wrapper.creatures;
        }
        else
        {
            GenerateStarterCreatures();
        }
    }

    // Adds a new creature (for capturing mechanics later)
    public void AddCreature(Creature newCreature)
    {
        playerCreatures.Add(newCreature);
        SaveCreatures();
    }
}

// Wrapper class to allow JSON conversion of lists
[System.Serializable]
public class CreatureListWrapper
{
    public List<Creature> creatures;

    public CreatureListWrapper(List<Creature> creatures)
    {
        this.creatures = creatures;
    }
}
