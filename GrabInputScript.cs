using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInputScript : MonoBehaviour
{
    //This script exists to watch for when the player presses E, and then call to all items that can be picked up to see if the player is within range 
    public GameObject Vectro;
    public bool Vectrino;
    
    void Start()
    {
        Vectrino = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItems();
        }
    }
    //checks to see if player is close, calls on the actual items script, the pickupvector script 
    public void CheckItems()
    {
        if (Vectrino == false)
        {
            Vectro.GetComponent<PickUpVector>().Grab();
        }
    }


    //callable to let this script know that a weapon is gone, reduces check time

    public void VectorGrabbed()
    {
        Vectrino = true;
    }


}
