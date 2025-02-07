using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI quantityText;

    private InventoryItem currentItem;

    public void SetupItem(InventoryItem item)
    {
        currentItem = item;
        // Here, you can load the sprite by name from your resources or assign it directly if you have a reference
        iconImage.sprite = Resources.Load<Sprite>(item.iconName);  
        itemNameText.text = item.itemName;
        quantityText.text = item.quantity.ToString();
    }
}
