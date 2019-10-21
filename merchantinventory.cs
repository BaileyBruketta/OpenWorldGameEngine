using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class merchantinventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] merchantitemslot[] merchantitemslots;
    [SerializeField] HUD hud;


    public event Action<Item> OnItemLeftClickedEvent;




    private void Start()
    {
        for (int i = 0; i < merchantitemslots.Length; i++)
        {
            merchantitemslots[i].OnLeftClickEvent += OnItemLeftClickedEvent;
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


    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;

        }
        return false;
    }
    //tells us if the inventory is full
    public bool IsFull()
    {
        return items.Count >= merchantitemslots.Length;
        //inventory amount is equal or less than total itemslots 
    }
    //refreshes ui and 
    private void OnValidate()
    {
        if (itemsParent != null)
        {
            merchantitemslots = itemsParent.GetComponentsInChildren<merchantitemslot>();
        }
        RefreshUI();
    }

    //refreshes and ties itemslots to items list
    private void RefreshUI()
    {
        int i = 0;

        for (; i < items.Count && i < merchantitemslots.Length; i++)
        {
            merchantitemslots[i].Item = items[i];
        }

        for (; i < merchantitemslots.Length; i++)
        {
            merchantitemslots[i].Item = null;
        }
    }
}
