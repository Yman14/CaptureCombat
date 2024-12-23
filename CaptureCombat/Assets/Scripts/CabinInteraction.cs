using UnityEngine;

public class CabinInteractions : MonoBehaviour
{
    public GameObject UpgradePanel;

    public void OnCabinClicked()
    {
        UpgradePanel.SetActive(true); // Opens a panel for upgrades or management
    }

    public void ClosedUpgradeWindowClicked()
    {
        UpgradePanel.SetActive(false); // close a panel for upgrades or management
    }
}
