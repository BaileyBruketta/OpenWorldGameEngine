
using UnityEngine;
public enum EquipmentType
{
    Submachinegun,
    Rifle,
    Pistol,
    Knife
}

[CreateAssetMenu]


public class EquippableItem : Item
{
    public int Strengthbonus;
    public int Agilitybonus;
    public int Vitalitybonus;
    public int Dexteritybonus;
    public int Powerbonus;

    [Space]

    public EquipmentType EquipmentType;



}