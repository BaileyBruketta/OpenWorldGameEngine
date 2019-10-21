using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class merchantitemslot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;
    
    [SerializeField] HUD hud;
    [SerializeField] Inventory inventory;
     public event Action<Item> OnLeftClickEvent;
    public Item _item;
    public int goar;
    public float creds;
    public float playercurrency;




    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;

            }
            else
            {
                image.sprite = _item.icon;
                image.enabled = true;
            }
        }
    }
    private Item _Item;

    public Item vectorsmg;
    public Item Tanto;
    public Item Apple;
    public Item HuntingRifle;
    public Item glocknine;
    protected virtual private void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (Item != null && OnLeftClickEvent != null)
            {
                playercurrency = hud.commonwealthcredits;
                if (Item = vectorsmg)
                {
                    if (playercurrency > 319)
                    {
                        creds = -320;
                        
                        hud.ChangeCredits(creds);
                        inventory.AddItem(vectorsmg);
                    }
                }
                if (Item = Tanto)
                {
                    if (playercurrency > 11)
                    {
                        creds = -12;
                        
                        hud.ChangeCredits(creds);
                        inventory.AddItem(Tanto);
                    }
                }
                if (Item = HuntingRifle)
                {
                    if (playercurrency > 169)
                    {
                        creds = -170;

                        hud.ChangeCredits(creds);
                        inventory.AddItem(HuntingRifle);
                    }
                }
                OnLeftClickEvent(Item);

            }
        }
    }
}
