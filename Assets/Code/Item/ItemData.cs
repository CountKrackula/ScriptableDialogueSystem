using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData: ScriptableObject
{
    public abstract string ItemName { get; set; }
    public abstract InventoryItemType ItemType { get; set; }
    public abstract bool IsStackable { get; protected set; }
    public abstract float MarketValue { get; set; }

}
