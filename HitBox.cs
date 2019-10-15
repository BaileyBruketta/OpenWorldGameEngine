using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public GameObject NPC;
    public float damagemultiplier;
    public float damagetosend;
    NpcScript Npcc;
    // Start is called before the first frame update
    void Start()
    {
        Npcc = NPC.GetComponent<NpcScript>();
    }

    // Update is called once per frame
   

    public void HitByProjectile(float damage)
    {
        damagetosend = damage * damagemultiplier;
        if (NPC.GetComponent<NpcScript>())
        {
            NPC.GetComponent<NpcScript>().TakeDamage(damagetosend);
        }
        if (NPC.GetComponent<AnimalScript>())
        {
            NPC.GetComponent<AnimalScript>().TakeDamage(damagetosend);
        }
        Debug.Log("damagesent");
    }
    public void KnifeHit(float damage)
    {
        damagetosend = damage * damagemultiplier;
        Npcc.HitByKnife(damagetosend);
        Npcc.GetStabbed();
    }
}
