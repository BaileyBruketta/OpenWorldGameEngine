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
                if (Item = vectorsmg)
                {
                    creds = -320;
                    playercurrency = hud.commonwealthcredits;
                    hud.ChangeCredits(creds);
                }
                if (Item = Tanto)
                {
                    creds = -12;
                    playercurrency = hud.commonwealthcredits;
                    hud.ChangeCredits(creds);
                }
                if (Item = HuntingRifle)
                {
                    creds = -170;
                    playercurrency = hud.commonwealthcredits;
                    hud.ChangeCredits(creds);
                }
                OnLeftClickEvent(Item);

            }
        }
    }
}
