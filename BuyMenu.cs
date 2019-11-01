using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] HUD hud;
    [SerializeField] Transform itemsParent;
    public BuySlot[] buySlots;
    public List<Item> items;
    [SerializeField] Inventory inventory;
    public List<Item> defaultitems;
    float playercurrency;
    public Text currencytext;


    public event Action<Item> OnItemLeftClickedEvent;
    void Start()
    {
        for (int i = 0; i < buySlots.Length; i++)
        {
            buySlots[i].OnLeftClickEvent += OnItemLeftClickedEvent;
        }
    
        for (int x = 0; x < defaultitems.Count && x < buySlots.Length; x++)
        {
            AddItem(defaultitems[x]);
        }
        RefreshUI();

    }
    
    
    
    public bool AddItem(Item item) //as bool to see if it could be added
    {

        if (IsFull())
            return false;

        items.Add(item);//adds item to item list

        RefreshUI();
        return true;
    }
    public bool IsFull()
    {
        return items.Count >= buySlots.Length;
        //inventory amount is equal or less than total itemslots 
    }

    // Update is called once per frame
    private void RefreshUI()
    {
        int i = 0;

        for (; i < items.Count && i < buySlots.Length; i++)
        {
            buySlots[i].Item = items[i];
        }

        for (; i < buySlots.Length; i++)
        {
            buySlots[i].Item = null;
        }
    }
}
