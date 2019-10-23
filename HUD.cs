using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public float maxhealth;
    public float health;
    public float hunger;
    public float maxhunger;

    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;
    public GameObject blood5;

    public Text healthdisplay;
    public Text HungerDisplay;
    public Text AmmoDisplay;

    [SerializeField] WeaponManagement weaponmanagement;
    public float magazine;
    public float ammo;

    public bool ispaused;
    public GameObject menupane;
    public GameObject player;

    public float experiencepoints;
    public Text experiencetext;
    public int Level;
    public float[] experiencecap;

    public float skillpoints;

    public float commonwealthcredits;
    public Text CommonwealthCredsText;
    Rigidbody rb;
    public GameObject rotator;
    public GameObject animalmanager;
    public GameObject weaponmanager;
    public GameObject npcmanager;
    public GameObject movementmanager;
    public GameObject LookUpDown;

    // Start is called before the first frame update
    void Start()
    {
        Level = 0;
        int l = Level + 1;
        healthdisplay.text = "HEALTH: " + health + "/" + maxhealth;
        HungerDisplay.text = "HUNGER: " + hunger + "/" + maxhunger;
        AmmoDisplay.text = "AMMO: " + magazine + "/" + ammo;
        ispaused = false;
        CommonwealthCredsText.text = "Commonwealth Credits : " + commonwealthcredits;
        experiencepoints = 0;
        experiencetext.text = "LV" + Level + ": " + experiencepoints + "/" + experiencecap[l];
        skillpoints = 0;
        rb = player.GetComponent<Rigidbody>();
        
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
            if (hunger > 3)
            {
                health += .02f;
                healthdisplay.text = "HEALTH: " + health + "/" + maxhealth;
            }
        }
        if (hunger > 0)
        {
            hunger -= .01f;
            HungerDisplay.text = "HUNGER: " + hunger + "/" + maxhunger;
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

    public void AmmoUpdate()
    {
        magazine = weaponmanagement.activemagazine;
        ammo = weaponmanagement.activeammo;
        AmmoDisplay.text = "AMMO: " + magazine + "/" + ammo;
    }
    public void Punchie()
    {
        TakeDamage(25);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MenuScreen();
        }
    }
    public void MenuScreen()
    {
        
            if (ispaused == true)
            {
            menupane.SetActive(false);
            Cursor.visible = false;
            ispaused = false;
            rotator.GetComponent<Rotator>().enabled = true;
            animalmanager.SetActive(true);
            weaponmanager.SetActive(true);
            npcmanager.SetActive(true);
            movementmanager.SetActive(true);
            LookUpDown.GetComponent<LookUpDown>().enabled = true;
            rb.WakeUp();
            
            
            }
            else if (ispaused == false)
            {
            menupane.SetActive(true);
            Cursor.visible = true;
            rotator.GetComponent<Rotator>().enabled = false;
            animalmanager.SetActive(false);
            weaponmanager.SetActive(false);
            npcmanager.SetActive(false);
            movementmanager.SetActive(false);
            LookUpDown.GetComponent<LookUpDown>().enabled = false;
            rb.Sleep();
            ispaused = true;
            
            }
        
    }
    public void Eatapple()
    {
        hunger += 5;
    }
    public void addexperience(float exp)
    { int x = Level + 1;
        experiencepoints += exp;
        experiencetext.text = "LV" + Level + ": " + experiencepoints + "/" + experiencecap[x];
        checklevel();
    }
    public void updatelevel()
    {
        int x = Level + 1;
        experiencetext.text = "LV" + Level + ": " + experiencepoints + "/" + experiencecap[x];
    }
    
    public void checklevel()
    {
        int x = Level + 1;
        
            if (experiencepoints >= experiencecap[x])
            {

                Level2();
            }
        
    }
    public void Level2()
    {
        int x = Level + 1;
        skillpoints += 1;
        var g = experiencecap[x] - experiencepoints;
        experiencepoints = g;
        Level +=1;
        updatelevel();
    }
    public void ChangeCredits(float creds)
    {
        commonwealthcredits += creds;
        CommonwealthCredsText.text = "Commonwealth Credits : " + commonwealthcredits;
    }
}
