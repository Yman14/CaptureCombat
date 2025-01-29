using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureListManager : MonoBehaviour
{
    public GameObject creatureCardPrefab; // The prefab for each creature card
    public Transform creatureListContainer; // The parent where cards are displayed

    void Start()
    {
        PopulateCreatureList();
    }

    void PopulateCreatureList()
    {
        // Get player's creatures
        List<Creature> playerCreatures = CreatureManager.Instance.GetPlayerCreatures();

        // Clear old UI
        foreach (Transform child in creatureListContainer)
        {
            Destroy(child.gameObject);
        }

        // Create cards for each creature
        foreach (Creature creature in playerCreatures)
        {
            GameObject newCard = Instantiate(creatureCardPrefab, creatureListContainer);
            newCard.GetComponent<CreatureCard>().SetupCard(creature);
        }
    }
}
