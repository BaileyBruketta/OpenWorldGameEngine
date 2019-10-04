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
        NPC.GetComponent<NpcScript>().TakeDamage(damagetosend);
    }
    public void KnifeHit(float damage)
    {
        damagetosend = damage * damagemultiplier;
        Npcc.HitByKnife(damagetosend);
        Npcc.GetStabbed();
    }
}
