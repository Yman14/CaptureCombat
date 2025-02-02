using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureListManager : MonoBehaviour
{
    public GameObject creatureCardPrefab; // The prefab for each creature card
    public Transform creatureListContainer; // The parent where cards are displayed


    //bug- it basically updates eveytime this panel is activated but if its not activated, new information is will not be updated
    void OnEnable()
    {
        // Start a coroutine that waits one frame to ensure all references are set
        StartCoroutine(RefreshCreatureList());
    }

    IEnumerator RefreshCreatureList()
    {
        yield return null; // Wait one frame
        PopulateCreatureList();
    }


    //this code is bad cause it will always destroy and create new one, its only fine if the data is small
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
