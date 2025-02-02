using UnityEngine;
using System.Collections;

[System.Serializable]
public class Creature
{
    public string name;
    public int level;
    public string type;       // Fire, Water, etc.
    public int hp;          // Health Points
    public int attack;      // Offensive power
    public int defense;     // Reduces incoming damage
    public float speed;       // Determines turn order
    public float criticalRate; // Chance of landing critical hits (0.0 to 1.0)

    // Constructor
    //name, level, type, hp, attack, defense, speed, criticalrate
    public Creature(string name, int level, string type, int hp, int attack, int defense, float speed, float criticalRate)
    {
        this.name = name;
        this.level = level;
        this.type = type;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.criticalRate = criticalRate;
    }

    // Converts stats to a formatted string
    public string GetStatString()
    {
        return $"[ HP: {hp} ]\n[ ATK: {attack} ]\n[ DEF: {defense} ]\n[ SPD: {speed} ]\n[ CRIT Rate: {criticalRate} ]\n ";
    }

    // Simulate training (stat growth)
    public void Train()
    {
        level++;
        hp += Random.Range(5, 10);      // Increase HP
        attack += Random.Range(1, 3);    // Increase attack slightly
        defense += Random.Range(1, 3);  // Increase defense slightly
        speed += Random.Range(0.1f, 0.5f); // Increase speed slightly
        
        // Update the saved data after training
        if (CreatureManager.Instance != null)
        {
            CreatureManager.Instance.SaveCreatures();
        }
    }
}
