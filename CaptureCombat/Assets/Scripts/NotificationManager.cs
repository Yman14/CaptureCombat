using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;


public class NotificationManager : MonoBehaviour
{
    public TMP_Text NotificationText;
    public Image background; // Assign the Image component in the Inspector
    public float fadeDuration = 2f; // Duration of the fade
    private float targetAlpha = 1f; // Target alpha value (0 = fully transparent, 1 = fully opaque)


    public void ShowNotification(string message)
    {
        ShowBackground();
        NotificationText.text = message;
        StartCoroutine(HideNotificationAfterSeconds(3));
    }

    private IEnumerator HideNotificationAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideBackground();
        NotificationText.text = "";
    }

    private void ShowBackground()
    {
        // Get the current color
        Color currentColor = background.color;
        currentColor.a = targetAlpha;

        // Smoothly interpolate the alpha value over time
        //currentColor.a = Mathf.Lerp(currentColor.a, targetAlpha, Time.deltaTime / fadeDuration);

        // Apply the updated color back to the Image
        background.color = currentColor;
    }
        private void HideBackground()
    {
        // Get the current color
        Color currentColor = background.color;
        currentColor.a = 0;

        background.color = currentColor;
    }
}


