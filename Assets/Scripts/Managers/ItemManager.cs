using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;
using UnityEngine.ResourceManagement.ResourceLocations;


public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;

    [SerializeField] GameObject[] itemPrefabs = new GameObject[7]; //Depends on Item numbers
    [SerializeField] List<GameObject> items = new List<GameObject>();
    
    ItemText myText;
    public ItemText MyText
    {
        get => myText;
        set
        {
            myText = value;
        }
    }
    
    bool[] hasItems = new bool[6];
    public bool[] HasItems
    {
        get => hasItems;
        set
        {
            hasItems = value;
        }
    }


    Dictionary<int, Item.ItemType> myItem = new Dictionary<int, Item.ItemType>();
    Dictionary<int, Item.ItemType> currentItem = new Dictionary<int, Item.ItemType>();
    Dictionary<Item.ItemType, GameObject> itemList = new Dictionary<Item.ItemType, GameObject>();

    Dictionary<string, Object> itemdict = new Dictionary<string, Object>();
    

    public Action<Item.ItemType, int> SetInventory;
    

    public static ItemManager Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

    }

    private void Start()
    {
        
    }

    public void GetItem(Item.ItemType type)
    {
        for (int i = 0; i < hasItems.Length; i++)
        {
            if (!hasItems[i])
            {
                hasItems[i] = true;
                myItem[i] = type;
                items.Add(itemList[type]);
                SetInventory(type, i);
                break;
            }
        }
    }

    public void UseItem(int index)
    {
        if (hasItems[index] == false) return;

        if (items[index].GetComponent<Item>().Usable == false)
        {
            return;
        }
        items.RemoveAt(index);
        hasItems[index] = false;
        myItem[index] = Item.ItemType.None;

        IEnumerable dicindex = Enumerable.Range(0, myItem.Count)
                            .Where(i => myItem[i] != Item.ItemType.None);
        
        IEnumerator enumerator = dicindex.GetEnumerator();
        
        
        for(int i = 0; enumerator.MoveNext() == true; i++)
        {
            currentItem[i] = myItem[(int)enumerator.Current];
        }

        int orderindex = Enumerable.Range(0, hasItems.Length)
            .Where(i => hasItems[i] == true)
            .Count();
        
        for(int i = 0; i < orderindex; i++)
        {
            hasItems[i] = true;
            SetInventory(currentItem[i], i);
        }

        for(int i = orderindex; i < hasItems.Length; i++)
        {
            hasItems[i] = false;
            SetInventory(Item.ItemType.None, i);
        }


        if (myItem.Count == 0) return;
        for (int i = 0; i < currentItem.Count; i++)
        {
            myItem[i] = currentItem[i];
        }
    }


    public int SearchItem(Item.ItemType type)
    {
        for (int i = 0; i < hasItems.Length; i++)
        {
            if (hasItems[i] && myItem[i] == type)
                return i;
        }
        return -1;
    }

    public Sprite GetSprite(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.Key:
                return itemPrefabs[0].GetComponent<Image>().sprite;
            
            case Item.ItemType.Cat:
                return itemPrefabs[1].GetComponent<Image>().sprite;

            case Item.ItemType.Letter:
                return itemPrefabs[2].GetComponent<SpriteRenderer>().sprite;
            
            default:
                return null;
        }
    }

    public void ClickItem(int index)
    {
        if (index == -1)
        {
            MyText.MyText.text = string.Format("");
            return;
        }

        else if (HasItems[index] == false) return;

        switch(myItem[index])
        {
            case Item.ItemType.Key:
                MyText.MyText.text = string.Format("키다");
                break;
                
            case Item.ItemType.Cat:
                MyText.MyText.text = string.Format("고양이다");
                break;

            case Item.ItemType.Letter:
                MyText.MyText.text = string.Format("편지다");
                break;
                
            default:
                break;
        }
    }

    

    
}
