using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
    public string itemName;
    public ItemType itemType;
    public int quantity;
    // Optionally, you can store the icon name or path if not directly referencing a sprite:
    public string iconName;  

    public InventoryItem(string itemName, ItemType itemType, int quantity, string iconName)
    {
        this.itemName = itemName;
        this.itemType = itemType;
        this.quantity = quantity;
        this.iconName = iconName;
    }
}

public enum ItemType
{
    AttackPotion,
    DefendPotion,
    HPPotion
    // You can add more types later
}
