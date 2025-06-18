using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private HashSet<string> inventoryItems = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemId)
    {
        inventoryItems.Add(itemId);
    }

    public void RemoveItem(string itemId)
    {
        inventoryItems.Remove(itemId);
    }

    public bool HasItem(string itemId)
    {
        return inventoryItems.Contains(itemId);
    }
} 