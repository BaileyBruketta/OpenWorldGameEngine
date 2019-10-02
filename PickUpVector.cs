using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpVector : MonoBehaviour
{
    public Transform thisobject;
    public Transform player;
    public GameObject WeaponManager;
    public GameObject InputCatcher;

    public float xdif;
    public float ydif;
    public float zdif;
    public float wholedif;
    //assign number in inspector relative to what the item is, each number calls a different function when grabbed
    public float number;

    public GameObject thisgun;
    public float ammo;

    
    // Start is called before the first frame update
  

    // Update is called once per frame
   

    public void Grab()
    {
        if (thisobject.transform.position.x > player.transform.position.x)
        {
            xdif = thisobject.transform.position.x - player.transform.position.x;
        }
        else xdif = player.transform.position.x - thisobject.transform.position.x;

        if (thisobject.transform.position.y > player.transform.position.y)
        {
            ydif = thisobject.transform.position.y - player.transform.position.y;
        }
        else ydif = player.transform.position.y - thisobject.transform.position.y;

        if (thisobject.transform.position.z > player.transform.position.z)
        {
            zdif = thisobject.transform.position.z - player.transform.position.z;
        }
        else zdif = player.transform.position.z - thisobject.transform.position.z;



        wholedif = xdif + ydif + zdif;

        if (wholedif < 10)
        {
            pickup();
        }
    }

    public void pickup()
    {
        if (number == 1)
        {
            WeaponManager.GetComponent<WeaponManagement>().EquipVector();
            InputCatcher.GetComponent<GrabInputScript>().VectorGrabbed();
            WeaponManager.GetComponent<WeaponManagement>().Addninemilammo(ammo);
            Destroy(thisgun);
        }
    }


}
