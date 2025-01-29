using UnityEngine;


public class NavigationManager: MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject HomePanel;
    public GameObject BattlePanel;
    public GameObject CreatureListPanel;

    public void SwitchToBattle()
    {
        HomePanel.SetActive(false);
        BattlePanel.SetActive(true);
    }

    public void SwitchToHome()
    {
        BattlePanel.SetActive(false);
        HomePanel.SetActive(true);
    }

    public void OpenCreatureListPanel()
    {
        MenuPanel.SetActive(false);
        CreatureListPanel.SetActive(true);
    }
}
