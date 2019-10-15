using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIGHTs : MonoBehaviour
{
    public GameObject bluelight;
    public GameObject redlight;
    public float lighttimer;
    // Start is called before the first frame update
    void Start()
    {
        lighttimer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        gurdie();
    }
    public void gurdie()
    {
        lighttimer -= 1;

        if (lighttimer == 3)
        {
            bluelight.SetActive(true);
            redlight.SetActive(false);
        }
        if (lighttimer == 1)
        {
            bluelight.SetActive(false);
            redlight.SetActive(true);
        }
        if (lighttimer < 0)
        {
            lighttimer = 4;
        }
    }
}
