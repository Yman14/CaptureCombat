using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreatureCard : MonoBehaviour
{
    public Image creatureIcon;
    public TextMeshProUGUI creatureName;
    public Button detailsButton;

    private Creature creatureData;

    // Initialize the card with creature data
    public void SetupCard(Creature data)
    {
        creatureData = data;
        //creatureIcon.sprite = data.creatureSprite;
        creatureName.text = data.name;

        // Add listener for the button
        detailsButton.onClick.AddListener(() => OpenCreatureDetails());
    }

    // Opens a separate panel to show more details about the creature
    void OpenCreatureDetails()
    {
        CreatureDetailPanel.Instance.ShowDetails(creatureData);
    }
}
