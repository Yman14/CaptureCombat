using UnityEngine;

[System.Serializable]
public class Creature
{
    public string name;
    public int level;
    public float hp;          // Health Points
    public float attack;      // Offensive power
    public float defense;     // Reduces incoming damage
    public float speed;       // Determines turn order
    public float criticalRate; // Chance of landing critical hits (0.0 to 1.0)

    // Constructor
    //name, level, hp, attack, defense, speed, criticalrate
    public Creature(string name, int level, float hp, float attack, float defense, float speed, float criticalRate)
    {
        this.name = name;
        this.level = level;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.criticalRate = criticalRate;
    }

    // Simulate training (stat growth)
    public void Train()
    {
        level++;
        attack += Random.Range(1, 3);    // Increase attack slightly
        defense += Random.Range(1, 3);  // Increase defense slightly
        hp += Random.Range(5, 10);      // Increase HP
        speed += Random.Range(0.1f, 0.5f); // Increase speed slightly
    }
}
