using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightCycle : MonoBehaviour
{
    public float timer;
    
    public Transform sunholder;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;

    public Transform sun;
    public Light sunlight;
    public Transform moon;
    public Light moonie;

    public Material skybox;


    // Start is called before the first frame update
    void Start()
    {
        currentTimeOfDay = .3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 1)
        {
            UpdateSun();
            timer = 1.1f;
        }
        if (timer > 0)
       {
           timer -= .325f * Time.deltaTime;
        }
    }

    void UpdateSun()
    {
        sun.transform.LookAt(sunholder);
        moon.transform.LookAt(sunholder);
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        sunholder.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 0, 0, 0);

        if (currentTimeOfDay < .25)
        {
            sunlight.intensity = 0;
            moonie.intensity = .1f;
            RenderSettings.skybox.SetFloat("_Exposure", 0);
        }

        if (currentTimeOfDay > .75)
        {
            sunlight.intensity = 0;
            moonie.intensity = .1f;
            RenderSettings.skybox.SetFloat("_Exposure", 0);
        }

        if (currentTimeOfDay > .25)
        {
            if (currentTimeOfDay < .75)
            {
                sunlight.intensity = 2f;
                moonie.intensity = 0;
                RenderSettings.skybox.SetFloat("_Exposure", 2);
            }
        }
        

        
    }
}
