using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryItemType {EQUIPMENT, CONSUMABLE, KEY }

[CreateAssetMenu(fileName = "newInventoryItem", menuName = "Inventory/Inventory Item")]
public class InventoryItemData : ItemData
{
    [SerializeField]
    private string itemName;
    public override string ItemName { get => itemName; set => itemName = value; }

    [SerializeField]
    private InventoryItemType itemType;
    public override InventoryItemType ItemType { get => itemType; set => itemType = value; }

    [SerializeField]
    private bool isStackable;
    public override bool IsStackable { get => isStackable; protected set => isStackable = value; }

    [SerializeField]
    private float marketValue;
    public override float MarketValue { get => marketValue; set => marketValue = value; }

}
