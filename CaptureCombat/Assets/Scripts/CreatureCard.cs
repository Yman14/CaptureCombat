using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreatureCard : MonoBehaviour
{
    public Image creatureIcon;
    public TextMeshProUGUI creatureName;
    public TextMeshProUGUI creatureLevel;
    public Button detailsButton;

    private Creature creatureData;

    // Initialize the card with creature data
    public void SetupCard(Creature data)
    {
        creatureData = data;
        //creatureIcon.sprite = data.creatureSprite;
        creatureName.text = data.name;
        creatureLevel.text = data.level.ToString();

        // Add listener for the button
        detailsButton.onClick.AddListener(() => OpenCreatureDetails());
    }

    // Opens a separate panel to show more details about the creature
    void OpenCreatureDetails()
    {
        Debug.Log("Generating Creature Detail Panel.");
        CreatureDetailPanel.Instance.ShowDetails(creatureData);
    }
}
