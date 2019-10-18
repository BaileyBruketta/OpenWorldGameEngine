using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactinput : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] interactable;
    public InteractAble[] objectofinteraction;
   

    void Start()
    {
        for (int i = 0; i < interactable.Length; i++) {
            objectofinteraction[i] = interactable[i].GetComponent<InteractAble>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Check();
            Debug.Log("checking");
        }
        

        
    }
    public void Check()
    {
        for (int i = 0; i < interactable.Length; i++)
        {
            objectofinteraction[i].CallCheck();
        }
    }
}
