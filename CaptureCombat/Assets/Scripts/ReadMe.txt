Theres a bug with DoTweeen 
DOTWEEN ► Target or field is missing/null (Void TryThrowEditorNullExceptionObject(UnityEngine.Object, System.String)) ► The object of type 'UnityEngine.RectTransform' has been destroyed but you are still trying to access it.
Your script should either check if it is null or you should not destroy the object.

It basically happeneds when i clicked the Creature List Panel and the mouse is hovering on top of the card 
directly after the panel is opened












//using Addressables
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
}
