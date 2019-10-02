using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponry : MonoBehaviour
{
    public GameObject IdleHands;
    public GameObject IdleLeftHand;
    public GameObject IdleRightHand;

    public GameObject PunchingHands;
    public GameObject PunchingLeftHand;
    public GameObject PunchingRightHand;

    public GameObject Vector1;
   
    // Start is called before the first frame update
    void Start()
    {
        PunchingHands.SetActive(false);
        IdleHands.SetActive(true);
    }

    // Update is called once per frame
 
    //Vectro based motions
    public void FireVector()
    {

    }
    public void HoldVector()
    {
        IdleHands.SetActive(false);
        PunchingHands.SetActive(false);
        Vector1.SetActive(true);
    }
    //hand based motions
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



}
