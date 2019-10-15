using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpVector : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    //this script attaches to any item that can be picked up 
    public Transform thisobject;
    public Transform player;
    public GameObject WeaponManager;
    //public GameObject InputCatcher;

    public float xdif;
    public float ydif;
    public float zdif;
    public float wholedif;
    //assign number in inspector relative to what the item is, each number calls a different function when grabbed
    public float number;

    public GameObject thisgun;
    public float ammo;


    // Start is called before the first frame update

    public void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Grab();
        }
    }
    // Update is called once per frame


    public void Grab()
    {
        
        wholedif = Vector3.Distance(thisgun.transform.position, player.transform.position);
        if (wholedif < 10)
        {
            pickup();
        }
    }

    public void pickup()
    {
        //number dictates what will be picked. able to be set in the inspector
        if (number == 1)  //vectro submachinegun
        {
           // WeaponManager.GetComponent<WeaponManagement>().GrabVector();
            //InputCatcher.GetComponent<GrabInputScript>().VectorGrabbed();
            WeaponManager.GetComponent<WeaponManagement>().Addninemilammo(ammo);
            inventory.AddItem(item);
            Destroy(thisgun);
        }
        if (number == 2) //apple
        {
            inventory.AddItem(item);
            Destroy(thisgun);
        }
        if (number == 3) //hunting rifle
        {
            //WeaponManager.GetComponent<WeaponManagement>().GrabHuntingRifle();
            inventory.AddItem(item);
            WeaponManager.GetComponent<WeaponManagement>().AddThreeOhEightAmmo(ammo);
            thisgun.SetActive(false);
        }
        if (number == 4) //tanto
        {
            inventory.AddItem(item);
            Destroy(thisgun);

        }
        if (number == 5) //meat or general
        {
            inventory.AddItem(item);
            thisgun.SetActive(false);
        }
    }


}
