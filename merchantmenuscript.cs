using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class merchantmenuscript : MonoBehaviour
{
    [SerializeField] playerinventoryformerchant playerinventory;
    [SerializeField] merchantinventory merchantinventory;
    [SerializeField] Inventory inventory;
    public Text commonwealthcreds;
    public float creds;
    public HUD hud;
    private void Awake()
    {
        playerinventory.OnItemLeftClickedEvent += SellFromInventory;
        merchantinventory.OnItemLeftClickedEvent += BuyFromMerchantInventory;
        creds = hud.commonwealthcredits;
        commonwealthcreds.text = "Commonwealth Credits : " + creds;
    }
   

    private void SellFromInventory(Item item)
    { //put if != quest item here later
        
            Sell((EquippableItem)item);
        creds = hud.commonwealthcredits;
        commonwealthcreds.text = "Commonwealth Credits : " + creds;
    }

    private void BuyFromMerchantInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Buy((EquippableItem)item);
            creds = hud.commonwealthcredits;
            commonwealthcreds.text = "Commonwealth Credits : " + creds;
        }
    }


    public void Sell(EquippableItem item)
    {
       // if (playerinventory.RemoveItem(item))
        //{
            playerinventory.RemoveItem(item);
            merchantinventory.AddItem(item);
            creds = hud.commonwealthcredits;
            commonwealthcreds.text = "Commonwealth Credits : " + creds;

       // }
    }

    public void Buy(EquippableItem item)
    {
        if (!playerinventory.IsFull())// && merchantinventory.RemoveItem(item))
        {
            merchantinventory.RemoveItem(item);
            playerinventory.AddItem(item);
            creds = hud.commonwealthcredits;
            commonwealthcreds.text = "Commonwealth Credits : " + creds;
        }
    }

    public void refresher()
    {
        playerinventory.RefreshUI();
    }
}
