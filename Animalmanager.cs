using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animalmanager : MonoBehaviour
{
    public float animaltimer;
    public GameObject[] animals;
    public AnimalScript[] ang;
    public float[] xyzdif;
    public float threshold;
    public Transform player;
    public float rendertimer;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        animaltimer = 5;
        rendertimer = 10;
        for (int i = 0; i < animals.Length; i++)
        {
            ang[i] = animals[i].GetComponent<AnimalScript>();
        }
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer();
    }
    public void timer()
    {
        animaltimer -= 2f;
        if (animaltimer <=2)
        {
            checkanimals();
            rendercheck();
        }
    }
    public void checkanimals()
    {
        animaltimer = 5;

        //for (int i = 0; i < ang.Length; i++)
        //  {

        //          ang[i].GetTheUpdate();

        //  }
        ang[x].GetTheUpdate();
        Debug.Log("senttheupdate");
        x += 1;
        if (x ==animals.Length)
        {
            x = 0;
        }

        
    }
    public void rendercheck()
    {
        rendertimer -= .001f;
        if (rendertimer < 2)
        {
            rendie();
        }
    
    }
    public void rendie()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].SetActive(true);
            xyzdif[i] = Vector3.Distance(animals[i].transform.position, player.transform.position);
            if (xyzdif[i] > threshold)
            {
                animals[i].SetActive(false);
            }
            
        }
       // rendertimer = 10;
    }
}
