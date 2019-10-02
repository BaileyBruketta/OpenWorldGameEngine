using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixteenBlock : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject ten;
    public GameObject eleven;
    public GameObject twelve;
    public GameObject thirteen;
    public GameObject fourteen;
    public GameObject fifteen;
    public GameObject sixteen;

    public float xone;
    public float xtwo;
    public float xthree;
    public float xfour;
    public float xfive;

    public float zone;
    public float ztwo;
    public float zthree;
    public float zfour;
    public float zfive;

    public float updatetimer;

    public Transform player;
    public float timer;
    public float Columntimer1;
    public float Columntimer2;
    public float Columntimer3;
    public float Columntimer4;
    // Start is called before the first frame update
    void Start()
    {
        updatetimer = 5;
        timer = 20;
        Columntimer1 = 9;
        Columntimer2 = 9;
        Columntimer3 = 9;
        Columntimer4 = 9;
    }

    // Update is called once per frame
  

    public void Updatemap()
    {
        timer -= .5f;

        if (timer == 18)
        {
            Column1();
        }
        if (timer == 14)
        {
            Column2();
        }
        if (timer == 8)
        {
            Column3();
        }
        if (timer == 3)
        {
            Column4();
        }
        if (timer < 1)
        {
            timer = 20;
        }
    }
    
    
    //columns
    public void Column1()
    {
        Columntimer1 -= .5f;

        if (Columntimer1 == 8)
        {
            Block1();
        }
        if (Columntimer1 == 6)
        {
            Block5();
        }
        if (Columntimer1 == 4)
        {
            Block9();
        }
        if (Columntimer1 == 2)
        {
            Block13();
        }
        if (Columntimer1 < 1)
        {
            Columntimer1 = 9;
        }
    }
    public void Column2()
    {
        Columntimer2 -= .5f;

        if (Columntimer2 == 8)
        {
            Block2();
        }
        if (Columntimer2 == 6)
        {
            Block6();
        }
        if (Columntimer2 == 4)
        {
            Block10();
        }
        if (Columntimer2 == 2)
        {
            Block14();
        }
        if (Columntimer2 < 1)
        {
            Columntimer2 = 9;
        }
    }
    public void Column3()
    {
        Columntimer3 -= .5f;

        if (Columntimer3 == 8)
        {
            Block3();
        }
        if (Columntimer3 == 6)
        {
            Block7();
        }
        if (Columntimer3 == 4)
        {
            Block11();
        }
        if (Columntimer3 == 2)
        {
            Block15();
        }
        if (Columntimer3 < 1)
        {
            Columntimer3 = 9;
        }
    }
    public void Column4()
    {
        Columntimer4 -= .5f;

        if (Columntimer4 == 8)
        {
            Block4();
        }
        if (Columntimer4 == 6)
        {
            Block8();
        }
        if (Columntimer4 == 4)
        {
            Block12();
        }
        if (Columntimer4 == 2)
        {
            Block16();
        }
        if (Columntimer4 < 1)
        {
            Columntimer4 = 9;
        }
    }
    //column 1

    public void Block1()
    {
        if (player.transform.position.x > xone - 100)
        {
            if (player.transform.position.x < xtwo + 100)
            {
                if (player.transform.position.z > zone - 100)
                {
                    if (player.transform.position.z < ztwo + 100)
                    {
                        one.SetActive(true);
                    }
                }
                else one.SetActive(false);
            }
            else one.SetActive(false);
        }
        else one.SetActive(false);
    }
    public void Block2()
    {
        if (player.transform.position.x > xtwo - 100)
        {
            if (player.transform.position.x < xthree + 100)
            {
                if (player.transform.position.z > zone - 100)
                {
                    if (player.transform.position.z < ztwo + 100)
                    {
                        two.SetActive(true);
                    }
                    else two.SetActive(false);
                }
                else two.SetActive(false);
            }
            else two.SetActive(false);
        }
        else two.SetActive(false);
    }
    public void Block3()
    {
        if (player.transform.position.x > xthree - 100)
        {
            if (player.transform.position.x < xfour + 100)
            {
                if (player.transform.position.z > zone - 100)
                {
                    if (player.transform.position.z < ztwo + 100)
                    {
                        three.SetActive(true);
                    }
                    else three.SetActive(false);
                }
                else three.SetActive(false);
            }
            else three.SetActive(false);
        }
        else three.SetActive(false);
    }
    public void Block4()
    {
        if (player.transform.position.x > xfour - 100)
        {
            if (player.transform.position.x < xfive + 100)
            {
                if (player.transform.position.z > zone - 100)
                {
                    if (player.transform.position.z < ztwo + 100)
                    {
                        four.SetActive(true);
                    }
                    else four.SetActive(false);
                }
                else four.SetActive(false);
            }
            else four.SetActive(false);
        }
        else four.SetActive(false);
    }
    //column 2
    public void Block5()
    {
        if (player.transform.position.x > xone - 100)
        {
            if (player.transform.position.x < xtwo + 100)
            {
                if (player.transform.position.z > ztwo - 100)
                {
                    if (player.transform.position.z < zthree + 100)
                    {
                        five.SetActive(true);
                    }
                }
                else five.SetActive(false);
            }
            else five.SetActive(false);
        }
        else five.SetActive(false);
    }
    public void Block6()
    {
        if (player.transform.position.x > xtwo - 100)
        {
            if (player.transform.position.x < xthree + 100)
            {
                if (player.transform.position.z > ztwo - 100)
                {
                    if (player.transform.position.z < zthree + 100)
                    {
                        six.SetActive(true);
                    }
                    else six.SetActive(false);
                }
                else six.SetActive(false);
            }
            else six.SetActive(false);
        }
        else six.SetActive(false);
    }
    public void Block7()
    {
        if (player.transform.position.x > xthree - 100)
        {
            if (player.transform.position.x < xfour + 100)
            {
                if (player.transform.position.z > ztwo - 100)
                {
                    if (player.transform.position.z < zthree + 100)
                    {
                        seven.SetActive(true);
                    }
                    else seven.SetActive(false);
                }
                else seven.SetActive(false);
            }
            else seven.SetActive(false);
        }
        else seven.SetActive(false);
    }
    public void Block8()
    {
        if (player.transform.position.x > xfour - 100)
        {
            if (player.transform.position.x < xfive + 100)
            {
                if (player.transform.position.z > ztwo - 100)
                {
                    if (player.transform.position.z < zthree + 100)
                    {
                        eight.SetActive(true);
                    }
                    else eight.SetActive(false);
                }
                else eight.SetActive(false);
            }
            else eight.SetActive(false);
        }
        else eight.SetActive(false);
    }
    //column 3
    public void Block9()
    {
        if (player.transform.position.x > xone - 100)
        {
            if (player.transform.position.x < xtwo + 100)
            {
                if (player.transform.position.z > zthree - 100)
                {
                    if (player.transform.position.z < zfour + 100)
                    {
                        nine.SetActive(true);
                    }
                }
                else nine.SetActive(false);
            }
            else nine.SetActive(false);
        }
        else nine.SetActive(false);
    }
    public void Block10()
    {
        if (player.transform.position.x > xtwo - 100)
        {
            if (player.transform.position.x < xthree + 100)
            {
                if (player.transform.position.z > zthree - 100)
                {
                    if (player.transform.position.z < zfour + 100)
                    {
                        ten.SetActive(true);
                    }
                    else ten.SetActive(false);
                }
                else ten.SetActive(false);
            }
            else ten.SetActive(false);
        }
        else ten.SetActive(false);
    }
    public void Block11()
    {
        if (player.transform.position.x > xthree - 100)
        {
            if (player.transform.position.x < xfour + 100)
            {
                if (player.transform.position.z > zthree - 100)
                {
                    if (player.transform.position.z < zfour + 100)
                    {
                        eleven.SetActive(true);
                    }
                    else eleven.SetActive(false);
                }
                else eleven.SetActive(false);
            }
            else eleven.SetActive(false);
        }
        else eleven.SetActive(false);
    }
    public void Block12()
    {
        if (player.transform.position.x > xfour - 100)
        {
            if (player.transform.position.x < xfive + 100)
            {
                if (player.transform.position.z > zthree - 100)
                {
                    if (player.transform.position.z < zfour + 100)
                    {
                        twelve.SetActive(true);
                    }
                    else twelve.SetActive(false);
                }
                else twelve.SetActive(false);
            }
            else twelve.SetActive(false);
        }
        else twelve.SetActive(false);
    }
    //column 4
    public void Block13()
    {
        if(player.transform.position.x > xfour - 100)
        {
            if (player.transform.position.x < xfive + 100)
            {
                if (player.transform.position.z > zfour - 100)
                {
                    if (player.transform.position.z < zfive + 100)
                    {
                        thirteen.SetActive(true);
                    }
                    else thirteen.SetActive(false);
                }
                else thirteen.SetActive(false);
            }
            else thirteen.SetActive(false);
        }
        else thirteen.SetActive(false);
    }
    public void Block14()
    {
        if (player.transform.position.x > xtwo - 100)
        {
            if (player.transform.position.x < xthree + 100)
            {
                if (player.transform.position.z > zfour - 100)
                {
                    if (player.transform.position.z < zfive + 100)
                    {
                        fourteen.SetActive(true);
                    }
                    else fourteen.SetActive(false);
                }
                else fourteen.SetActive(false);
            }
            else fourteen.SetActive(false);
        }
        else fourteen.SetActive(false);
    }
    public void Block15()
    {
        if (player.transform.position.x > xthree - 100)
        {
            if (player.transform.position.x < xfour + 100)
            {
                if (player.transform.position.z > zfour - 100)
                {
                    if (player.transform.position.z < zfive + 100)
                    {
                        fifteen.SetActive(true);
                    }
                    else fifteen.SetActive(false);
                }
                else fifteen.SetActive(false);
            }
            else fifteen.SetActive(false);
        }
        else fifteen.SetActive(false);
    }
    public void Block16()
    {
        if (player.transform.position.x > xfour - 100)
        {
            if (player.transform.position.x < xfive + 100)
            {
                if (player.transform.position.z > zfour - 100)
                {
                    if (player.transform.position.z < zfive + 100)
                    {
                        sixteen.SetActive(true);
                    }
                    else sixteen.SetActive(false);
                }
                else sixteen.SetActive(false);
            }
            else sixteen.SetActive(false);
        }
        else sixteen.SetActive(false);

    }

}
