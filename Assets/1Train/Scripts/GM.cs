using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static bool mouseIsPressed;
    public static bool s1InInventory;
    public static bool s2InInventory;
    public static bool s3InInventory;
    public static bool event4Trigger;
    public static bool radioPickedUp;
    public static bool radioStart;

    public static bool switch1InRange;
    public static bool switch2InRange;
    public static bool switch3InRange;

    public static bool pedetalInRange;
    public static bool pedetal2InRange;
    public static bool pedetal3InRange;

    public static bool slot1Active;
    public static bool slot2Active;
    public static bool slot3Active;

    public static bool s1InHand;
    public static bool s2InHand;
    public static bool s3InHand;

    public static bool stat1OnPedestal;
    public static bool stat2OnPedestal;
    public static bool stat3OnPedestal;

    public GameObject event4Trig;

    public GameObject blackScreen;
    public GameObject blackScreen2;
    public GameObject blackScreen3;
    public GameObject blackScreen4;

    public GameObject inventoryBar;

    public GameObject wbFX;
    public GameObject grainFX;

    public GameObject closedDoor;
    public GameObject openedDoor;

    public GameObject Luggage1;
    public GameObject Luggage2;

    public GameObject pedestals;
    public GameObject switches;

    public GameObject lvl1;
    public GameObject lvl2;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;
    public GameObject light7;
    public GameObject light8;
    public GameObject light9;
    public GameObject light10;
    public GameObject light11;

    public GameObject log;
    public GameObject log2;

    public GameObject stat1InInv;
    public GameObject stat2InInv;
    public GameObject stat3InInv;

    public GameObject redMoon;

    public GameObject openDoor;
    public GameObject fallingLuggages;
    public GameObject trainWhistle;

    int count;
    int count2;
    int count3;
    int count4;

    bool actionLock;

    private void Update()
    {
        EventActivate();

        //Inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            count += 1;
            InventorySystem(count);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && slot1Active == true)
        {
            count2 += 1;
            if (count2 % 2 == 1 && actionLock == false)
            {
                stat1InInv.SetActive(true);
                actionLock = true;
                s1InHand = true;
            }
            else
            {
                stat1InInv.SetActive(false);
                actionLock = false;
                s1InHand = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && slot2Active == true)
        {
            count3 += 1;
            if (count3 % 2 == 1 && actionLock == false)
            {
                stat2InInv.SetActive(true);
                actionLock = true;
                s2InHand = true;
            }
            else
            {
                stat2InInv.SetActive(false);
                actionLock = false;
                s2InHand = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && slot3Active == true)
        {
            count4 += 1;
            if (count4 % 2 == 1 && actionLock == false)
            {
                stat3InInv.SetActive(true);
                actionLock = true;
                s3InHand = true;
            }
            else
            {
                stat3InInv.SetActive(false);
                actionLock = false;
                s3InHand = false;
            }
        }

        if(slot1Active == false)
        {
            stat1InInv.SetActive(false);
        }

        if (slot2Active == false)
        {
            stat2InInv.SetActive(false);
        }

        if (slot3Active == false)
        {
            stat3InInv.SetActive(false);
        }
    }

    void EventActivate()
    {
        if(s1InInventory == true)
        {
            StartCoroutine(StartEvent1(0.5f));
            slot1Active = true;
            s1InInventory = false;
        }

        if(s2InInventory == true)
        {
            StartCoroutine(CamShake(0.5f));
            slot2Active = true;
            s2InInventory = false;
        }

        if(s3InInventory == true)
        {
            StartCoroutine(BlackScreen());
            slot3Active = true;
            s3InInventory = false;
        }

        if(event4Trigger == true)
        {
            StartCoroutine(StartEvent4(11f));

            event4Trigger = false;
        }

        if(stat1OnPedestal == true && stat2OnPedestal == true && stat3OnPedestal == true)
        {
            StartCoroutine(StartEvent5(5f));
            stat3OnPedestal = false;
        }
    }

    void InventorySystem(int i)
    {
        if(i % 2 == 1)
        {
            inventoryBar.SetActive(true);
        } else
        {
            inventoryBar.SetActive(false);
            i = 0;
        }
    }

    IEnumerator StartEvent1(float time)
    {
        yield return new WaitForSeconds(time);

        blackScreen.SetActive(true);

        openDoor.SetActive(true);

        redMoon.SetActive(true);

        light1.SetActive(false);
        light2.SetActive(false);
        light4.SetActive(true);
        light7.SetActive(true);
        light9.SetActive(true);

        closedDoor.SetActive(false);
        openedDoor.SetActive(true);

        FlickeringLight[] lightArray = FindObjectsOfType<FlickeringLight>();

         foreach(FlickeringLight lght in lightArray)
        {
            lght.enabled = true;
        }
    }

    IEnumerator CamShake(float time)
    {
        yield return new WaitForSeconds(time);

        //black screen
        blackScreen2.SetActive(true);

        //StartEvent
        StartCoroutine(StartEvent2());
    }

    IEnumerator BlackScreen()
    {
        yield return new WaitForSeconds(0f);
        radioStart = true;
        blackScreen3.SetActive(true);
        StartCoroutine(StartEvent3());

    }


    IEnumerator StartEvent2()
    {
        yield return new WaitForSeconds(1.5f);
        //FindObjectOfType<CameraShaker>().enabled = false;
        //camera position = main pos

        fallingLuggages.SetActive(true);

        //vintage camera fx
        redMoon.SetActive(false);
        wbFX.SetActive(true);

        //lights
        light7.SetActive(false);
        light9.SetActive(false);
        light5.SetActive(true);
        light6.SetActive(true);
        light8.SetActive(true);

        //luggage
        Luggage1.SetActive(false);
        Luggage2.SetActive(true);

        FlickeringLight[] lightArray = FindObjectsOfType<FlickeringLight>();

        foreach (FlickeringLight lght in lightArray)
        {
            lght.enabled = false;
        }
    }

    IEnumerator StartEvent3()
    {
        yield return new WaitForSeconds(0.5f);

        //grain FX
        wbFX.SetActive(false);
        grainFX.SetActive(true);

        //lights
        light5.SetActive(false);
        light6.SetActive(false);
        light8.SetActive(false);
        light1.SetActive(true);
        light3.SetActive(true);

        event4Trig.SetActive(true);

    }

    IEnumerator StartEvent4(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Mereee");

        log.SetActive(true);
        StartCoroutine(StartLog2(5f));

        //lights
        light1.SetActive(false);
        light4.SetActive(true);
        light5.SetActive(true);
        light6.SetActive(true);
        light7.SetActive(true);
        light8.SetActive(true);

        //signs.SetActive(true);
        pedestals.SetActive(true);
        switches.SetActive(true);

        FlickeringLight[] lightArray = FindObjectsOfType<FlickeringLight>();

        foreach (FlickeringLight lght in lightArray)
        {
            lght.enabled = false;
        }
    }

    IEnumerator StartLog2(float time)
    {
        yield return new WaitForSeconds(time);

        log.SetActive(true);
        log2.SetActive(true);
    }

    IEnumerator StartEvent5(float time)
    {
        yield return new WaitForSeconds(time);

        blackScreen4.SetActive(true);

        light10.SetActive(true);
        light11.SetActive(true);

        lvl1.SetActive(false);
        lvl2.SetActive(true);

        trainWhistle.SetActive(true);
    }


}
