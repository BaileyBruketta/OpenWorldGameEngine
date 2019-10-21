using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinventoryformerchant : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] playeritemslotformerchant[] playeritemslotformerchant;


    public event Action<Item> OnItemLeftClickedEvent;




    private void Start()
    {
        for (int i = 0; i < playeritemslotformerchant.Length; i++)
        {
            playeritemslotformerchant[i].OnLeftClickEvent += OnItemLeftClickedEvent;
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
        return items.Count >= playeritemslotformerchant.Length;
        //inventory amount is equal or less than total itemslots 
    }
    //refreshes ui and 
    private void OnValidate()
    {
        if (itemsParent != null)
        {
            playeritemslotformerchant = itemsParent.GetComponentsInChildren<playeritemslotformerchant>();
        }
        RefreshUI();
    }

    //refreshes and ties itemslots to items list
    private void RefreshUI()
    {
        int i = 0;

        for (; i < items.Count && i < playeritemslotformerchant.Length; i++)
        {
            playeritemslotformerchant[i].Item = items[i];
        }

        for (; i < playeritemslotformerchant.Length; i++)
        {
            playeritemslotformerchant[i].Item = null;
        }
    }
}
