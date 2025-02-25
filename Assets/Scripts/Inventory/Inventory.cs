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


    #region CRUD Operation
    public bool CreateItem(string Name, string Description)
    {
        itemList.Items.Add(new ItemData(Name, Description));
        return true;
    }

    public bool RetriveItem(string Name, out ItemData data)
    {
        data = itemList.Items.Find(x => x.Name == Name);
        return data != null;
    }

    public bool UpdateItemDescription(string Name, string Description)
    {
        int itemIndex = itemList.Items.FindIndex(x => x.Name == Name);
        if (itemIndex < 0) return false;

        itemList.Items[itemIndex].Description = Description;
        return true;
    }

    public bool DeleteItem(string Name)
    {
        int targetIndex = itemList.Items.FindIndex(x => x.Name == Name);
        if (targetIndex < 0) return false;

        itemList.Items.RemoveAt(targetIndex);
        return true;
    }
    #endregion


    #region Save Load
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
    #endregion Save Load
}