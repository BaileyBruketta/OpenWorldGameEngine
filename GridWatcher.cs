using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWatcher : MonoBehaviour
{
    public GameObject sixteenblock1;
    public float timer;

    private SixteenBlock teener1;
    // Start is called before the first frame update
    public void Start()
    {
        timer = 12;
        teener1 = sixteenblock1.GetComponent<SixteenBlock>();
    }

    // Update is called once per frame
   
    public void UpdateBlocks()
    {
        teener1.Updatemap();       
    }
}
