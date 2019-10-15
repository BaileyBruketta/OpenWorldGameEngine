using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] MovementManager movement;

    public float rotationSpeed = 3;
        
    public Transform cam;

    public bool grounded;
    
   

    
    void Update()
    {
        RotateObject();
        if (grounded == false)
        {
            movement.antifloat();
        }
        else if (grounded == true)
        {
            movement.antifloat2();
        }
    }

    void RotateObject()
    {
        
            transform.Rotate(cam.up, -Input.GetAxis("Mouse X") * rotationSpeed,
                                             Space.World);
        
    }
   
    public void OnCollisionEnter(Collision collision)
    {
        grounded = true;  
    }
    public void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

}
