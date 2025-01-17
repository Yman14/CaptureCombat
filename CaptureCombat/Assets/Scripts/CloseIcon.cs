using UnityEngine;
using System;

public class CloseIcon : MonoBehaviour
{
    public void CloseIconButton()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
