using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public GameObject strobelight;
    public float seentimer;
    public bool seen;
    public GameObject rotationscript;
    private readonly VectorPid angularVelocityController = new VectorPid(33.7766f, 0, 0.2553191f);
    private readonly VectorPid headingController = new VectorPid(9.244681f, 0, 0.06382979f);

    public float angel1;
    public float angel2;
    public float experiencetogive;
    public GameObject aimableweapon;
    public GameObject animatedweaponpiece1;
    public GameObject animatedweaponpiece2;
    public GameObject animatedweaponpiece3;
    public float turnquotient;

    
    public Transform SPINE;
    
    public Transform enemyhead;
    public float sightrange;
    public Transform player;
    public Transform anglemaker1;
    public Transform anglemaker2;
    Animator anim;
    public float turnspeed;
    public float turntimer;
    public float turntimerstart;
    Rigidbody rb;
    public float RateOfFire;
    public float RateOfFireDecrease;
    public bool isalert;
    public float NewRateOfFire;
    public GameObject MuzzleSmoke;
    public Transform GunMuzzle;
    public GameObject MuzzleFlash;
    public GameObject blood;
    public Transform playercenter;
    public GameObject GunSmoke;
    [SerializeField] HUD playerhud;
    public float damagetoplayer;
    public GameObject actualweapon;
    public Transform NPC;
    public float xyzdif;
    public float Sneakmeterdecrease;
    public float Sneakmeter;
    public float sneakmeterstart;
    public float closethreshold;
    public float sneakmeterthreshold;
    public bool shotsfiredbool;
    public float health;
    public float maxhealth;
    public Transform TheStabSpace;
    public bool isdead;
    [SerializeField] NpcManagement npcmanager;
    [SerializeField] MovementManager movementManager;
    public float punchclock;
    [SerializeField] HitBoxController HitBoxManager;
    public float dummyweapontimer;
    public bool dummyweaponadded;
    public GameObject dummyweapon;
    public float NewActionTimer;
    public float NewActionThreshold;
    public float NewActionDecreaseSpeed;
    public float NewActionNumber;
    public float NewActionTimerStart;
    public float EnemyClassification;
    public float[] Location0xyz;
    public float[] Location1xyz;
    public float[] Location2xyz;
    public float[] Location3xyz;
    public float[] Location4xyz;
    
    public float locale;
    public bool firing;
    public float maxvelocity;
    public float speed;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isdead = false;
        health = maxhealth;
        shotsfiredbool = false;
        isalert = false;
        dummyweapontimer = 6;
        dummyweapon.SetActive(false);
        dummyweaponadded = false;
        firing = false;
        NewActionTimer = NewActionTimerStart;
        locale = 0;
        strobelight.SetActive(false);
        
    }
    public void GetTheUpdate() //called by outside npcmanager script
    {
        //rotationscript.SetActive(false);

        if (seen == true)
        {
            var lookDir = player.position - transform.position;
            lookDir.y = 0; // keep only the horizontal direction
            transform.rotation = Quaternion.LookRotation(lookDir);
        }

        rb.maxAngularVelocity = 5;
        xyzdif = Vector3.Distance(NPC.transform.position, player.transform.position);

        if (xyzdif < 40)
        {
            sightrange = 800000;
        }
        if (xyzdif > 40)
        {
            sightrange =0;
        }

        Debug.Log("gottheupdate" + gameObject.name);
        if (isdead == false)
        {
            RaycastHit hit; //
            int layerMask = (1 << 9) | (1 << 10)|(1<<11);  //npc layer and npc hitbox layer
            layerMask = ~layerMask; //inverts raycast so raycast avoids these layers 
            if (Physics.Raycast(SPINE.position, SPINE.forward, out hit, sightrange, layerMask))
            {
                playerhitbox target = hit.transform.GetComponent<playerhitbox>();
                if (target != null) //if the ray hits the player
                {
                    seen = true;
                    seentimer = 10;
                    strobelight.SetActive(true);
                    
                    rotationscript.SetActive(false);

                    shotsfiredbool = true;
                    Debug.Log("seen" + gameObject.name);
                    rb.Sleep();
                    rb.WakeUp();
                    Punch();
                    anim.SetBool("Aiming", true);
                    var lookDir = player.position - transform.position;
                    lookDir.y = 0; // keep only the horizontal direction
                    transform.rotation = Quaternion.LookRotation(lookDir);
                    anim.SetTrigger("Shuffle");

                    RateOfFire -= RateOfFireDecrease;  //getting ready to fire
                                                        npcmanager.GetComponent<NpcManagement>().JustFired();  //let npcmanager know to tell other npcs to ook around

                    
                        anim.SetBool("Aiming", true);
                        isalert = true;
                        TakeShot();
                    
                }

             if (target == null)
                
                {
                    if (seentimer > 0)
                    {
                        seentimer -= 1;
                    }
                    if (seentimer < 2)
                    {
                        seen = false;
                    }
                        SPINE.position = new Vector3(transform.position.x, playercenter.transform.position.y + 1, transform.position.z);
                    if (seen == false)
                    { 
                            Debug.Log("nulltarget" + gameObject.name);
                            Vector3 targetDir = player.position - transform.position; //angle of peripheral vision with enemys head as one line of the angle
                            float angle = Vector3.Angle(targetDir, transform.forward);
                        if (angle < 70)
                        {
                        rotationscript.SetActive(true);
                        }

                        if (angle > 70)
                        {
                            Debug.Log("more70" + gameObject);
                            xyzdif = Vector3.Distance(NPC.transform.position, player.transform.position);

                            if (xyzdif < closethreshold)
                            {
                                Debug.Log("lessthreshold" + gameObject);
                                Sneakmeter -= 1;

                                if (Sneakmeter < sneakmeterthreshold)
                                {
                                    shotsfiredbool = true;
                                    strobelight.SetActive(true);
                                    rotationscript.SetActive(true);
                                }
                            }

                            if (shotsfiredbool == true)
                            {
                                rotationscript.SetActive(true);
                            }
                    }
                        if (seen == true)
                        {
                            var lookDir = player.position - transform.position;
                            lookDir.y = 0; // keep only the horizontal direction
                            transform.rotation = Quaternion.LookRotation(lookDir);
                        }

                    if (shotsfiredbool == false)
                    {
                            NewActionTimer -= NewActionDecreaseSpeed;

                            if (NewActionTimer < NewActionThreshold)
                            {
                                NewActionNumber = (Random.Range(0, 4));
                            }

                            if (EnemyClassification == 0)
                            {
                                if (NewActionNumber == 0)
                                {
                                    rb.Sleep();
                                    rb.WakeUp();
                                    anim.SetBool("Squatting", true);
                                    NewActionTimer = 40;
                                }

                                if (NewActionNumber == 1)
                                {
                                    rb.Sleep();
                                    rb.WakeUp();
                                    anim.SetBool("Idling", true);
                                    NewActionTimer = 40;
                                }

                                if (NewActionNumber == 2)
                                {
                                    if (locale == 0)
                                    {
                                        Vector3 position0 = new Vector3(Location0xyz[0], Location0xyz[1], Location0xyz[2]);
                                        var lookDir = position0 - transform.position;
                                        lookDir.y = 0; // keep only the horizontal direction
                                        transform.rotation = Quaternion.LookRotation(lookDir);
                                    }

                                    rb.Sleep();
                                    rb.WakeUp();
                                    anim.SetBool("Walking", true);
                                    var v = rb.velocity;
                                    rb.AddRelativeForce(Vector3.forward * speed);
                                    rb.velocity = v.normalized * maxvelocity;
                                    NewActionTimer = 40;
                                }
                            }
                    }
                    }
                }
            } else
            SPINE.position = new Vector3(transform.position.x, playercenter.transform.position.y, transform.position.z);
        }
        if (isdead == true)
        {
            strobelight.SetActive(false);
            rotationscript.SetActive(false);
            if (dummyweaponadded == false)
            {

                dummyweapontimer -= 1;
                if (dummyweapontimer < 2)
                {
                    actualweapon.SetActive(false);
                    dummyweapon.SetActive(true);
                    dummyweaponadded = true;
                }
            }

        }
        
       
    }
    public void TakeShot()
    {
       // aimableweapon.SetActive(true);
        
      //  aimableweapon.transform.LookAt(playercenter);
       // animatedweaponpiece1.GetComponent<MeshRenderer>().enabled = false;
      //  animatedweaponpiece2.GetComponent<MeshRenderer>().enabled = false;
      //  animatedweaponpiece3.GetComponent<MeshRenderer>().enabled = false;
       // actualweapon.transform.LookAt(playercenter);
        GunMuzzle.transform.LookAt(playercenter);


        
        anim.SetBool("Aiming", true);
        anim.SetTrigger("Fire");
        RaycastHit hit;
        int layerMask = (1 << 9)|(1<<10)|(1<<11);
        layerMask = ~layerMask;
        if (Physics.Raycast(GunMuzzle.transform.position, GunMuzzle.transform.forward, out hit, sightrange, layerMask))
        {
            playerhitbox target = hit.transform.GetComponent<playerhitbox>();
            if (target != null)
            {
                RateOfFire -= RateOfFireDecrease;

                if (RateOfFire < 1)
                {
                    GameObject blik = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                    blik.transform.SetParent(target.transform);
                    playerhud.GetComponent<HUD>().TakeDamage(damagetoplayer);
                    Instantiate(GunSmoke, GunMuzzle.position, GunMuzzle.rotation);
                    Instantiate(MuzzleFlash, GunMuzzle.position, GunMuzzle.rotation);
                    RateOfFire = NewRateOfFire;
                    isalert = true;
                }
            }
        }
    }

    public void TheyCrouch() //triggered when player crouches and called in by the npcmanagerscript. decrease enemies ability to hear you 
    {
        Sneakmeterdecrease = Sneakmeterdecrease / 10;
    }
    public void TheyStand() //resets the enemys ability to hear you to "normal" levels 
    {
        Sneakmeterdecrease = Sneakmeterdecrease * 10;
    }
    public void DamageAlert() //called when the player fires a loud weapon
    {
        xyzdif = Vector3.Distance(NPC.transform.position, player.transform.position); //if player is within range 
        if (xyzdif < 90)
        {
            if (xyzdif > -90)
            {
                shotsfiredbool = true;
            }
        }
    }
    public void DeathHeard(float x, float y, float z) //has enemy turn to face dead npc 
    {
        shotsfiredbool = true;
    }
    public void GetStabbed()
    {
        Vector3 TheStabbingFloor = new Vector3(TheStabSpace.position.x, TheStabSpace.position.y, TheStabSpace.position.z);
        NPC.transform.position = TheStabbingFloor;
    }
    public void HitByKnife(float damage) //when hit by melee
    {
        if (health > 0)
        {
            health -= damage;
            CheckHealth();
        }
    }
    public void CheckHealth() //sees if enemy is dead or not 
    {
        if (health <= 0)
        {
            isdead = true;
            rb.Sleep();
            rb.WakeUp();
            Die();
        }
        else if (health > 0)
        {
            StillAlive();
        }
    }
    public void StillAlive() //lets other enemies know to look, sets npc to lok at player. specifically for knife hits.
    {
        isalert = true;
        npcmanager.GetComponent<NpcManagement>().HearADeath(transform.position.x, transform.position.y, transform.position.z); //gives npcmanager playerlocation location
    }
    public void Die() //called at death
    {
        anim.SetTrigger("Die");
        anim.SetBool("Death", true);
        isdead = true;
        if (isalert == true)
        {
            npcmanager.GetComponent<NpcManagement>().HearADeath(transform.position.x, transform.position.y, transform.position.z); //gives npcmanager death location
            npcmanager.GetComponent<NpcManagement>().JustFired();
        }
        playerhud.addexperience(experiencetogive);

    }
    public void TakeDamage(float damage) //applies damage to the enemy and checks for death. called through hitbox and triggered by impact with bullets or melee weapons
    {
        health -= damage;
        DamageAlert();
        seen = true;
        if (health <= 0)
        {
            isdead = true;
            rb.Sleep();
            rb.WakeUp();
            Die();
        }
        if (health < 1000)
        {
            if (health > 0)
            {
                npcmanager.GetComponent<NpcManagement>().HearADeath(transform.position.x, transform.position.y, transform.position.z); //gives npcmanager npclocation
            }

        }
    }
    public void Punch() //triggered by a positive sight confirmation in Lineofsight()
    {
        xyzdif = Vector3.Distance(NPC.transform.position, player.transform.position);
        if (xyzdif < 6)
        {
            if (xyzdif > -6)
            {
                punchclock -= 3;

                anim.SetTrigger("punch");
                if (punchclock < 1)
                {
                    movementManager.GetPunched();
                    punchclock = 3;
                }

            }
        }
    }
    public void Located()
    {
        //deprecated
    }
}
