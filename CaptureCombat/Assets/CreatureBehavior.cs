using UnityEngine;

public class CreatureBehavior : MonoBehaviour
{
    private bool isCaptured = false;

    void OnMouseDown()
    {
        if (!isCaptured)
        {
            CaptureCreature();
        }
    }

    void CaptureCreature()
    {
        isCaptured = true;
        Debug.Log("Creature captured!");
        Destroy(gameObject); // Remove creature after capture
    }
}