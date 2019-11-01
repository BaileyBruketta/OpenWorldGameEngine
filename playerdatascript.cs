using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class playerdatascript 
{
    public float[] position;
    public float[] items;
    public float ninemilammo;
    public float rifleammo;
    
    // Start is called before the first frame update
    public playerdatascript(SaveMaster SaveMaster)
    {

        position = new float[3];
        position[0] = SaveMaster.position1[0];
        position[1] = SaveMaster.position1[1];
        position[2] = SaveMaster.position1[2];
        items = new float[SaveMaster.itemlist.Count];
        for (int i = 0; i < SaveMaster.itemlist.Count; i++)
        {
            items[i] = SaveMaster.itemlist[i];
        }
        ninemilammo = SaveMaster.ninemilammo;
        rifleammo = SaveMaster.rifleammo;
        

       
    }
   
}
