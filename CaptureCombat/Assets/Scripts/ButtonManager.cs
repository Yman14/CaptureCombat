using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameManager gameManager;

    public void CaptureButtonPressed()
    {
        gameManager.CaptureRandomCreature();
    }

    
}
