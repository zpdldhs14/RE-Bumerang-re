using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Item : MonoBehaviour, IPointerDownHandler
{
    [Header("# Item Info")]
    public ItemType type;
    public enum ItemType { Key, Cat, Letter, None}
    [SerializeField] bool usable;

    

    public bool Usable
    {
        get => usable;
        set
        {
            usable = value;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ItemManager.Instance.GetItem(type);
        Destroy(gameObject);
    }


    
    


}
