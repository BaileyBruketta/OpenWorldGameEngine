using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITEXT : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject thiscanvas;
    private float number;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        number = 0;
        text1.SetActive(true);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= 1;
        }
        if (timer == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (number == 0)
                {
                    one();
                }
                else
                if (number == 1)
                {
                    two();
                }
                else
                if (number == 2)
                {
                    three();
                }
                else
                if (number == 3)
                {
                    four();
                }
                else if (number == 4)
                {
                    five();
                }
            }
        }
    }
    void one()
    {
        text1.SetActive(false);
        text2.SetActive(true);
        number = 1;
        timer = 10;
    }
    void two()
    {
        text2.SetActive(false);
        text3.SetActive(true);
        number = 2;
        timer = 10;
    }
    void three()
    {
        text3.SetActive(false);
        text4.SetActive(true);
        number = 3;
        timer = 10;
    }
    void four()
    {
        text4.SetActive(false);
        text5.SetActive(true);
        number = 4;
        
        timer = 10;
    }
    void five()
    {
        text5.SetActive(false);
        number = 5;
        thiscanvas.SetActive(false);
        timer = 10;
    }
}
