using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<InventoryItemData> InventoryList;
    // Start is called before the first frame update
    void Start()
    {
        if(InventoryList == null)
        {
            InventoryList = new List<InventoryItemData>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
