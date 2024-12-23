using UnityEngine;


public class LockedButton : MonoBehaviour
{
    public void LockedButtonClicked()
    {
        string text = "Not available at the moment.";
        FindAnyObjectByType<NotificationManager>().ShowNotification(text);
    }   


}