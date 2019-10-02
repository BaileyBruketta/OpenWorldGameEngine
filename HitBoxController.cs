using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    public Transform NPC;
    public GameObject ThisObject;

    public GameObject chest;
    public Transform NPCchest;

    public GameObject head;
    public Transform NPChead;

    public GameObject leftarm;
    public GameObject leftforearm;

    public Transform NPCleftarm;
    public Transform NPCleftforearm;

    public GameObject rightarm;
    public GameObject rightforearm;

    public Transform NPCrightarm;
    public Transform NPCrightforearm;

    public GameObject leftleg;
    public GameObject leftleg2;

    public Transform NPCleftleg;
    public Transform NPCleftleg2;

    public GameObject rightleg;
    public GameObject rightleg2;

    public Transform NPCrightleg;
    public Transform NPCrightleg2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    public void UpdateBoxes()
    {
        ThisObject.transform.position = new Vector3(NPC.position.x, NPC.position.y, NPC.position.z);
        ThisObject.transform.rotation = NPC.transform.rotation;
        head.transform.position = new Vector3(NPChead.position.x, NPChead.position.y, NPChead.position.z);
        head.transform.rotation = NPChead.transform.rotation;
        chest.transform.position = new Vector3(NPCchest.position.x, NPCchest.position.y, NPCchest.position.z);
        chest.transform.rotation = NPCchest.transform.rotation;
        leftarm.transform.position = new Vector3(NPCleftarm.position.x, NPCleftarm.position.y, NPCleftarm.position.z);
        leftarm.transform.rotation = NPCleftarm.transform.rotation;
        leftforearm.transform.position = new Vector3(NPCleftforearm.position.x, NPCleftforearm.position.y, NPCleftforearm.position.z);
        leftforearm.transform.rotation = NPCleftforearm.transform.rotation;
        rightarm.transform.position = new Vector3(NPCrightarm.position.x, NPCrightarm.position.y, NPCrightarm.position.z);
        rightarm.transform.rotation = NPCrightarm.transform.rotation;
        rightforearm.transform.position = new Vector3(NPCrightforearm.position.x, NPCrightforearm.position.y, NPCrightforearm.position.z);
        rightforearm.transform.rotation = NPCrightforearm.transform.rotation;
        leftleg.transform.position = new Vector3(NPCleftleg.position.x, NPCleftleg.position.y, NPCleftleg.position.z);
        leftleg.transform.rotation = NPCleftleg.transform.rotation;
        leftleg2.transform.position = new Vector3(NPCleftleg2.position.x, NPCleftleg2.position.y, NPCleftleg2.position.z);
        leftleg2.transform.rotation = NPCleftleg2.transform.rotation;
        rightleg.transform.position = new Vector3(NPCrightleg.position.x, NPCrightleg.position.y, NPCrightleg.position.z);
        rightleg.transform.rotation = NPCrightleg.transform.rotation;
        rightleg2.transform.position = new Vector3(NPCrightleg2.position.x, NPCrightleg2.position.y, NPCrightleg2.position.z);
        rightleg2.transform.rotation = NPCrightleg2.transform.rotation;


    }
}
