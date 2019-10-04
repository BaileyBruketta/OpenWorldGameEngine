using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManagement : MonoBehaviour
{
    public GameObject hud;
    public GameObject NPC1;
    NpcScript npce1;
    public GameObject NPC2;
    NpcScript npce2;
    public GameObject NPC3;
    NpcScript npce3;
    public float timer;
    public float timer2;
    public GameObject terrainmasterscript;
    public GameObject NPCMasterCulling;
    NPCRenderCull rendie;
    public GameObject movementmanager;
    [SerializeField] WeaponManagement weaponManagement;
    [SerializeField] HUD hudie;
    

   

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        rendie = NPCMasterCulling.GetComponent<NPCRenderCull>();
        timer2 = 5;
        npce1 = NPC1.GetComponent<NpcScript>();
        npce2 = NPC2.GetComponent<NpcScript>();
        npce3 = NPC3.GetComponent<NpcScript>();




    }
    // Update is called once per frame
    void Update()
    {
        movementmanager.GetComponent<MovementManager>().Update2();
        if (timer > 0)
        {
            timer -= .25f;
            if (timer < 2.1f)
            {
                UpdateNpcs();
                
                WeGotemboys();
                timer = 2.5f;
            }
        }
    }
    public void UpdateNpcs()
    {        
        UpdateNPCs2();
    }
    public void UpdateNPCs2()
    {
        timer2 -= .5f;
        if (timer2 == 0)
        {
            weaponManagement.SingleFireTimer();
            rendie.UpdateCulling();
            terrainmasterscript.GetComponent<GridWatcher>().UpdateBlocks();
            hud.GetComponent<HUD>().SlowHeal();
            npce1.GetTheUpdate();
            npce2.GetTheUpdate();
            npce3.GetComponent<NpcScript>().GetTheUpdate();
            timer2 = 5;
        }
    }
    public void JustFired()
    {
        npce1.DamageAlert();
        npce2.DamageAlert();
        npce3.DamageAlert();
        npce3.DamageAlert();
    }    
    public void WeGotemboys()                   //not fun or good looking
    {
        npce1.Located();
        npce2.Located();
        npce3.Located();
    }
    public void Crouchon()
    {
        npce1.TheyCrouch();
        npce2.TheyCrouch();
        npce3.TheyCrouch();
    }
    public void Crouchoff()
    {
        npce1.TheyStand();
        npce2.TheyStand();
        npce3.TheyStand();
    }
   
}
