using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAble : MonoBehaviour
{
    public float itemtype;
    //1=door
    public bool dooropen;
    
    public GameObject door1closed;
    public GameObject door2open;
    public Transform thisobject;
    public Transform player;
    public float xyzdif;
    
    // Start is called before the first frame update
    void Start()
    {
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
