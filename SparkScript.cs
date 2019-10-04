using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aura2API;

public class SparkScript : MonoBehaviour
{
    public GameObject thisobject;
    public Light sparklight;
    public AuraLight auralight;
    
    // Start is called before the first frame update
    void Start()
    {
        //destroys light, or glow from heat from projectile
        Destroy(thisobject, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        //decreases intensity of light over time
        sparklight.intensity -= .15f * Time.deltaTime;
        sparklight.range -= .01f * Time.deltaTime;
        auralight.strength -= .2f * Time.deltaTime;
    }
}
