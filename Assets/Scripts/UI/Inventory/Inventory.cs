using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Image[] slots;



    void Start()
    {
        ItemManager.Instance.SetInventory += GetItem;
    }

    void GetItem(Item.ItemType type, int index)
    {
        switch(type)
        {
            case Item.ItemType.Key:
                slots[index].sprite = ItemManager.Instance.GetSprite(type);
                slots[index].gameObject.SetActive(true);
                break;

            case Item.ItemType.Cat:
                slots[index].sprite = ItemManager.Instance.GetSprite(type);
                slots[index].gameObject.SetActive(true);
                break;

            case Item.ItemType.None:
                slots[index].gameObject.SetActive(false);
                break;

            case Item.ItemType.Letter:
                slots[index].sprite = ItemManager.Instance.GetSprite(type);
                slots[index].gameObject.SetActive(true);
                break;
        }
        
    }
}
