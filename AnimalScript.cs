using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public float gar;
    public GameObject meat;
    public float health;
    public float maximumhealth;
    public bool scared;
    public float xyzdiftoplayer;
    public Transform player;
    public float distancethreshold;
    public float maxwalk;
    public float maxrun;
    public float walkspeed;
    public float runspeed;
    public float playertimer;
    public float locationfloat;
    Rigidbody rb;
    public float wandertime;
    public bool dead;
    public bool unnadded;
    public float speed;
    public float maxvelocity;
    public float xyzdif;
    public float closethreshold;
    [SerializeField] HitBoxController HitBoxManager;
    Animator anim;
    public float animalnumber;
    public float RAYCASTSIGHT;
    public float checktimer;
   
    //0=elk, 1=eagle
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meat.SetActive(false);
        anim = GetComponent<Animator>();
        wandertime = 150;
        health = maximumhealth;
        speed = walkspeed;
        maxvelocity = maxwalk;
        scared = false;
        anim.SetBool("walking", true);
        anim.SetBool("running", false);
        checktimer = 3;
    }

    // Update is called once per frame
    public void GetTheUpdate()
    {
        Debug.Log("animalupdate");
        moving();
        
        checktimer -= 1f;
        if(checktimer < 1){
            checkforplayer();
        }
        
    }
    
    public void moving()
    {
        Debug.Log("animalmoving");

        

        if (dead == false)
        {
            wandertime -= 1;

            if (wandertime < 2)
            {
                Wander();
            }
            //rb.Sleep();
            // rb.WakeUp();
            HitBoxManager.GetComponent<HitBoxController>().UpdateBoxes();
            var v = rb.velocity;
            rb.AddRelativeForce(Vector3.forward * speed);
            //rb.AddForce(transform.up * 3);
            rb.velocity = v.normalized * maxvelocity;

            

            HitBoxManager.GetComponent<HitBoxController>().UpdateBoxes();
        }
    }
    public void checkforplayer()
    {
        xyzdif = Vector3.Distance(transform.position, player.transform.position);
        if (xyzdif < closethreshold)
        {
            Scary();
        }

        int layerMask = (1 << 9) | (1 << 10) | (1 << 11);  //npc layer and npc hitbox layer
        layerMask = ~layerMask; //inverts raycast so raycast avoids these layers 

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, RAYCASTSIGHT, layerMask))
        {
            Debug.Log("whatsinfront");
            rb.Sleep();
            rb.WakeUp();
            transform.eulerAngles = new Vector3(0, Random.Range(0, 40), 0);
        }

        RaycastHit hit2;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit2, 80, layerMask))
        {

            Debug.Log("Terraintula");
            var ydif = Vector3.Distance(transform.position, hit2.point);
            gar = transform.position.y - ydif;
            var var = gar + 1.5f;



            transform.position = new Vector3(transform.position.x, var, transform.position.z);


        }

        checktimer = 3;
    }
    public void Scary()
    {
        speed = runspeed;
        maxvelocity = maxrun;
        anim.SetBool("running", true);
        anim.SetBool("walking", true);
    }
    void Wander()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        wandertime = 150;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            die();
            
        }
    }
    public void die()
    {
        rb.Sleep();
        dead = true;
        meat.SetActive(true);
        if (animalnumber==1)
        {
            birdthings();
        }
    }
    public void birdthings()
    {
        rb.useGravity = true;
    }
}
