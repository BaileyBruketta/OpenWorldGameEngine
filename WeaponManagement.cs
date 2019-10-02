using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    //so NPC manager can call bots when player fires
    public GameObject NPCmanager;
    public float NineMillimeterRounds;

    public bool HandsEquipped;
    public bool VectorEquipped;
    public bool VectorHave;
    public float hands;
    public GameObject bullet1;

    public GameObject Vector;
    public GameObject Vectorbody;
    public float Vectormagazine;
    public float vectorweaponrange;
    public Transform VectorMuzzle;
    public float vectordamage;
    public float Vectortimer;

    
    public GameObject Weaponry;

    //instantiate when bullets hit
    public GameObject sparks;
    //muzzleflash generic
    public GameObject muzzleflash;
    public GameObject smoke;
    public GameObject blood;

    //player camera
    public Camera cam;

    public GameObject hitmarker1;

    // Start is called before the first frame update
    void Start()
    {
        EquipHands();
        VectorHave = false;
        hands = 0;
        Vectortimer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //gets button press

        if (Input.GetMouseButtonDown(0))
        {
            CheckWeapons();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReleaseWeapons();
        }
        if (Input.GetMouseButtonDown(1))
        {
            CheckAim();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ReleaseAim();
        }

        if (Input.GetMouseButton(0))
        {
            CheckWeapons();
        }

        
    }
    //checks to see equipped weapon for firing, ADS, draw, etc
    public void CheckWeapons()
    {
        if (HandsEquipped == true)
        {
            FireHands();
        }
        if (VectorEquipped == true)
        {
            FireVectorshit();
        }
    }
    public void ReleaseWeapons()
    {
        if (HandsEquipped == true)
        {
            ReleaseHands();
        }
        if (VectorEquipped == true)
        {
            //ReleaseVector();
        }

        
    }
    public void Weaponwalk()
    {
        if (VectorEquipped == true)
        {
            Vectorwalk();
        }
    }
    public void Weaponstop()
    {
        if (VectorEquipped == true)
        {
            Vectorstop();
        }
    }

    //aiming down sight 
    public void CheckAim()
    {
        if (VectorEquipped == true)
        {
            Vector.GetComponent<Animator>().SetBool("ads", true);
            
        }
        hitmarker1.SetActive(false);
    }
    public void ReleaseAim()
    {
        if (VectorEquipped == true)
        {
            Vector.GetComponent<Animator>().SetBool("ads", false);
        }
        hitmarker1.SetActive(true);
    }
    //deals with hands
    public void EquipHands()
    {
        HandsEquipped = true;
    }
                     //attacks with hands
    public void FireHands()
    {
        if (hands == 0)
        {
            Weaponry.GetComponent<weaponry>().RightPunch();
            
        }
        else if (hands == 1)
        {
            Weaponry.GetComponent<weaponry>().LeftPunch();
        }
    }
                      //pulls hands back
    public void ReleaseHands()
    {
        if (hands == 0)
        {
            Weaponry.GetComponent<weaponry>().ReleaseRight();
            hands = 1;
        }
        else if (hands == 1)
        {
            Weaponry.GetComponent<weaponry>().ReleaseLeft();
            hands = 0;
        }
    }
    //deals with Kriss Vector SMG/Carbine
    public void EquipVector()
    {
        VectorEquipped = true;
        HandsEquipped = false;
        VectorHave = true;
        Weaponry.GetComponent<weaponry>().HoldVector();
    }
    public void FireVectorshit()
    {
        Vectortimer -= .5f;
        if (Vectortimer < 2.5f)
        {
            FireVector();
            Vectortimer = 4;
        }
    }
    public void FireVector()
    {
        if (Vectormagazine > 0)
        {
            NPCmanager.GetComponent<NpcManagement>().JustFired();
            Vector.GetComponent<Animator>().SetTrigger("Fire");
            Instantiate(muzzleflash, VectorMuzzle.position, VectorMuzzle.rotation);
            Instantiate(smoke, VectorMuzzle.position, VectorMuzzle.rotation);

            //stores location of raycast hit
            RaycastHit hit;
            //makes raycast avoid layer with player and ui
            
            int layerMask = (1 << 8) | (1<<9);
            layerMask = ~layerMask;
            //casts ray
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, vectorweaponrange, layerMask))
            {
                //makes an impact particle effect
                

                HitBox target = hit.transform.GetComponent<HitBox>();         // this checks to see if object hit has a certain script, which is why all enemy scripts will be run on one script with a float that dictated which enemy type they are
                if (target != null)
                {
                    target.HitByProjectile(vectordamage);
                    GameObject blik = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                    blik.transform.SetParent(target.transform);
                    GameObject smokes = Instantiate(sparks, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                    smokes.transform.SetParent(target.transform);
                }
                else Instantiate(sparks, hit.point, Quaternion.LookRotation(hit.normal));
            }

            
            
            cam.transform.rotation *= Quaternion.Euler(-.1f, 0, 0.0f);
            
            Vectormagazine -= 1;
        }
    }
    public void Vectorwalk()
    {
        Vector.GetComponent<Animator>().SetBool("walk", true);
    }
    public void Vectorstop()
    {
        Vector.GetComponent<Animator>().SetBool("walk", false);
    }
    public void Addninemilammo(float ammo)
    {
        NineMillimeterRounds += ammo;
    }
}
