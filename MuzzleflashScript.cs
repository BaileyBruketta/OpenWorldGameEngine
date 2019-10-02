using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleflashScript : MonoBehaviour
{
    public GameObject thisobject;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(thisobject, .05f);
    }

    // Update is called once per frame
  
}
