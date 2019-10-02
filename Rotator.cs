using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 3;
        
    public Transform cam;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        
            transform.Rotate(cam.up, -Input.GetAxis("Mouse X") * rotationSpeed,
                                             Space.World);
        
    }
}
