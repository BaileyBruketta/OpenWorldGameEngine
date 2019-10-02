using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public GameObject playerhud;
    public float damagetoplayer;
    //for detecting player shot sound
    public float x;
    public float y;
    public float z;
    public float xyzdif;
    public float shotdetectiontimer;
    public float shotdetectiontimernew;

    
    public bool unselected;
    public float selectiontimer;

    public float Sneakmeter;
    public float Sneakmeterdecrease;

    //for alerting other enemies to player presence
    public GameObject npcmanager;


    public Transform playercenter;
    public GameObject HitBoxManager;
    //Things are gonna be set in the inspector
    //general use NPC script
    public float health;
    public float sightrange;
    public Transform player;
    public bool isalert;

    //for enemies hearing shots
    public float shotclock;
    public float shotclockdecrease;
    
    public float stun;
    public bool isdamaged;
    
    //how long it takes for npc to notice you 
    public float attentionmeter;
    public float attentionmeterdecreasespotted;
    public float attentionmeterdecrease;
    //npc
    public GameObject NPC; //this particular unit
    public GameObject npcmaster; //calls npc scripts
    //raycasts occur from the NPCs head so that turning animations allow enemy's line of sight to change
    public Transform enemyhead;
    public GameObject NPCROTATOR;
    //time between shots and first shot
    public float RateOfFire;
    public float RateOfFireDecrease;
    public float NewRateOfFire;

    public float EnemyClassification;
    //if 0, enemy walks, runs, squats, etc and is hostile
    //if 1, enemy is idle or squatting, and hostile
    public float magazine;

    public Transform GunMuzzle;
    public GameObject MuzzleFlash;
    public GameObject GunSmoke;

    public GameObject blood;

    public float damage;
    public float healthmax;

    //for rotating an injured and confused npc
    public bool ishurt;
    public float hurtrotationspeed;

    //for rndomized new actions by npc
    public float NewActionTimer;
    private float NewFacingAngle;
    public float NewActionNumber;
    public float NewActionThreshold;
    public float NewActionDecreaseSpeed;
    //for setting frequency of npc actions
    private float Timewalking;
    public float walkingparam1;
    public float walkingparam2;
    private float TimeIdling;
    public float idlingparam1;
    public float idlingparam2;
    private float TimeSquatting;
    public float squattingparam1;
    public float squattingparam2;
    public float TimeTurning;
    public bool Turning;
    

    private float speeder;
    private float speed;
    private float limit;
    public float maxspeed;
    public float speedthreshold;

    Rigidbody rb;
    Animator anim;

    public bool isdead;
    
   



    void Start()

    {
        
        isalert = false;
        
        rb = GetComponent<Rigidbody>();
        anim = npcmaster.GetComponent<Animator>();
        NewAction();
        NPCROTATOR.SetActive(false);
        unselected = true;
        
        
    }

    // Update is called once per frame
    

    public void TakeDamage(float damage)
    {
        health -= damage;
        DamageAlert();
        if (health <= 0)
        {
            isdead = true;
            rb.Sleep();
            rb.WakeUp();
            Die();
        }
    }
    public void Die()
    {
        // anim.SetTrigger("StopLooking");
            anim.SetTrigger("Die");
            anim.SetBool("Death", true);
            NPCROTATOR.SetActive(false);
            isdead = true;
        

        
        
    }
    //new actions for npcs
    public void Looking()
    {
        // NewFacingAngle = (Random.Range(-60, 60));
        //transform.RotateAround(transform.position, transform.up, NewFacingAngle);
        NPCROTATOR.SetActive(true);
        anim.SetTrigger("LookAround");
    }
    public void Walking()
    {
        if (rb.velocity.magnitude < speedthreshold)
        {
            speed = maxspeed;
        }
        else speed = speeder / 2;
        limit = maxspeed;
        speeder = limit - rb.velocity.magnitude - 2;
        rb.AddRelativeForce(Vector3.forward * speed);
    }
    public void Running()
    {

    }
    public void Aiming()
    {

    }
    public void Squatting()
    {

    }
    public void Idling()
    {
        anim.SetBool("Idling", true);
    }
    public void Turningz()
    {
        rb.Sleep();
        rb.WakeUp();
        anim.SetTrigger("Shuffle"); //plays the shuffling animation
        NewFacingAngle = (Random.Range(-60, 60));
        transform.RotateAround(transform.position, transform.up, NewFacingAngle); //quick turns the enemy to a randomized angle
        Turning = true;
    }
    public void Actions()
    {
        if (NewActionTimer < NewActionThreshold)
        {
            NewAction();
        }
        if (NewActionTimer == NewActionThreshold)
        {
            NewAction();
        }
        if (NewActionTimer > NewActionThreshold)
        {
            NewActionTimer -= NewActionDecreaseSpeed;
        }
    }
    //movement and correspon
    public void Movement()
    {
        if (isalert == false) //only works if not alert and aiming
        {

            if (ishurt == false)
            {
                if (NewActionNumber == 0)   //walking
                {
                    Walking();

                }
                if (NewActionNumber == 1)   //squatting
                {
                    Squatting();
                }
                if (NewActionNumber == 2)   //turning when not under fire
                {                    
                        if (Turning == false)
                        {
                            Turningz();
                        }                                            
                }
                if (NewActionNumber == 3)   // idling or standing about 
                {
                    Idling();

                }
            }
            if (ishurt == true)  //for when it hears a shot
            {
                if (isalert == false)
                {
                    Looking();
                }
            }
        }

    }
    public void NewAction()
    {
        if (EnemyClassification == 0)
        {
            NewActionNumber = (Random.Range(0, 4));
            if (NewActionNumber == 0) //makes the enemy walk in a straight line
            {
                anim.SetBool("Walking", true);
                anim.SetBool("Squatting", false);
                anim.SetBool("Idling", false);
                rb.WakeUp();
                Timewalking = Random.Range(walkingparam1, walkingparam2);
                NewActionTimer = Timewalking;
            }
            if (NewActionNumber == 1) //makes the enemy stop and squat
            {
                rb.Sleep();
                anim.SetBool("Squatting", true);
                anim.SetBool("Walking", false);
                anim.SetBool("Idling", false);
                TimeSquatting = Random.Range(squattingparam1, squattingparam2);
                NewActionTimer = TimeSquatting;
            }
            if (NewActionNumber == 2) //makes the enmy switch directions instantly
            {
                Turning = false;
                NewActionTimer = TimeTurning;
            }
            if (NewActionNumber == 3) //makes the enemy stand and do nothing/little
            {
                rb.Sleep();
                anim.SetBool("Idling", true);
                anim.SetBool("Walking", false);
                anim.SetBool("Squatting", false);
                TimeIdling = Random.Range(idlingparam1, idlingparam2);
                NewActionTimer = TimeIdling;
            }
        }
        if (EnemyClassification == 1)
        {
            NewActionNumber = (Random.Range(5,7)); //different numbers 
            //converts action number for this type of unit
            if (NewActionNumber == 5)
            {
                NewActionNumber = 3;
            }
            if (NewActionNumber == 6)
            {
                NewActionNumber = 1;
            }

            if (NewActionNumber == 3) //makes the enemy stand and do nothing/little
            {
                rb.Sleep();
                anim.SetBool("Idling", true);
                anim.SetBool("Walking", false);
                anim.SetBool("Squatting", false);
                TimeIdling = Random.Range(idlingparam1, idlingparam2);
                NewActionTimer = TimeIdling;
            }

            if (NewActionNumber == 1) //makes the enemy stop and squat
            {
                rb.Sleep();
                anim.SetBool("Squatting", true);
                anim.SetBool("Walking", false);
                anim.SetBool("Idling", false);
                TimeSquatting = Random.Range(squattingparam1, squattingparam2);
                NewActionTimer = TimeSquatting;
            }
        }
    }
    public void LineOfSight() //how the enemy spots the player
    {
        if (ishurt == false)
        {
            Vector3 targetDir = player.position - transform.position; //angle of peripheral vision with enemys head as one line of the angle
            float angle = Vector3.Angle(targetDir, transform.forward);
            if (angle < 50) //if player is within peripheral view
            {
                attentionmeter -= attentionmeterdecrease;//decrease the time until enemy registers the player
                if (attentionmeter < 8) //if it has been a sufficient amount of time
                {
                    NPCROTATOR.SetActive(false);
                    transform.LookAt(playercenter);
                    anim.SetBool("Aiming", true);
                   // anim.SetTrigger("StopLooking");
                    
                    isalert = true;
                    
                    
                    rb.Sleep();
                    rb.WakeUp();//rotate to look at the player
                                //make the enemy stop looking around if relevent
                     //make the enemy aim

                    RaycastHit hit; //
                    int layerMask = (1 << 9) | (1 << 10);  //npc layer and npc hitbox layer
                    layerMask = ~layerMask; //inverts raycast so raycast avoids these layers 
                    if (Physics.Raycast(transform.position, transform.forward, out hit, sightrange, layerMask)) //sends a ray from the enemys head 
                    {
                        Rotator target = hit.transform.GetComponent<Rotator>();
                        if (target != null) //if the ray hits the player
                        {
                            attentionmeter -= attentionmeterdecreasespotted;  //more time to register 
                            if (attentionmeter < 1)  //sufficent passage of time
                            {
                                Alert();  //enemy is now alert
                                RateOfFire -= RateOfFireDecrease;  //getting ready to fire
                               // npcmanager.GetComponent<NpcManagement>().WeGotemboys();  //let npcmanager know to tell other npcs to ook around

                                if (RateOfFire < 1)
                                {
                                    TakeShot();
                                }
                            }
                        }
                    }
                }

            }
        }
        if (ishurt == true)
        {
            Vector3 targetDir = player.position - enemyhead.transform.position; //angle of peripheral vision with enemys head as one line of the angle
            float angle = Vector3.Angle(targetDir, transform.forward);
            if (angle < 20) //if player is within peripheral view
            {
               // anim.SetTrigger("StopLooking");
                NPCROTATOR.SetActive(false);
                transform.LookAt(playercenter);
                anim.SetBool("Aiming", true);
                rb.Sleep();
                rb.WakeUp();
                ishurt = false;
                isalert = true;

                attentionmeter -= attentionmeterdecreasespotted;//decrease the time until enemy registers the player
                if (attentionmeter < 8) //if it has been a sufficient amount of time
                {
                    //anim.SetTrigger("StopLooking");
                    anim.SetBool("Aiming", true);
                    TakeShot();
                    isalert=true;
                    ishurt = false;
                    transform.LookAt(playercenter); //rotate to look at the player
                                                    //make the enemy stop looking around if relevent
                     //make the enemy aim
                    
                    RaycastHit hit; //
                    int layerMask = (1 << 9) | (1 << 10);  //npc layer and npc hitbox layer
                    layerMask = ~layerMask; //inverts raycast so raycast avoids these layers 
                    if (Physics.Raycast(transform.position, transform.forward, out hit, sightrange, layerMask)) //sends a ray from the enemys head 
                    {
                        Rotator target = hit.transform.GetComponent<Rotator>();
                        if (target != null) //if the ray hits the player
                        {
                            attentionmeter -= attentionmeterdecreasespotted;  //more time to register 
                            if (attentionmeter < 1)  //sufficent passage of time
                            {
                                Alert();  //enemy is now alert
                                RateOfFire -= RateOfFireDecrease;  //getting ready to fire
                               // npcmanager.GetComponent<NpcManagement>().WeGotemboys();  //let npcmanager know to tell other npcs to ook around

                                if (RateOfFire < 1)
                                {
                                    TakeShot();
                                }
                            }
                        }
                    }
                }

            }
        }
    }
    //calledby an outside timer
    public void GetTheUpdate()
    {
        if (isdead == false)
        {
            LineOfSight();
            Movement();
            Actions();
        }
        HitBoxManager.GetComponent<HitBoxController>().UpdateBoxes();
    }

    public void Alert()
    {
        
        isalert = true;
        ishurt = false;
        anim.SetBool("Aiming", true);
       // anim.SetTrigger("StopLooking");
        rb.Sleep();
    }
    public void ShotsFired() //turns npc to player when within range and player shoots
    {
        if (ishurt == true)
        {
            x = player.transform.position.x - transform.position.x;
            y = player.transform.position.y - transform.position.y;
            z = player.transform.position.z - transform.position.z;
            xyzdif = x + y + z;
            if (xyzdif < 90)
            {
                if (xyzdif > -90)
                {
                    shotclock -= shotclockdecrease;
                }
            }
        } 
        if (shotclock<2)
        {
            if (isalert == false)
            {
                transform.LookAt(player);
                isalert = true;
            }
        }
    }
    public void Located()
    {
        x = player.transform.position.x - transform.position.x;
        y = player.transform.position.y - transform.position.y;
        z = player.transform.position.z - transform.position.z;
        xyzdif = x + y + z;
        if (xyzdif < 20)
        {
            if (xyzdif > -20)
            {
                enemyhearing();
                if (Sneakmeter < 26)
                {
                    
                    ishurt = true;
                }
                if (Sneakmeter < 2)
                {
                    transform.LookAt(player);
                }
            }
            else enemycalms();
        }
    }
    public void enemyhearing()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Sneakmeter -= Sneakmeterdecrease;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Sneakmeter -= Sneakmeterdecrease;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Sneakmeter -= Sneakmeterdecrease;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Sneakmeter -= Sneakmeterdecrease;
        }
        
    }
    public void enemycalms()
    {
        if (Sneakmeter < 31)
        {
            Sneakmeter += Sneakmeterdecrease;
        }
        if (Sneakmeter > 30)
        {
            ishurt = false;
            NPCROTATOR.SetActive(false);
        }
    }


    public void resetdetetcion()
    {
        shotdetectiontimer = 100;
        ishurt = false;
        isalert = false;
    }
    public void DamageAlert()
    {
        ShotsFired();
        if (isdead == false)
        {
            if (ishurt == false)
            {
                
                if (isalert == false)
                {
                    NPCROTATOR.SetActive(true);
                    Sneakmeter = 0;
                    ishurt = true;
                    //anim.SetTrigger("Shuffle");
                }
            }
        }
    }
    public void TakeShot()
    {
        anim.SetTrigger("Fire");
        RaycastHit hit;
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        if (Physics.Raycast(transform.position, transform.forward, out hit, sightrange, layerMask))
        {
            Rotator target = hit.transform.GetComponent<Rotator>();
            if (target != null)
            {
                GameObject blik = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                blik.transform.SetParent(target.transform);
                playerhud.GetComponent<HUD>().TakeDamage(damagetoplayer);
            }
        }
        Instantiate(GunSmoke, GunMuzzle.position, GunMuzzle.rotation);
        Instantiate(MuzzleFlash, GunMuzzle.position, GunMuzzle.rotation);
        RateOfFire = NewRateOfFire;
    }

}
