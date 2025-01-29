using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class OnButtonSelected : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        transform.DOScale(1.075f, 0.075f).SetEase(Ease.InOutQuad);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        transform.DOScale(1f, 0.075f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }


    
}
