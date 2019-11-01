using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCulling : MonoBehaviour
{
    public GameObject[] terrain;
    public Transform[] terrains;
    public Vector3[] terraincoordinates;
    public Transform player;
    public float[] xyzdif;
    public float threshold;
    public float timer;
    public Transform itemsparent;
    public int x;
    
    
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        threshold = 350;
        
        //int i=transform.childCount;
        timer = 10;

        for (int i = 0; i < transform.childCount; i++)
        {
            terrains[i] = this.gameObject.transform.GetChild(i);
            
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            terrain[i] = this.gameObject.transform.GetChild(i).gameObject;

        }

        for (int i = 0; i < terrain.Length; i++)
         {
        if (terrain[i] != null)
        {
            terraincoordinates[i] = new Vector3(terrains[i].position.x, terrains[i].position.y, terrains[i].position.z);
        }//terrains coordinates are saved as a vector 3

        xyzdif[i] = Vector3.Distance(terraincoordinates[i], player.transform.position);
        if (xyzdif[i] > threshold)
        {
            terrain[i].SetActive(false);
        }
        if (xyzdif[i] < threshold)
        {
            terrain[i].SetActive(true);
        }



         }





    }

    // Update is called once per frame
    void Update()
    {
       timer -= 2;
        if (timer < 2)
        {
            updatemap();
        }
    }
    public void updatemap()
    {


        for (int i = 0; i < terrain.Length; i++)
        {

            terraincoordinates[i] = new Vector3(terrains[i].position.x, terrains[i].position.y, terrains[i].position.z); //terrains coordinates are saved as a vector 3

            xyzdif[i] = Vector3.Distance(terraincoordinates[i], player.transform.position);
            if (xyzdif[i] > threshold)
            {
                terrain[i].SetActive(false);
            }
            if (xyzdif[i] < threshold)
            {
                terrain[i].SetActive(true);
            }



        }
        timer = 10;
    }
}
