using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public TMP_Text battleLog;
    string result = "[Battle Log]";

    public void Update()
    {
            battleLog.text = result;
    }


    public void StartBattle()
    {
        //name, level, hp, attack, defense, speed, criticalrate
        Creature playerCreature = new Creature("Glowpaw", 1, 100, 10, 5, 12, 0.2f);
        Creature enemyCreature = new Creature("Darkfang", 1, 100, 8, 6, 10, 0.15f);

        SimulateBattle(playerCreature, enemyCreature);
    }

    public void SimulateBattle(Creature player, Creature enemy)
    {
        result = $"{player.name} vs {enemy.name}";
        Debug.Log(result);

        while (player.hp > 0 && enemy.hp > 0)
        {
            // Player attacks
            float playerDamage = (10 * (player.attack / enemy.defense)) + Random.Range(1, 5);
            enemy.hp -= playerDamage;
            result = $"{player.name} deals {playerDamage} damage! {enemy.name} has {enemy.hp} HP left.";
            Debug.Log(result);
            if (enemy.hp <= 0)
            {
                result = $"{enemy.name} fainted. {player.name} wins!";
                break;
            }

            // Enemy attacks
            float enemyDamage = (10 * (enemy.attack / player.defense)) + Random.Range(1, 5);
            player.hp -= enemyDamage;
            result = $"{enemy.name} deals {enemyDamage} damage! {player.name} has {player.hp} HP left.";
            Debug.Log(result);
            if (player.hp <= 0)
            {
                result = $"{player.name} fainted. {enemy.name} wins!";
                break;
            }
        }
    }
}
