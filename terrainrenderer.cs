using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainrenderer : MonoBehaviour
{
    public GameObject[] terrain;
    public Transform[] terrains;
    public Vector3[] terraincoordinates;
    public Transform player;
    public float[] xyzdif;
    public float threshold;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1;
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
