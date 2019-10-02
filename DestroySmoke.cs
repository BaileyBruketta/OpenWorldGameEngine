using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySmoke : MonoBehaviour
{
    public GameObject ThisObject;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(ThisObject, 15f);
    }

    // Update is called once per frame
   
}
