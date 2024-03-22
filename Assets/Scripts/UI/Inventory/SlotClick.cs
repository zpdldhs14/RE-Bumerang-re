using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotClick : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] int myIndex;

    public void OnPointerDown(PointerEventData eventData)
    {
        ItemManager.Instance.ClickItem(myIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemManager.Instance.ClickItem(-1);
    }
}
