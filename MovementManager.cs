using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] HUD hud;
    [SerializeField] NpcManagement npcManagement;
    public bool w;
    public bool a;
    public bool s;
    public bool d;
    public bool sp;

    //necesasry for player
    public GameObject player;
    Rigidbody rb;
    public float maxVelocity;
    public float speeder;
    public float speed;
    public float limit;
    public float jumptimer;

    CapsuleCollider col_size;
    public bool iscrouching;
    public Transform stabspacething;
    public Transform stabspacething2;
    public Transform stabspace;
    public bool grounded;

    public GameObject Weaponmanj;
    //for calling to weapons walk, run, or ,idle statii
    NpcManagement manj;
    WeaponManagement weps;
    
    void Start()
    {
        jumptimer = 10;
        Cursor.visible = false;
        rb = player.GetComponent<Rigidbody>();
        col_size = player.GetComponent<CapsuleCollider>();
        manj = npcManagement.GetComponent<NpcManagement>();
        weps = Weaponmanj.GetComponent<WeaponManagement>();
    }

    // Update is called once per frame
    public void Update()
    {
        speed =100;
        jumptimer -= 1;
        maxVelocity = 1;
        rb.WakeUp();
        //set speeds
//        if (rb.velocity.magnitude < 5)
//        {
 //           speed = limit*2;
//        }
  //      else speed = speeder / 2;

    //    speeder = limit - rb.velocity.magnitude - 2;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 500;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.WakeUp();

            if (iscrouching)
            {
                iscrouching = false;
                speed = 300;
                rb.AddRelativeForce(Vector3.up * 300);
                col_size.height = 2.8f;
                col_size.center = new Vector3(0, -2.520422f, 0);
                npcManagement.Crouchoff();
                stabspace.position = stabspacething.position;
            }

            else
            {
                iscrouching = true;
                speed = 100;
                rb.AddRelativeForce(Vector3.up * 300);
                col_size.height = 1.4f;
                col_size.center = new Vector3(0, -1.260211f, 0);
                npcManagement.Crouchon();
                stabspace.position = stabspacething2.position;
            }

            jumptimer = 10;
        }
  //      else  maxVelocity = 2;

        //jump
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumptimer < 1)
            {
                //rb.Sleep();

                rb.AddRelativeForce(Vector3.up * 600);
                rb.WakeUp();
                sp = true;
                jumptimer = 80;
            }
        }
        else sp = false;

        

        
            var v = rb.velocity;
            
            if (Input.GetKey(KeyCode.W))
            {        
                rb.AddRelativeForce(Vector3.forward * speed);
                w = true;
                weps.Weaponwalk();
                rb.velocity = v.normalized * maxVelocity;
            }
            else w = false;
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddRelativeForce(Vector3.forward * -speed);
                s = true;
                weps.Weaponwalk();
                rb.velocity = v.normalized * maxVelocity;
            }
            else s = false;
            if (Input.GetKey(KeyCode.A))
            {                
                rb.AddRelativeForce(Vector3.right * -speed);
                a = true;
                weps.Weaponwalk();
                rb.velocity = v.normalized * maxVelocity;
            }
            else a = false;
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddRelativeForce(Vector3.right * speed);
                d = true;
                weps.Weaponwalk();
                rb.velocity = v.normalized * maxVelocity;
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
                            if (jumptimer < 1)
                            {
                                if (grounded == true)
                                {
                                    weps.Weaponstop();
                                    rb.Sleep();
                                }
                            }   
                        }
                    }
                }
            }
        
        manj.Updateus();
        
    }
    public void knifejump()
    {
      //  rb.Sleep();
       // a = true;
        //rb.WakeUp();
        //jumptimer = 5;
        //rb.AddRelativeForce(Vector3.forward * 1200);
    }
    public void GetPunched()
    {
        hud.Punchie();
        rb.Sleep();
        a = true;
        rb.WakeUp();
        jumptimer = 5;
        rb.AddRelativeForce(Vector3.forward * -2200);
    }
    public void antifloat()
    {
        grounded = false;
        
    }
    public void antifloat2()
    {
        grounded = true;
        
    }
}
