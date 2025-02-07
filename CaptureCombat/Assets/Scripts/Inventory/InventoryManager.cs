using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // List to store the player's inventory items
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    private string saveFilePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        saveFilePath = Application.persistentDataPath + "/inventory.json";
        LoadInventory();
    }

    // Returns the current inventory
    public List<InventoryItem> GetInventoryItems()
    {
        return inventoryItems;
    }

    // Add an item or update the quantity if it already exists
    public void AddItem(InventoryItem newItem)
    {
        InventoryItem existing = inventoryItems.Find(item => item.itemType == newItem.itemType);
        if (existing != null)
        {
            existing.quantity += newItem.quantity;
        }
        else
        {
            inventoryItems.Add(newItem);
        }
        SaveInventory();
    }

    // Remove or reduce item quantity (if quantity reaches 0, remove it)
    public void UseItem(ItemType type, int amount = 1)
    {
        InventoryItem existing = inventoryItems.Find(item => item.itemType == type);
        if (existing != null)
        {
            existing.quantity -= amount;
            if (existing.quantity <= 0)
            {
                inventoryItems.Remove(existing);
            }
            SaveInventory();
        }
    }

    // Save the inventory to a JSON file
    public void SaveInventory()
    {
        InventoryWrapper wrapper = new InventoryWrapper(inventoryItems);
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(saveFilePath, json);
    }

    // Load the inventory from a JSON file
    public void LoadInventory()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            InventoryWrapper wrapper = JsonUtility.FromJson<InventoryWrapper>(json);
            inventoryItems = wrapper.items;
        }
        else
        {
            // Generate starter items, if needed
            GenerateStarterItems();
        }
    }

    void GenerateStarterItems()
    {
        // For example, start with some potions:
        inventoryItems.Add(new InventoryItem("Attack Potion", ItemType.AttackPotion, 10, "AttackPotionIcon"));
        inventoryItems.Add(new InventoryItem("Defend Potion", ItemType.DefendPotion, 5, "DefendPotionIcon"));
        inventoryItems.Add(new InventoryItem("HP Potion", ItemType.HPPotion, 79, "HPPotionIcon"));
        SaveInventory();
    }
}

// Wrapper class for JSON serialization
[System.Serializable]
public class InventoryWrapper
{
    public List<InventoryItem> items;

    public InventoryWrapper(List<InventoryItem> items)
    {
        this.items = items;
    }
}
