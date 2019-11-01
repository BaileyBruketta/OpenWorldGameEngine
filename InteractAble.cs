using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAble : MonoBehaviour
{
    public float itemtype;
    //1=door
    //2=merchant
    public bool dooropen;
    
    public GameObject door1closed;
    public GameObject door2open;
    public Transform thisobject;
    public Transform player;
    public float xyzdif;
    public GameObject merchantmenu;
    public bool MenuUp;
    

    Rigidbody rb;
    public GameObject rotator;
    public GameObject animalmanager;
    public GameObject weaponmanager;
    public GameObject npcmanager;
    public GameObject movementmanager;
    public GameObject LookUpDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        if (itemtype == 1)
        {
            if (dooropen == true)
            {
                door1closed.SetActive(false);
                door2open.SetActive(true);
            }
            if (dooropen == false)
            {
                door2open.SetActive(false);
                door1closed.SetActive(true);
            }
        }
        MenuUp = false;
       

    }
  

    // Update is called once per frame
    public void CallCheck()
    {
        xyzdif = Vector3.Distance( thisobject.transform.position, player.transform.position);
        if (xyzdif < 4)
        {
            if (itemtype == 1)
            {
                Doorcheck();
            }
        }
        if (xyzdif < 8)
        {
            if (itemtype == 2)
            {
                Merchant();
            }
        }
        
        
    }
    public void Doorcheck()
    {
       
            if (dooropen == true)
            {
                CloseDoor();
                Debug.Log("closethedoor");
            }
            else if (dooropen == false)
            {
                OpenDoor();
                Debug.Log("Openthedoor");
            }
        
    }
    public void Merchant()
    {
        if (MenuUp == false)
        {
            rotator.GetComponent<Rotator>().enabled = false;
            animalmanager.SetActive(false);
            weaponmanager.SetActive(false);
            npcmanager.SetActive(false);
            movementmanager.SetActive(false);
            LookUpDown.GetComponent<LookUpDown>().enabled = false;
            rb.Sleep();
            Cursor.visible = true;
            //merchantmenu.GetComponent<merchantmenuscript>().refresher();
            MenuGoesUp();
        }else if (MenuUp == true)
        {
            rotator.GetComponent<Rotator>().enabled = true;
            animalmanager.SetActive(true);
            weaponmanager.SetActive(true);
            npcmanager.SetActive(true);
            movementmanager.SetActive(true);
            LookUpDown.GetComponent<LookUpDown>().enabled = true;
            rb.WakeUp();
            Cursor.visible = false;
            MenuGoesDown();
        }

    }
    public void MenuGoesUp()
        
    {
        MenuUp = true;
        merchantmenu.SetActive(true);
    }
    public void MenuGoesDown()
    {
        MenuUp = false;
        merchantmenu.SetActive(false);
    }
    public void OpenDoor()
    {
        dooropen = true;
        
        door1closed.SetActive(false);
        door2open.SetActive(true);
        
    }
    public void CloseDoor()
    {
        
        dooropen = false;
        door1closed.SetActive(true);
        door2open.SetActive(false);
       
        
    }
}
