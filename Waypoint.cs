using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject thisobject;
    public float waypointnumber;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (waypointnumber == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(thisobject);
            }
        }
    }
}
