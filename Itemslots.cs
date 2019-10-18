using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Itemslots : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;
    [SerializeField] WeaponManagement weaponmanagement;
    [SerializeField] HUD hud;

    public event Action<Item> OnLeftClickEvent;
    public Item _item;
    public int goar;




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
                if (Item == Apple)
                {
                    hud.Eatapple();                   
                }
                if (Item == HuntingRifle)
                {
                    weaponmanagement.GrabHuntingRifle();
                }
                if (Item == vectorsmg)
                {
                    weaponmanagement.GrabVector();
                }
                if (Item == Tanto)
                {
                    weaponmanagement.GrabTanto();
                }
                if (Item == glocknine)
                {
                    weaponmanagement.GrabGlockNine();
                }
                OnLeftClickEvent(Item);

            }
        }
    }
}
