using UnityEngine;
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite icon;
    public string GameName;
    public float VendorPrice;
    public float PlayerPrice;

}
