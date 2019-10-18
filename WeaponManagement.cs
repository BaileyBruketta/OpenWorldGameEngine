using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{//this script can be attached to any empty game object. its job is to handle player input for using weapons, and collecting ammo
 //so NPC manager can call bots when player fires

    public GameObject scope;
    public GameObject scopebody;
    public Camera maincam;
    //this is for managing ammunition 
    public float activeammo;
    public float activemagazine;
    [SerializeField] HUD hud;
    [SerializeField] MovementManager move;

    //
    public GameObject NPCmanager;
    public float NineMillimeterRounds;
    public float ThreeOhEightAmmo;

    public bool HandsEquipped;

    public float weaponslots;
    

    public bool KnifeEquipped;
    public bool knifehave;
    public GameObject KnifeBody;
    public float knifetimer;
    public float KnifeDamage;
    public float KnifeWeaponRange;
    Animator KN;

    public float hands;

    public bool VectorEquipped;
    public bool VectorHave;
    public GameObject Vector;
    public GameObject Vectorbody;
    public float Vectormagazine;
    public float vectorweaponrange;
    public Transform VectorMuzzle;
    public float vectordamage;
    private float Vectortimer;

    public bool glocknineEquipped;
    public bool glocknineHave;
    public GameObject glocknine;
    public GameObject glockninebody;
    public float glockninemagazine;
    public float glocknineweaponrange;
    public Transform glocknineMuzzle;
    public float glockninedamage;
    private float glockninetimer;

    public bool HuntingRifleHave;
    public bool HuntingRifleEquipped;
    public GameObject HuntingRifle;
    public GameObject HuntingRifleBody;
    public float HuntingRifleMagazine;
    public float HuntingRifleRange;
    public Transform HuntingRifleMuzzle;
    public float HuntingRifleDamage;
    public float HuntingRifleTimer;

    
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
    public bool changing;
    public float pistolfloat;
    public float knifefloat;
    public float submachinegunfloat;
    public float riflefloat;
    public float weaponequipnumber;

    // Start is called before the first frame update
    void Start()
    {
        EquipHands();
        VectorHave = false;
        hands = 0;
        Vectortimer = 4;
        changing = false;
        knifehave = false;
        HandsEquipped = true;
        KN = KnifeBody.GetComponent<Animator>();
        knifetimer = 4;
        HuntingRifleTimer = 10;
        weaponequipnumber = 0;
        glockninetimer = 2;
        glockninedamage = vectordamage;
        glocknineweaponrange = 400;
    }

    // Update is called once per frame
    void Update()
    {
        //knifetimer -= .5f;
        //gets button press
        if (Input.GetMouseButtonDown(2))
        {
            changing = false;
            ChangeWeapons2();
        }
        if (Input.GetMouseButton(0))
        {
            CheckWeapons(); //rapid fire
        }
        if (Input.GetMouseButtonDown(0))
        {
            CheckWeapons2(); //single fire
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        

        
    }
    public void SingleFireTimer()
    {
        if (KnifeEquipped == true)
        {
            knifetimer -= .25f;
        }
        if (HuntingRifleEquipped == true)
        {
            HuntingRifleTimer -= 1;
        }
        if (glocknineEquipped == true)
        {
            glockninetimer -= 1;
        }
    }
    //for changing weapons on the fly
    public void ChangeWeapons2() //checks to see which weapon/weaponslot you're using 
    {
        if (changing == false)
        {
            if (weaponequipnumber == 0)
            {
                EquipKnives();
                changing = true;
            }else if (weaponequipnumber == 1)
            {
                EquipRifles();
                changing = true;
            }else if (weaponequipnumber == 2)
            {
                EquipSMGs();
                changing = true;
            }else if (weaponequipnumber == 3)
            {
                EquipHandguns();
            }else if (weaponequipnumber == 4)
            {
                EquipHands();
            }
        }
    }
    //these all see which actual weapon is in the selected weaponslot
    public void EquipKnives()
    {
        weaponequipnumber = 1;
        if (knifehave == true)
        {
            EquipKnife();
        }
    }
    public void EquipRifles()
    {
        weaponequipnumber = 2;
        if (HuntingRifleHave == true)
        {
            EquipHuntingRifle();
        }
    }
    public void EquipSMGs()
    {
        weaponequipnumber = 3;
        if (VectorHave == true)
        {
            EquipVector();
        }
    }
    public void EquipHandguns()
    {
        weaponequipnumber = 4;
        if (glocknineHave == true)
        {
            EquipGlockNine();
        }
    }
   
    //checks to see which equipped weapon for firing, ADS, draw, etc
    public void CheckWeapons() //called on click left button
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
    public void CheckWeapons2()
    {
        if (KnifeEquipped == true)
        {
            FireKnife();
        }
        if (HuntingRifleEquipped == true)
        {
            FireRifle();
        }
        if (glocknineEquipped)
        {
            Fireglocknine();
        }
    }
    public void ReleaseWeapons() //called on release left button
    {
        if (HandsEquipped == true)
        {
            ReleaseHands();
        }
        if (VectorEquipped == true)
        {
            //ReleaseVector();
        }
        if (KnifeEquipped == true)
        {
            ReleaseKnife();
        }
        


    }
    public void Weaponwalk() //called when walking
    {
        if (VectorEquipped == true)
        {
            Vectorwalk();
        }
        if (HuntingRifleEquipped == true)
        {
            HuntingRiflewalk();
        }
        if (glocknineEquipped == true)
        {
            GlockNinewalk();
        }
    }
    public void Weaponstop() //called when movement stops
    {
        if (VectorEquipped == true)
        {
            Vectorstop();
        }
        if (HuntingRifleEquipped == true)
        {
            HuntingRiflestop();
        }
        if (glocknineEquipped == true)
        {
            GlockNinestop();
        }
    }

    //aiming down sight 
    public void CheckAim() //callled on click right button 
    {
        if (VectorEquipped == true)
        {
            maincam.fieldOfView = 108;
            Vector.GetComponent<Animator>().SetBool("ads", true);
            
        }
        if (HuntingRifleEquipped == true)
        {
            HuntingRifle.GetComponent<Animator>().SetBool("ads", true);
            scope.SetActive(true);
            scopebody.SetActive(false);
            maincam.fieldOfView = 15;

        }
        if (glocknineEquipped == true)
        {
            maincam.fieldOfView = 108;
            glocknine.GetComponent<Animator>().SetBool("ads", true);
        }
        hitmarker1.SetActive(false);
    }
    public void ReleaseAim() //called on release right button
    {
        if (VectorEquipped == true)
        {
            maincam.fieldOfView = 110;
            Vector.GetComponent<Animator>().SetBool("ads", false);

        }
        if (HuntingRifleEquipped == true)
        {
            HuntingRifle.GetComponent<Animator>().SetBool("ads", false);
            maincam.fieldOfView = 110;
            scope.SetActive(false);
            scopebody.SetActive(true);

        }
        if (glocknineEquipped == true)
        {
            maincam.fieldOfView = 110;
            glocknine.GetComponent<Animator>().SetBool("ads", false);
        }
        hitmarker1.SetActive(true);
    }
    
    //deals with knives
    public void GrabTanto()
    {
        if (knifehave == true)
        {
            Tantofalse();
        }
        if (knifehave == false)
        {
            Tantotrue();
        }

    }
    public void Tantotrue()
    {
        knifehave = true;
    }
    public void Tantofalse()
    {
        knifehave = false;
    }
    public void EquipKnife()
    {
        KnifeEquipped = true;
        VectorEquipped = false;
        HandsEquipped = false;
        Weaponry.GetComponent<weaponry>().KnifeEquip();
        HuntingRifleEquipped = false;
    }
  
    
    public void FireKnife()
    {
        if (knifetimer < 2.5f)
        {
            var fire = 0;
            move.knifejump();
            cam.transform.rotation *= Quaternion.Euler(.4f, 0, 0.0f);
            //Weaponry.GetComponent<weaponry>().KnifeStab();
            //KnifeBody.GetComponent<Animator>().SetTrigger("stab");
            //stores location of raycast hit
            RaycastHit hit;
            //makes raycast avoid game-layer with player and ui
            int layerMask = (1 << 8) | (1 << 9);
            layerMask = ~layerMask;
            //casts ray
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, KnifeWeaponRange, layerMask))
            {
                //makes an impact particle effect


                HitBox target = hit.transform.GetComponent<HitBox>();         // this checks to see if object hit has a certain script
                if (target != null)
                {
                    if (fire == 0)
                    {
                        KN.SetTrigger("GrabStab");
                        //target.HitByProjectile(KnifeDamage);
                        GameObject blik = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                        blik.transform.SetParent(target.transform);
                        target.KnifeHit(KnifeDamage);
                        fire = 1;
                    }

                }
            }
            else KN.SetTrigger("stab");
            knifetimer = 2;
        }

    }
    public void ReleaseKnife()
    {
        Weaponry.GetComponent<weaponry>().KnifeRelease();
    }
    //deals with hands
    public void EquipHands()
    {
        weaponequipnumber = 0;
        HandsEquipped = true;
        VectorEquipped = false;
        KnifeEquipped = false;
        Weaponry.GetComponent<weaponry>().EquipHands();
        HuntingRifleEquipped = false;
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
    //deals with handguns
    public void GlockNinewalk()
    {
        glocknine.GetComponent<Animator>().SetBool("walk", true);
    }
    public void GlockNinestop()
    {
        glocknine.GetComponent<Animator>().SetBool("walk", false);
    }
    public void GrabGlockNine()
    {
        if (HuntingRifleHave == true)
        {
            GlockNineFalse();
        }
        else if (HuntingRifleHave == false)
        {
            GlockNineTrue();
        }
    }
    public void GlockNineTrue()
    {
        glocknineHave = true;
    }
    public void GlockNineFalse()
    {
        glocknineHave = false;
    }
    public void EquipGlockNine()
    {
        glocknineEquipped = true;
        HuntingRifleEquipped = false;
        HandsEquipped = false;
        KnifeEquipped = false;
        VectorEquipped = false;
        Weaponry.GetComponent<weaponry>().EquipGlock();
        activeammo = NineMillimeterRounds;
        activemagazine = glockninemagazine;
        hud.AmmoUpdate();
    }
    public void Fireglocknine()
    {
        if (glockninetimer < 1)
        {
            if (glockninemagazine > 0)
            {

                NPCmanager.GetComponent<NpcManagement>().JustFired(); //lets NPCs know you fired, so they can look for you 
                glocknine.GetComponent<Animator>().SetTrigger("Fire");                                               //HuntingRifle.GetComponent<Animator>().SetTrigger("Fire");  //plays a firing animation
                Instantiate(muzzleflash, glocknineMuzzle.position, glocknineMuzzle.rotation);  //muzzleflash
                Instantiate(smoke, glocknineMuzzle.position, glocknineMuzzle.rotation);  //gunsmoke

                //stores location of raycast hit
                RaycastHit hit;
                //makes raycast avoid game-layer with player and ui

                int layerMask = (1 << 8) | (1 << 9);
                layerMask = ~layerMask;
                //casts ray
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, glocknineweaponrange, layerMask))
                {
                    //makes an impact particle effect


                    HitBox target = hit.transform.GetComponent<HitBox>();         // this checks to see if object hit has a certain script
                    if (target != null)
                    {
                        target.HitByProjectile(glockninedamage);
                        GameObject blik = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                        blik.transform.SetParent(target.transform);
                        GameObject smokes = Instantiate(sparks, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                        smokes.transform.SetParent(target.transform);
                    }
                    else Instantiate(sparks, hit.point, Quaternion.LookRotation(hit.normal));
                }



                cam.transform.rotation *= Quaternion.Euler(-.2f, 0, 0.0f);

                glockninemagazine -= 1;
                activemagazine = glockninemagazine;

                hud.AmmoUpdate();
                glockninetimer = 8;
            }
        }

    }
    //deals with hunting rifle
    public void HuntingRiflewalk()
    {
        HuntingRifle.GetComponent<Animator>().SetBool("walk", true);
    }
    public void HuntingRiflestop()
    {
        HuntingRifle.GetComponent<Animator>().SetBool("walk", false);
    }
        public void GrabHuntingRifle()
    {
        if(HuntingRifleHave == true)
        {
            HuntingRifleFalse();
        }else if  (HuntingRifleHave == false)
            {
                HuntingRifleTrue();
            }
    }
    public void HuntingRifleTrue()
    {
        HuntingRifleHave = true;
    }
    public void HuntingRifleFalse()
    {
        HuntingRifleHave = false;
    }
    public void EquipHuntingRifle()
    {
        HuntingRifleEquipped = true;
        HandsEquipped = false;
        KnifeEquipped = false;
        VectorEquipped = false;
        Weaponry.GetComponent<weaponry>().EquipRifle();
        activeammo = ThreeOhEightAmmo;
        activemagazine = HuntingRifleMagazine;
        hud.AmmoUpdate();
    }
    public void FireRifle()
    {
        if (HuntingRifleTimer < 1)
        {
            if (HuntingRifleMagazine > 0)
            {

                NPCmanager.GetComponent<NpcManagement>().JustFired(); //lets NPCs know you fired, so they can look for you 
                HuntingRifle.GetComponent<Animator>().SetTrigger("Fire");                                               //HuntingRifle.GetComponent<Animator>().SetTrigger("Fire");  //plays a firing animation
                Instantiate(muzzleflash, HuntingRifleMuzzle.position, HuntingRifleMuzzle.rotation);  //muzzleflash
                Instantiate(smoke, HuntingRifleMuzzle.position, HuntingRifleMuzzle.rotation);  //gunsmoke

                //stores location of raycast hit
                RaycastHit hit;
                //makes raycast avoid game-layer with player and ui

                int layerMask = (1 << 8) | (1 << 9);
                layerMask = ~layerMask;
                //casts ray
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, HuntingRifleRange, layerMask))
                {
                    //makes an impact particle effect


                    HitBox target = hit.transform.GetComponent<HitBox>();         // this checks to see if object hit has a certain script
                    if (target != null)
                    {
                        target.HitByProjectile(HuntingRifleDamage);
                        GameObject blik = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                        blik.transform.SetParent(target.transform);
                        GameObject smokes = Instantiate(sparks, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                        smokes.transform.SetParent(target.transform);
                    }
                    else Instantiate(sparks, hit.point, Quaternion.LookRotation(hit.normal));
                }



                cam.transform.rotation *= Quaternion.Euler(-.1f, 0, 0.0f);

                HuntingRifleMagazine -= 1;
                activemagazine = HuntingRifleMagazine;

                hud.AmmoUpdate();
                HuntingRifleTimer = 4;
            }
        }
        
    }
    
    //deals with Kriss Vector SMG/Carbine
    public void GrabVector()
    {

        if (VectorHave == true)
        {
            Vectorfalse();
        }else if (VectorHave == false)
        {
            Vectortrue();
        }
    }
    public void Vectortrue()
    {
        VectorHave = true;
    }
    public void Vectorfalse()
    {
        VectorHave = false;
    }
    public void EquipVector()
    {
        VectorEquipped = true;
        HandsEquipped = false;
        HuntingRifleEquipped = false;
        KnifeEquipped = false;
        VectorHave = true;
        Weaponry.GetComponent<weaponry>().HoldVector();
        activeammo = NineMillimeterRounds;
        activemagazine = Vectormagazine;
        hud.AmmoUpdate();
    }
    public void FireVectorshit() //gets called when holding left button and manages rate of fire 
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

            NPCmanager.GetComponent<NpcManagement>().JustFired(); //lets NPCs know you fired, so they can look for you 
            Vector.GetComponent<Animator>().SetTrigger("Fire");  //plays a firing animation
            Instantiate(muzzleflash, VectorMuzzle.position, VectorMuzzle.rotation);  //muzzleflash
            Instantiate(smoke, VectorMuzzle.position, VectorMuzzle.rotation);  //gunsmoke

            //stores location of raycast hit
            RaycastHit hit;
            //makes raycast avoid game-layer with player and ui
            
            int layerMask = (1 << 8) | (1<<9);
            layerMask = ~layerMask;
            //casts ray
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, vectorweaponrange, layerMask))
            {
                //makes an impact particle effect
                

                HitBox target = hit.transform.GetComponent<HitBox>();         // this checks to see if object hit has a certain script
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
            activemagazine=Vectormagazine;

            hud.AmmoUpdate();
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
        hud.AmmoUpdate();
    }
    public void AddThreeOhEightAmmo(float ammo)
    {
        ThreeOhEightAmmo += ammo;
        hud.AmmoUpdate();
    }
    public void Reload()
    {
        if (VectorEquipped == true)
        {
            VectorReload();
        }
        else if (HuntingRifleEquipped == true)
        {
            HuntingRifleReload();
        }
        else if (glocknineEquipped == true)
        {
            glocknineReload();
        }
    }
    public void VectorReload()
    {
        if (NineMillimeterRounds > 0)
        {
            if (Vectormagazine < 15)
            {
                Vector.GetComponent<Animator>().SetTrigger("Reload");
                var f = NineMillimeterRounds + Vectormagazine;
                if (f > 15)
                {
                    activemagazine = 15;
                    activeammo = f - 15;
                    Vectormagazine = activemagazine;
                    NineMillimeterRounds = activeammo; 
                    Vectortimer = 8;
                }
                else if (f <= 15)
                {
                    activemagazine = f;
                    activeammo = 0;
                    Vectormagazine = activemagazine;
                    NineMillimeterRounds = activeammo;
                    Vectortimer = 8;
                }
                hud.AmmoUpdate();
            }
        }
    }
    public void glocknineReload()
    {
        if (NineMillimeterRounds > 0)
        {
            if (glockninemagazine < 12)
            {
                glocknine.GetComponent<Animator>().SetTrigger("Reload");
                var f = NineMillimeterRounds + glockninemagazine;
                if (f > 15)
                {
                    activemagazine = 15;
                    activeammo = f - 15;
                    glockninemagazine = activemagazine;
                    NineMillimeterRounds = activeammo;
                    glockninetimer = 8;
                }
                else if (f <= 15)
                {
                    activemagazine = f;
                    activeammo = 0;
                    glockninemagazine = activemagazine;
                    NineMillimeterRounds = activeammo;
                    glockninetimer = 8;
                }
                hud.AmmoUpdate();
            }
        }
    }
    public void HuntingRifleReload()
    {
        if (ThreeOhEightAmmo > 0)
        {
            if (HuntingRifleMagazine < 5)
            {
                HuntingRifle.GetComponent<Animator>().SetTrigger("Reload");
                var f = ThreeOhEightAmmo + HuntingRifleMagazine;
                if (f > 5)
                {
                    activemagazine = 5;
                    activeammo = f - 5;
                    HuntingRifleMagazine = activemagazine;
                    ThreeOhEightAmmo = activeammo;
                    HuntingRifleTimer = 4;
                }
                else if (f <= 5)
                {
                    activemagazine = f;
                    activeammo = 0;
                    HuntingRifleMagazine = activemagazine;
                    ThreeOhEightAmmo = activeammo;
                    HuntingRifleTimer = 4;
                }
                hud.AmmoUpdate();
            }
        }
    }
}
