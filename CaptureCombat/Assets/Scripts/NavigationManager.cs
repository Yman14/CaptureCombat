using UnityEngine;


public class NavigationManager: MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject HomePanel;
    public GameObject BattlePanel;
    public GameObject ExplorePanel;
    public GameObject CreatureListPanel;
    public GameObject InventoryPanel;
    public GameObject UpgradePanel;
    public GameObject SettingsPanel;
    public GameObject ProfilePanel;


    void Awake()
    {
        BattlePanel.SetActive(false);
        HomePanel.SetActive(true);
    }

    public void SwitchToBattle()
    {
        MenuPanel.SetActive(false);
        HomePanel.SetActive(false);
        BattlePanel.SetActive(true);
    }

    public void SwitchToHome()
    {
        BattlePanel.SetActive(false);
        HomePanel.SetActive(true);
    }

    public void OpenExplorePanel()
    {
        MenuPanel.SetActive(false);
        SwitchToBattle();
    }

    public void OpenCreatureListPanel()
    {
        MenuPanel.SetActive(false);
        CreatureListPanel.SetActive(true);
    }

    public void OpenInventoryPanel()
    {
        MenuPanel.SetActive(false);
        InventoryPanel.SetActive(true);
    }
    public void OpenUpgradePanel()
    {
        MenuPanel.SetActive(false);
        UpgradePanel.SetActive(true);
    }
}
