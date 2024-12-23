using UnityEngine;
using System.Collections;
using TMPro;


public class NotificationManager : MonoBehaviour
{
    public TMP_Text NotificationText;

    public void ShowNotification(string message)
    {
        NotificationText.text = message;
        StartCoroutine(HideNotificationAfterSeconds(3));
    }

    private IEnumerator HideNotificationAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        NotificationText.text = "";
    }
}


