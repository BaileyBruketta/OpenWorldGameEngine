using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpDown : MonoBehaviour
{
    public float mouseSensitivity = 25.0F;
    public float clampAngle = 80.0F;
    public bool ispaused;

    float rotX = 0.001F, rotY = 0.0F;
    
    void Start()
    {
        ispaused = false;
    }

    
    void Update()
    {
      
        if (ispaused == false)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            rotX = mouseY * mouseSensitivity;
            rotY = mouseX * mouseSensitivity;
            transform.rotation *= Quaternion.Euler(-rotX, 0, 0.0f);
        }
    }

    public void Pauseit()
    {
        ispaused = true;
    }
    public void Unpauseit()
    {
        ispaused = false;
    }
}
