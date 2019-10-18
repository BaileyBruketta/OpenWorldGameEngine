using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponry : MonoBehaviour
{//This script can be attached to any empty game object. its job is to get called by the weaponmanager and handle changes in weapon animation/display
    public GameObject IdleHands;
    public GameObject IdleLeftHand;
    public GameObject IdleRightHand;

    public GameObject PunchingHands;
    public GameObject PunchingLeftHand;
    public GameObject PunchingRightHand;

    public GameObject Vector1;

    public GameObject Knifehands;
    public GameObject LeftKnifeHand;
    public GameObject RightKnifeHand;

    public GameObject HuntingRifle;

    public GameObject HandGun;

    Animator KN;
   
    // Start is called before the first frame update
    void Start()
    {
        PunchingHands.SetActive(false);
        IdleHands.SetActive(true);

        KN = Knifehands.GetComponent<Animator>();
    }

    //handgunshit
    public void EquipGlock()
    {
        HandGun.SetActive(true);
        
        IdleHands.SetActive(false);
        PunchingHands.SetActive(false);
        Knifehands.SetActive(false);
        Vector1.SetActive(false);
        HuntingRifle.SetActive(false);
    }
    //rifle based motions
    public void EquipRifle()
    {
        IdleHands.SetActive(false);
        PunchingHands.SetActive(false);
        Knifehands.SetActive(false);
        Vector1.SetActive(false);
        HuntingRifle.SetActive(true);
        HandGun.SetActive(false);
    }
    //Vectro based motions
    public void FireVector()
    {

    }
    public void HoldVector()
    {
        IdleHands.SetActive(false);
        PunchingHands.SetActive(false);
        Knifehands.SetActive(false);
        Vector1.SetActive(true);
        HuntingRifle.SetActive(false);
        HandGun.SetActive(false);
    }
    //hand based motions
    public void EquipHands()
    {
        Knifehands.SetActive(false);
        Vector1.SetActive(false);
        IdleHands.SetActive(true);
        HuntingRifle.SetActive(false);
        HandGun.SetActive(false);
    }
    public void RightPunch()
    {
        PunchingHands.SetActive(true);
        PunchingRightHand.SetActive(true);
        IdleRightHand.SetActive(false);
        PunchingRightHand.GetComponent<Animator>().SetBool("punchright", true);
        PunchingLeftHand.SetActive(false);
       
        
    }
    public void ReleaseRight()
    {
        PunchingRightHand.GetComponent<Animator>().SetBool("punchright", false);
        IdleRightHand.SetActive(true);
        PunchingRightHand.SetActive(false);
    }

    public void LeftPunch()
    {
        PunchingHands.SetActive(true);
        PunchingLeftHand.SetActive(true);
        IdleLeftHand.SetActive(false);
        PunchingLeftHand.GetComponent<Animator>().SetBool("PunchingLeft", true);
        PunchingRightHand.SetActive(false);
       
        
    }
    public void ReleaseLeft()
    {
        PunchingLeftHand.GetComponent<Animator>().SetBool("PunchingLeft", false);
        IdleLeftHand.SetActive(true);
        PunchingLeftHand.SetActive(false);
    }

    //knife movements
    public void KnifeStab()
    {
        //KN.SetTrigger("stab");
    }
    public void KnifeRelease()
    {
        //Knifehands.GetComponent<Animator>().SetBool("unstab", false);
    }
    public void KnifeEquip()
    {
        Knifehands.SetActive(true);
        IdleHands.SetActive(false);
        PunchingHands.SetActive(false);
        Vector1.SetActive(false);
        HuntingRifle.SetActive(false);
        HandGun.SetActive(false);
    }



}
