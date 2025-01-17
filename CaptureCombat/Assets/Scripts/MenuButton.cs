using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject menuPanel;
    
    public void OpenMenuPanel(){
        menuPanel.SetActive(true);
    }
}
