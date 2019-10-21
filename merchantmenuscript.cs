using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class merchantmenuscript : MonoBehaviour
{
    [SerializeField] playerinventoryformerchant playerinventory;
    [SerializeField] merchantinventory merchantinventory;
    private void Awake()
    {
        playerinventory.OnItemLeftClickedEvent += SellFromInventory;
        merchantinventory.OnItemLeftClickedEvent += BuyFromMerchantInventory;
    }

    private void SellFromInventory(Item item)
    { //put if != quest item here later
        
            Sell((EquippableItem)item);        
    }

    private void BuyFromMerchantInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Buy((EquippableItem)item);
        }
    }


    public void Sell(EquippableItem item)
    {
        if (playerinventory.RemoveItem(item))
        {

            merchantinventory.AddItem(item);
           
        }
    }

    public void Buy(EquippableItem item)
    {
        if (!playerinventory.IsFull() && merchantinventory.RemoveItem(item))
        {
            playerinventory.AddItem(item);
        }
    }
}
