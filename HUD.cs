using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public float maxhealth;
    public float health;

    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;
    public GameObject blood5;

    public Text healthdisplay;
    

    // Start is called before the first frame update
    void Start()
    {
        healthdisplay.text = "HEALTH: " + health + "/" + maxhealth;
    }

    // Update is called once per frame
   
    public void TakeDamage(float damage)
    {
        health -= damage * 1f;
        if (health < 100)
        {
            blood1.SetActive(true);
        }
        if (health < 80)
        {
            blood2.SetActive(true);
        }
        if (health < 60)
        {
            blood3.SetActive(true);
        }
        if(health < 40)
        {
            blood4.SetActive(true);
        }
        if (health < 20)
        {
            blood5.SetActive(true);
        }
        healthdisplay.text = "HEALTH: " + health + "/" + maxhealth;
    }

    public void SlowHeal()
    {
        if (health < maxhealth)
        {
            health += .001f;
            healthdisplay.text = "HEALTH: " + health + "/" + maxhealth;
        }
    
    if (health > 99)
        {
            blood1.SetActive(false);
        }
        if (health > 79)
        {
            blood2.SetActive(false);
        }
        if (health > 59)
        {
            blood3.SetActive(false);
        }
        if(health > 39)
        {
            blood4.SetActive(false);
        }
        if (health> 19)
        {
            blood5.SetActive(false);
        }
    }
}
