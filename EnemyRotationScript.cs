using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotationScript : MonoBehaviour
{
    public GameObject thisobj;
    public Transform npc;
    public float[] rotationspeedfortyplus;
    //public float rotationspeedfortyplus2;
    public float excel;
    public int randominteger;
    public float rotationtimer;
    public Transform SPINE;
    public float sightrange;
    public bool gottem;
    // Start is called before the first frame update
    void Start()
    {
        //rotationspeedfortyplus2 = rotationspeedfortyplus * -1;
        randominteger = Random.Range(0, 6);
        excel = rotationspeedfortyplus[randominteger];
        gottem = false;
    }

    // Update is called once per frame
    void Update()
    {
       // if (gottem == false)
       // {
       //     npc.transform.Rotate(npc.up, Time.deltaTime * excel);

        //    rotationtimer -= .2f;

        //    if (rotationtimer < 8)
        //    {
         //       randominteger = Random.Range(0, 6);
        //        excel = rotationspeedfortyplus[randominteger];
                //  npc.transform.Rotate(npc.up, Time.deltaTime * excel);
         //   }
         //  if (rotationtimer < 2)
         //   {
               // rotationtimer = Random.Range(30, 50);
          //  }
      //  }
        grif();


    }
    public void grif()
    {
        RaycastHit hit; //
        int layerMask = (1 << 9) | (1 << 10) | (1 << 11);  //npc layer and npc hitbox layer
        layerMask = ~layerMask; //inverts raycast so raycast avoids these layers 
        if (Physics.Raycast(SPINE.position, SPINE.forward, out hit, sightrange, layerMask))
        {
            playerhitbox target = hit.transform.GetComponent<playerhitbox>();
            if (target != null)
            { //if the ray hits the player
                gottem = true;
                thisobj.SetActive(false);
            }
            
        }
        grod();
        
    }
    public void grod()
    {
        if (gottem == false)
        {
            npc.transform.Rotate(npc.up, excel * .03f);

            rotationtimer -= .2f;

            if (rotationtimer < 8)
            {
                randominteger = Random.Range(0, 6);
                excel = rotationspeedfortyplus[randominteger];
                //  npc.transform.Rotate(npc.up, Time.deltaTime * excel);
            }
            if (rotationtimer < 2)
            {
                rotationtimer = Random.Range(30, 50);
            }
        }
    }
    public void False()
    {
        gottem = true;
    }
    
}
