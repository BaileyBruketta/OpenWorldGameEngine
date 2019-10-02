using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPClocationGrabforRender : MonoBehaviour
{
    public GameObject player;
    public GameObject NPC;
    public float x;
    public float y;
    public float z;
    public float xyzdif;
    public Transform playie;
    public Transform NPCie1;
    
    // Start is called before the first frame update
    void Start()
    {
        playie = player.GetComponent<Transform>();

        NPCie1 = NPC.GetComponent<Transform>();
    }

    // Update is called once per frame
   public void UpdateLocationandRender() //called by another script 
    {
        NPC.SetActive(true);

        x = playie.position.x - NPCie1.position.x;
        y = playie.position.y - NPCie1.position.y;
        z = playie.position.z - NPCie1.position.z;
        xyzdif = x + y + z;

        if (xyzdif > 100)
        {
            if (xyzdif < -100)
            {
                NPC.SetActive(false);
            }
        }
    }
}
