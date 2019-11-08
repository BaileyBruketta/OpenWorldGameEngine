using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menubutton : MonoBehaviour
{
    public GameObject initialmerchantmenu;
    public GameObject merchantmenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyButton()
    {
        merchantmenu.SetActive(true);
        initialmerchantmenu.SetActive(false);
    }
}
