using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelManager : MonoBehaviour
{
    public GameObject itemPrefab; // The prefab with InventoryItemUI attached
    public Transform contentPanel; // The parent (e.g., the Content object in a Scroll View)

    void OnEnable()
    {
        PopulateInventory();
    }

    public void PopulateInventory()
    {
        // Clear previous items
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // Get inventory items from InventoryManager
        List<InventoryItem> items = InventoryManager.Instance.GetInventoryItems();
        foreach (InventoryItem item in items)
        {
            GameObject newItem = Instantiate(itemPrefab, contentPanel);
            newItem.GetComponent<InventoryItemUI>().SetupItem(item);
        }
    }
}
