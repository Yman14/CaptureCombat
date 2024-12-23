using UnityEngine;
using UnityEngine.SceneManagement; // If you want to load a new scene

public class NodeInteraction : MonoBehaviour
{
    public string nodeName; // Name of the node
    public string eventType; // "Battle", "Treasure", etc.
    
    public void OnNodeClick()
    {
        Debug.Log("Player clicked on " + nodeName);
        
        // Trigger an event based on the type
        if (eventType == "Battle")
        {
            // Example: Load a battle scene or open battle UI
            //SceneManager.LoadScene("BattleScene");
        }
        else if (eventType == "Treasure")
        {
            Debug.Log("Found treasure!");
        }
    }
}
