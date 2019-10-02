using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRenderCull : MonoBehaviour
{
    public float TimerStart1;
    public float Timer1;
    
    public float Timerthreshold1;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;

    NPClocationGrabforRender NPCie1;
    NPClocationGrabforRender NPCie2;
    NPClocationGrabforRender NPCie3;
    // Start is called before the first frame update
    void Start()
    {
        Timer1 = TimerStart1;
        NPCie1 = NPC1.GetComponent<NPClocationGrabforRender>();
        NPCie2 = NPC2.GetComponent<NPClocationGrabforRender>();
        NPCie3 = NPC3.GetComponent<NPClocationGrabforRender>();
    }

    public void UpdateCulling() //called from any script that has a timer;
    {
        Updatem();

    }
    //use gameobejct.setactiverecursively
    public void Updatem() //de-render NPCs that are not in range 
    {
        Timer1 -= .5f;
        if (Timer1 == TimerStart1 - 1)
        {
            NPCie1.UpdateLocationandRender();
        }
        if (Timer1 == TimerStart1 - 2)
        {
            NPCie2.UpdateLocationandRender();
        }
        if (Timer1 == TimerStart1 - 3)
        {
            NPCie3.UpdateLocationandRender();
        }
    }
    










}
