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
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        timer2 = 5;
    }
    // Update is called once per frame
    void Update()
    {
        
        movementmanager.GetComponent<MovementManager>().Update2();
        if (timer > 0)
        {
            timer -= .1f;
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
        for (int i = 0; i < NPCs.Length; i++)
        {
            NPCs[i].GetComponent<NpcScript>().GetTheUpdate();
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

            NPCs[i].GetComponent<NpcScript>().GetTheUpdate();
        }
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
