
public class EquipmentSlots : Itemslots
{
    public EquipmentType EquipmentType;

    protected override private void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString() + " Slot";
    }
    

    
}
