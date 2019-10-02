using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public bool w;
    public bool a;
    public bool s;
    public bool d;

    //necesasry for player
    public GameObject player;
    Rigidbody rb;

    public float speeder;
    public float speed;
    public float limit;

    public GameObject Weaponmanj;   //for calling to weapons walk, run, or ,idle statii
    
    void Start()
    {
        Cursor.visible = false;
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.WakeUp();
        if (rb.velocity.magnitude < 5)
        {
            speed = 20;
        }
        else speed = speeder / 2;

        speeder = limit - rb.velocity.magnitude - 2;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {

            limit = 30;
        }
        else limit = 15;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * speed);
            //movementtimer = 3;
                w = true;
            Weaponmanj.GetComponent<WeaponManagement>().Weaponwalk();
        }
         else w = false;
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.forward * -speed);
            //movementtimer = 3;
                s = true;
            Weaponmanj.GetComponent<WeaponManagement>().Weaponwalk();
        }
         else s = false;
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.right * -speed);
           // movementtimer = 3;
               a = true;
            Weaponmanj.GetComponent<WeaponManagement>().Weaponwalk();
        }
         else a = false;
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * speed);
            //movementtimer = 3;
            d = true;
            Weaponmanj.GetComponent<WeaponManagement>().Weaponwalk();
        }
        else d = false;

        if (a == false)
        {
            if (w == false)
            {
                if (s == false)
                {
                    if (d == false)
                    {
                        Weaponmanj.GetComponent<WeaponManagement>().Weaponstop();
                        rb.Sleep();
                    }
                }
            }
        }
        
    }
}
