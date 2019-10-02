using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManagement : MonoBehaviour
{
    public GameObject hud;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public float timer;
    public GameObject terrainmasterscript;
    public GameObject NPCMasterCulling;
    NPCRenderCull rendie;

   

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        rendie = NPCMasterCulling.GetComponent<NPCRenderCull>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= .05f;
            if (timer < 2)
            {
                UpdateNpcs();
                WeGotemboys();
                timer = 2.5f;
            }
        }

        

    }
    public void UpdateNpcs()
    {
        rendie.UpdateCulling();
        terrainmasterscript.GetComponent<GridWatcher>().UpdateBlocks();
        hud.GetComponent<HUD>().SlowHeal();
        NPC1.GetComponent<NpcScript>().GetTheUpdate();
        NPC2.GetComponent<NpcScript>().GetTheUpdate();
        NPC3.GetComponent<NpcScript>().GetTheUpdate();
    }

    public void JustFired()
    {
        NPC1.GetComponent<NpcScript>().DamageAlert();
        NPC2.GetComponent<NpcScript>().DamageAlert();
        NPC3.GetComponent<NpcScript>().DamageAlert();
    }

    
    public void WeGotemboys()                   //not fun or good looking
    {
        NPC1.GetComponent<NpcScript>().Located();
        NPC2.GetComponent<NpcScript>().Located();
        NPC3.GetComponent<NpcScript>().Located();
    }

    
}
