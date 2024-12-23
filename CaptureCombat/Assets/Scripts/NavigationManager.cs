using UnityEngine;


public class NavigationManager: MonoBehaviour
{
    public GameObject HubPanel;
    public GameObject BattlePanel;

    public void SwitchToBattle()
    {
        HubPanel.SetActive(false);
        BattlePanel.SetActive(true);
    }

    public void SwitchToHub()
    {
        BattlePanel.SetActive(false);
        HubPanel.SetActive(true);
    }
}
