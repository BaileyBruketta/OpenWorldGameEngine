using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMaster : MonoBehaviour
{
    public Transform Player;
    public float[] position1;
    public List<Item> items;
    public List<float> itemlist;
    [SerializeField] Inventory inventory;
    [SerializeField] WeaponManagement weaponmanagement;
    public Item TantoKnife;
    public Item TokhilPistol;
    public Item Vectorsmg;
    public Item HuntingRifle;
    public float ninemilammo;
    public float rifleammo;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
        public void SavePlayer()
        {
        position1[0] = Player.position.x;
        position1[1] = Player.position.y;
        position1[2] = Player.position.z;
        ninemilammo = weaponmanagement.NineMillimeterRounds;
        rifleammo = weaponmanagement.riflefloat;
        itemlist.Clear();
        items.Clear();
        for (int i=0; i < inventory.items.Count; i++)
        {
            items.Add(inventory.items[i]);
        }
        for(int i=0; i< inventory.items.Count; i++)
        {
            if (items[i] != null)
            {
                if (items[i] == TantoKnife)
                {
                    itemlist.Add(1);
                }
                else if (items[i] == TokhilPistol)
                {
                    itemlist.Add(2);
                }
                else if (items[i] == Vectorsmg)
                {
                    itemlist.Add(3);
                }
                else if (items[i] == HuntingRifle)
                {
                    itemlist.Add(4);
                }
            }
        }
        SaveSystemScript.Saveplayer(this);

        
    }
        public void LoadPlayer()
        {
            playerdatascript data = SaveSystemScript.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        itemlist.Clear();
        inventory.items.Clear();
        inventory.RefreshUI();

        for (int i = 0; i < data.items.Length; i++)
        {
            itemlist.Add(data.items[i]);
        }
        for (int i = 0; i < itemlist.Count; i++)
        {
            
                if (itemlist[i] == 1)
                {
                    items.Add(TantoKnife);
                    inventory.AddItem(TantoKnife);
                }
            else if (itemlist[i] == 2)
            {
                items.Add(TokhilPistol);
                inventory.AddItem(TokhilPistol);
            }
            else if (itemlist[i] == 3)
            {
                items.Add(Vectorsmg);
                inventory.AddItem(Vectorsmg);
            }
            else if (itemlist[i] == 4)
            {
                items.Add(HuntingRifle);
                inventory.AddItem(HuntingRifle);
            }

        }
        inventory.RefreshUI();
        Player.transform.position = position;
        ninemilammo = data.ninemilammo;
        weaponmanagement.NineMillimeterRounds = ninemilammo;
        rifleammo = data.rifleammo;
        weaponmanagement.riflefloat = rifleammo;


        
        


    }
}
