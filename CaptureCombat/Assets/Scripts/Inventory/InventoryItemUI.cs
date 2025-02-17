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


/*using Addressables(putting it here for when resources.load is not good enough)
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public IEnumerator LoadIcon(string key, System.Action<Sprite> callback)
{
    AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(key);
    yield return handle;
    if (handle.Status == AsyncOperationStatus.Succeeded)
    {
        callback(handle.Result);
    }
    else
    {
        Debug.LogError("Failed to load asset: " + key);
    }
}*/
