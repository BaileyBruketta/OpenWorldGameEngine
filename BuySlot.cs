using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuySlot : MonoBehaviour, IPointerClickHandler



{


    
    public event Action<Item> OnLeftClickEvent;
    public Item _item;


    public Item vectorsmg;
    public Item Tanto;
    public Item Apple;
    public Item HuntingRifle;
    public Item glocknine;
    
    public Text text;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                //image.enabled = false;
                text.enabled = false;

            }
            else
            {
                //image.sprite = _item.icon;
                //image.enabled = true;
                text.enabled = true;
                text.text = Item.GameName + " : " + Item.VendorPrice;
            }
        }
    }
    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Cli");
           if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (Item != null && OnLeftClickEvent != null)
            {
                Debug.Log("clicked");
                OnLeftClickEvent(Item);
            }
        }
    }
}