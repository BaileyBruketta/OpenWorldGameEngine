using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class UseableItem : Item
{
    public bool IsConsumable;
    public virtual void Use(InventoryManager inventorymanager)
    {

    }
}
