using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public GameObject BattleUI;

    public TMP_Text playerNameText;
    public TMP_Text playerLevelText;
    public TMP_Text playerHpText;
    public Image playerHealthBar;

    public TMP_Text enemyNameText;
    public TMP_Text enemyLevelText;
    public TMP_Text enemyHpText;
    public Image enemyHealthBar;

    public TMP_Text battleLog;

    public Creature playerCreature;
    public Creature enemyCreature;

    public Image playerSprite;
    public Image enemySprite;

    public GameObject playerSpritePrefab;
    public Transform playerSpawnPoint;
    public GameObject enemySpritePrefab;
    public Transform enemySpawnPoint;

    public string spritePath;


    string result;


    //Health Bar Update
    public void UpdateHealth(Creature creature, Image healthBar)
    {
        healthBar.fillAmount = creature.hp / 100f; // Assuming max HP is 100
    }

    public void AnimateHealthBar(Image healthBar, float currentHP, float maxHP)
    {
        StartCoroutine(SmoothHealthBar(healthBar, currentHP / maxHP));
    }


    //Health bar animation when taking damage
    //AnimateHealthBar(playerHealthBar, playerCreature.hp, 100f);
    private IEnumerator SmoothHealthBar(Image healthBar, float targetFill)
    {
        float currentFill = healthBar.fillAmount;
        float elapsed = 0f;
        float duration = 0.5f; // Duration of the animation

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            healthBar.fillAmount = Mathf.Lerp(currentFill, targetFill, elapsed / duration);
            yield return null;
        }

        healthBar.fillAmount = targetFill; // Ensure it reaches exactly the target
    }



    //Battle Log Prompt Message
    public void LogAction(string message)
    {
        battleLog.text += message + "\n";
    }



    public void StartBattle()
    {
        // Initialize creatures (can add a setup phase later)
        playerCreature = new Creature("Glowpaw", 1, "Light", 100, 10, 5, 12, 0);
        enemyCreature = new Creature("Darkfang", 1, "Shadow", 100, 8, 6, 10, 0);

        BattleUI.SetActive(true);
        UpdateUI();
        SetupBattleUI();
        LogAction($"A wild {enemyCreature.name} appeared! Get ready to battle!");
    }

    // Process the player's attack action
    public void PlayerAttack()
    {
        int damage = CalculateDamage(playerCreature, enemyCreature);
        enemyCreature.hp -= damage;
        enemyHpText.text = enemyCreature.hp.ToString();
        AnimateHealthBar(enemyHealthBar, enemyCreature.hp, 100f);
        LogAction($"{playerCreature.name} attacks {enemyCreature.name} for {damage} damage!");

        if (enemyCreature.hp <= 0)
        {
            LogAction($"{enemyCreature.name} fainted! You win!");
            EndBattle(true);
            return;
        }

        EnemyTurn();
    }

    // Process the player's defend action
    public void PlayerDefend()
    {
        LogAction($"{playerCreature.name} braces for impact!");
        playerCreature.defense *= 2; // Temporarily boost defense
        EnemyTurn();
        playerCreature.defense /= 2; // Reset defense after turn
    }

    // Use Item (e.g., Heal Potion)
    public void UseItem()
    {
        LogAction($"{playerCreature.name} uses a healing potion!");
        playerCreature.hp += 20;
        playerHpText.text = playerCreature.hp.ToString();
        if (playerCreature.hp > 100) playerCreature.hp = 100; // Cap HP
        AnimateHealthBar(playerHealthBar, playerCreature.hp, 100);
        LogAction($"{playerCreature.name} recovers health!");

        EnemyTurn();
    }

    // Process the enemy's turn
    private void EnemyTurn()
    {
        LogAction($"{enemyCreature.name} attacks!");

        int damage = CalculateDamage(enemyCreature, playerCreature);
        playerCreature.hp -= damage;
        playerHpText.text = playerCreature.hp.ToString();
        AnimateHealthBar(playerHealthBar, playerCreature.hp, 100f);
        LogAction($"{enemyCreature.name} deals {damage} damage to {playerCreature.name}!");

        if (playerCreature.hp <= 0)
        {
            LogAction($"{playerCreature.name} fainted! You lose!");
            EndBattle(false);
        }
    }

    // End the battle
    private void EndBattle(bool playerWon)
    {
        if (playerWon)
        {
            LogAction("Congratulations! You won the battle!");
        }
        else
        {
            LogAction("You lost the battle! Better luck next time.");
        }
    }

    // Damage calculation logic
    private int CalculateDamage(Creature attacker, Creature defender)
    {
        return (10 * (attacker.attack / defender.defense)) + Random.Range(1, 5);
    }

    // Update UI elements
    private void UpdateUI()
    {
        playerNameText.text = playerCreature.name;
        playerLevelText.text = $"Lvl: {playerCreature.level}";
        playerHpText.text = playerCreature.hp.ToString();
        enemyNameText.text = enemyCreature.name;
        enemyLevelText.text = $"Lvl {enemyCreature.level}";
        enemyHpText.text = enemyCreature.hp.ToString();

        AnimateHealthBar(playerHealthBar, playerCreature.hp, 100f);
        AnimateHealthBar(enemyHealthBar, enemyCreature.hp, 100f);
    }

    //spawing creature  
    private void SetupBattleUI()
    {
        Instantiate(playerSpritePrefab, playerSpawnPoint.transform.position, Quaternion.Euler(0,180,0), playerSpawnPoint);
        Instantiate(enemySpritePrefab, enemySpawnPoint, false);

        playerSprite.sprite = Resources.Load<Sprite>("Prefabs/Creatures/Glowpaw");
        enemySprite.sprite = Resources.Load<Sprite>("Sprites/Darkfang");
    }

    

}
