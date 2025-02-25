[System.Serializable]
public class ItemData
{
    public string Name;
    public string Description;

    public ItemData(string name, string description)
    {
        Name = name;
        Description = description;
    }
}