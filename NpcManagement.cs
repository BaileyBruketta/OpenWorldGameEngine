using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManagement : MonoBehaviour
{
    public GameObject hud;
    public float timer;
    public float timer2;
    public GameObject movementmanager;
    [SerializeField] WeaponManagement weaponManagement;
    [SerializeField] HUD hudie;
    public GameObject[] NPCs;
    public Transform[] NPClocation;
    public Vector3[] NPCcoordinates;
    public float[] xyzdif;
    public Transform player;
    public float threshold;
    public NpcScript[] nengpc;
    HUD hudx;
    public int x;
    public float enemy;
    // Start is called before the first frame update
    void Start()
    {
        hudx = hudie.GetComponent<HUD>();
        timer = 3;
        timer2 = 10;
        for (int i = 0; i < NPCs.Length; i++)
        {
            nengpc[i]=NPCs[i].GetComponent<NpcScript>();
        }
        x = 0;
    }
    // Update is called once per frame
    public void Updateus()
    {
        weaponManagement.SingleFireTimer();
       //movementmanager.GetComponent<MovementManager>().Update();

        if (timer > 0)
        {
            timer -= .3f;
            if (timer < 2.1f)
            {
                UpdateNpcs();
                hudx.SlowHeal();
                WeGotemboys();
                timer = 2.5f;
                timer2 -= .001f;
                if (timer2 < 1)
                {
                    UpdateNPCs2();
                }
            }
        }
    }
    public void UpdateNpcs()
    {
        

        //for (int i = 0; i < NPCs.Length; i++)
        //{
            nengpc[x].GetTheUpdate();
        // }
        x += 1;
        if (x == NPCs.Length)
        {
            x = 0;
        }
    }
    public void UpdateNPCs2()
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCcoordinates[i] = new Vector3(NPClocation[i].position.x, NPClocation[i].position.y, NPClocation[i].position.z);
            xyzdif[i] = Vector3.Distance(NPCcoordinates[i], player.transform.position);
            if (xyzdif[i] > threshold)
            {
                NPCs[i].SetActive(false);
            }
            if (xyzdif[i] < threshold)
            {
                NPCs[i].SetActive(true);
            }

            //NPCs[i].GetComponent<NpcScript>().GetTheUpdate();
        }
        timer2 = 10;
    }
    public void JustFired()
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCs[i].GetComponent<NpcScript>().DamageAlert();
        }

    }    
    public void WeGotemboys()                   //not fun or good looking
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCs[i].GetComponent<NpcScript>().Located();
        }
    }
    public void Crouchon()
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCs[i].GetComponent<NpcScript>().TheyCrouch();
        }
    }
    public void Crouchoff()
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCs[i].GetComponent<NpcScript>().TheyStand();
        }
    }
    public void HearADeath(float x, float y, float z)
    {
        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCs[i].GetComponent<NpcScript>().DeathHeard(x,y,z);
        }
    }
   
}
