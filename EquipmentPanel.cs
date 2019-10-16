using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlots[] equipmentSlots;

    public event Action<Item> OnItemLeftClickedEvent;

    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnLeftClickEvent += OnItemLeftClickedEvent;
        }

    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlots>();
    }

    public bool AddItem(EquippableItem Item, out EquippableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == Item.EquipmentType)
            {
                previousItem = (EquippableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = Item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }
    

    public bool RemoveItem(EquippableItem Item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == Item)
            {

                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
