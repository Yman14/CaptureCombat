using UnityEngine;

public class EventManager : MonoBehaviour
{
    public void TriggerEvent(string eventType)
    {
        switch (eventType)
        {
            case "Battle":
                // Start a battle
                Debug.Log("Starting a battle!");
                break;
            case "Treasure":
                // Give rewards
                Debug.Log("Found a treasure!");
                break;
            case "Story":
                // Trigger a story cutscene
                Debug.Log("Story event triggered.");
                break;
            default:
                Debug.Log("Unknown event type.");
                break;
        }
    }
}
