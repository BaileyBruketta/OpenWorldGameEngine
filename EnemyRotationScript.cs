using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotationScript : MonoBehaviour
{
    public Transform npc;
    public float[] rotationspeedfortyplus;
    //public float rotationspeedfortyplus2;
    public float excel;
    public int randominteger;
    // Start is called before the first frame update
    void Start()
    {
        //rotationspeedfortyplus2 = rotationspeedfortyplus * -1;
        randominteger = Random.Range(0, 6);
        excel = rotationspeedfortyplus[randominteger];
    }

    // Update is called once per frame
    void Update()
    {
        randominteger = Random.Range(0, 6);
        excel = rotationspeedfortyplus[randominteger];
        npc.transform.Rotate(npc.up, Time.deltaTime * excel);
       
    }
}
