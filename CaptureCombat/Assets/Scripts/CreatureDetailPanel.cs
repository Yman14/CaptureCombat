using UnityEngine;
using UnityEngine.UI;

public class CreatureDetailPanel : MonoBehaviour
{
    public static CreatureDetailPanel Instance;
    public Image creatureImage;
    public Text creatureName, creatureLevel, creatureStats;
    public GameObject panel;

    private Creature currentCreature;

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void ShowDetails(Creature creature)
    {
        currentCreature = creature;
        //creatureImage.sprite = creature.icon;
        creatureName.text = creature.name;
        creatureLevel.text = "Lv. " + creature.level;
        creatureStats.text = creature.GetStatString(); // Convert stats to text format
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
