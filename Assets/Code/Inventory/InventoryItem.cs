using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public InventoryItemData Data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void PrintItemNameToConsole()
    {
        Debug.Log("Item Name: " + Data.ItemName);
    }
}
