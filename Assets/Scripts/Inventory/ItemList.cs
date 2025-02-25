using System;
using System.Collections.Generic;

[Serializable]
public struct ItemList<T>
{
    public List<T> Items;
}