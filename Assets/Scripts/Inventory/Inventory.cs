using System;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private string saveDestination => Application.persistentDataPath + "/save.data";

    private ItemList<ItemData> itemList;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        itemList = LoadItemList(init:true);
        Instance = this;
    }

    private void SaveItemList()
    {
        try
        {
            string saveData = JsonUtility.ToJson(itemList);
            File.WriteAllText(saveDestination, saveData);
        }
        catch(Exception e)
        {
            
        }
    }

    private ItemList<ItemData> LoadItemList(bool init = false)
    {
        if (!File.Exists(saveDestination)) return new ItemList<ItemData>();

        try
        {
            string OldData = File.ReadAllText(saveDestination);
            itemList = JsonUtility.FromJson<ItemList<ItemData>>(OldData);
            return itemList;
        }
        catch(Exception e)
        {
            Debug.Log("Failed to load items");
        }
        return new ItemList<ItemData>();
    }
}