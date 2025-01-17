using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreasureChestManager : MonoBehaviour
{
    public GameObject chestPrefab; // Prefab of the chest.
    public Transform rewardsPanel; // Panel to hold chest icons.
    public GameObject rewardPopup; // Popup for showing rewards.

    public void AddChest()
    {
        // Instantiate chest icon in rewards panel.
        GameObject newChest = Instantiate(chestPrefab, rewardsPanel);
        //newChest.GetComponent<Button>().onClick.AddListener(() => OpenChest(newChest));
        OpenChest(newChest);
    }

    public void OpenChest(GameObject chest)
    {
        // Play opening animation.
        Animator animator = chest.GetComponent<Animator>();
        animator.SetTrigger("OpenChest");

        // Show rewards after animation (use delay if needed).
        StartCoroutine(ShowRewards());
        Destroy(chest, 3f); // Remove chest after animation.
    }

    private IEnumerator ShowRewards()
    {
        yield return new WaitForSeconds(1.5f); // Wait for animation.
        rewardPopup.SetActive(true);
        // Populate rewards in popup.
        Debug.Log("Rewards granted!");
    }
}
