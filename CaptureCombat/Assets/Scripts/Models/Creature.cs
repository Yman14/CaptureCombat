using UnityEngine;

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
        return $"ATK: {attack} | DEF: {defense} | SPD: {speed}";
    }

    // Simulate training (stat growth)
    public void Train()
    {
        level++;
        hp += Random.Range(5, 10);      // Increase HP
        attack += Random.Range(1, 3);    // Increase attack slightly
        defense += Random.Range(1, 3);  // Increase defense slightly
        speed += Random.Range(0.1f, 0.5f); // Increase speed slightly
    }
}
