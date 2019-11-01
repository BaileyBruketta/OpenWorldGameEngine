using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buymanager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] BuyMenu buymenu;
    public float playercurrency;
    [SerializeField] HUD hud;
    
    public Text currencytext;


    // Start is called before the first frame update
    private void Awake()
    {
        buymenu.OnItemLeftClickedEvent += Buy;
        updatecurrency();
    }
    public void Buy(Item item)
    {
        if (playercurrency > item.VendorPrice)
        {
            inventory.AddItem(item);
            hud.ChangeCredits(-item.VendorPrice);
            updatecurrency();
        }
    }
    public void updatecurrency()
    {
        playercurrency = hud.commonwealthcredits;
        currencytext.text = "Remaining Credits: " + playercurrency;
    }
}
