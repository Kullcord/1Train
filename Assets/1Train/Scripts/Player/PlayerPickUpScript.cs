using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpScript : MonoBehaviour
{
    public Transform hand;

    public GameObject stST;
    public AudioSource startStatic;

    public GameObject _staticSource;
    public GameObject morganSource;

    public GameObject statue1Text1;
    public GameObject statue1Text2;

    public GameObject statue2Text1;
    public GameObject statue2Text2;

    public GameObject statue3Text1;

    public GameObject radioLog1;
    public GameObject radioLog2;

    public GameObject tutorialTxt;

    public GameObject statue1;
    public GameObject statue2;
    public GameObject statue3;

    public GameObject radio;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

    public GameObject eye;
    public GameObject triangle;
    public GameObject fish;

    public GameObject s1Placed;
    public GameObject s2Placed;
    public GameObject s3Placed;

    public GameObject tutText;

    bool s1InRange;
    bool s1PickedUp;

    bool s2InRange;
    bool s2PickedUp;

    bool s3InRange;
    bool s3PickedUp;

    bool radioInRange;
    public static bool radioPickedUp;

    Vector3 initialPos;
    Vector3 initialPos2;
    Vector3 initialPos3;
    Vector3 initialPos4;

    private void Start()
    {
        initialPos = statue1.transform.position;
        initialPos2 = statue2.transform.position;
        initialPos3 = statue3.transform.position;
        initialPos4 = radio.transform.position;
    }

    private void Update()
    {
        if(s1PickedUp == true && Input.GetMouseButtonDown(1))
        {
            statue1.SetActive(false);
            statue2.SetActive(true);
            GM.s1InInventory = true;
            s1InRange = false;
            s1PickedUp = false;
        }

        if (s2PickedUp == true && Input.GetMouseButtonDown(1))
        {
            statue2.SetActive(false);
            statue3.SetActive(true);
            GM.s2InInventory = true;
            s2InRange = false;
            s2PickedUp = false;
        }

        if (s3PickedUp == true && Input.GetMouseButtonDown(1))
        {
            statue3.SetActive(false);
            GM.s3InInventory = true;
            s3InRange = false;
            s3PickedUp = false;
            stST.SetActive(true);
            startStatic.Play();
        }

        if (Input.GetMouseButtonDown(0))
        {
            PickUpFnction();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DropFnction();
        }
    }

    void PickUpFnction()
    {
        Debug.Log("MouseClick");
        if (s1InRange == true)
        {
            statue1.GetComponent<Rigidbody>().isKinematic = true;
            statue1.GetComponent<BoxCollider>().enabled = false;

            statue1.transform.position = hand.transform.position;
            statue1.transform.parent = GameObject.Find("Hand").transform;

            statue1Text1.SetActive(true);

            if (GM.s1InInventory == false)
            {
                StartCoroutine(TxtActivate(statue1Text2, 4f));
            }

            s1PickedUp = true;
        }

        if(s2InRange == true)
        {
            statue2.GetComponent<Rigidbody>().isKinematic = true;
            statue2.GetComponent<BoxCollider>().enabled = false;

            statue2.transform.position = hand.transform.position;
            statue2.transform.parent = GameObject.Find("Hand").transform;

            statue2Text1.SetActive(true);

            if (GM.s2InInventory == false)
            {
                StartCoroutine(TxtActivate(statue2Text2, 4f));
            }

            s2PickedUp = true;
        }

        if(s3InRange == true)
        {
            statue3.GetComponent<Rigidbody>().isKinematic = true;
            statue3.GetComponent<BoxCollider>().enabled = false;

            statue3.transform.position = hand.transform.position;
            statue3.transform.parent = GameObject.Find("Hand").transform;

            statue3Text1.SetActive(true);

            s3PickedUp = true;
        }

        if (radioInRange == true)
        {
            startStatic.Stop();

            radio.GetComponent<Rigidbody>().isKinematic = true;
            radio.GetComponent<BoxCollider>().enabled = false;

            radio.transform.position = hand.transform.position;
            radio.transform.parent = GameObject.Find("Hand").transform;

            radioLog1.SetActive(true);
            StartCoroutine(TxtActivate(radioLog2, 4f));

            GM.radioPickedUp = true;
            StartAudio();
        }

        //switches
        if (GM.switch1InRange == true)
        {
            light1.SetActive(false);
            fish.SetActive(true);
            Debug.Log("l1");
        }

        if (GM.switch2InRange == true)
        {
            light3.SetActive(false);
            triangle.SetActive(true);
            Debug.Log("l2");
        }

        if (GM.switch3InRange == true)
        {
            light2.SetActive(false);
            eye.SetActive(true);
            Debug.Log("l3");
        }

        //pedestal
        if(GM.pedetalInRange == true && GM.s1InHand == true)//fish
        {
            s1Placed.SetActive(true);
            GM.stat1OnPedestal = true;
            GM.slot1Active = false;
        }

        if (GM.pedetal2InRange == true && GM.s3InHand == true)//eye
        {
            s3Placed.SetActive(true);
            GM.stat3OnPedestal = true;
            GM.slot3Active = false;
        }

        if (GM.pedetal3InRange == true && GM.s2InHand == true)//triangle
        {
            s2Placed.SetActive(true);
            GM.stat2OnPedestal = true;
            GM.slot2Active = false;
        }
    }

    void DropFnction()
    {
        if (s1PickedUp == true)
        {
            statue1Text1.SetActive(false);
            statue1Text2.SetActive(false);

            statue1.GetComponent<Rigidbody>().isKinematic = false;
            statue1.GetComponent<BoxCollider>().enabled = true;

            statue1.transform.parent = null;
            statue1.transform.position = initialPos;

            s1PickedUp = false;
        }

        if (s2PickedUp == true)
        {
            statue2Text1.SetActive(false);
            statue2Text2.SetActive(false);

            statue2.GetComponent<Rigidbody>().isKinematic = false;
            statue2.GetComponent<BoxCollider>().enabled = true;

            statue2.transform.parent = null;
            statue2.transform.position = initialPos2;

            s2PickedUp = false;
        }

        if (s3PickedUp == true)
        {
            statue3Text1.SetActive(false);

            statue3.GetComponent<Rigidbody>().isKinematic = false;
            statue3.GetComponent<BoxCollider>().enabled = true;

            statue3.transform.parent = null;
            statue3.transform.position = initialPos3;

            s3PickedUp = false;
        }

        if (GM.radioPickedUp == true)
        {
            //textfalse

            radio.GetComponent<Rigidbody>().isKinematic = false;
            radio.GetComponent<BoxCollider>().enabled = true;

            radio.transform.parent = null;
            radio.transform.position = initialPos4;

            GM.radioPickedUp = false;
            radioInRange = false;
            StopAudio();
        }


    }

    void StartAudio()
    {
        _staticSource.SetActive(true);
        morganSource.SetActive(true);
        GetComponent<StaticController>().enabled = true;
    }

    void StopAudio()
    {
        _staticSource.SetActive(false);
        startStatic.Play();
        morganSource.SetActive(false);
        GetComponent<StaticController>().enabled = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("statue1"))
        {
            s1InRange = true;
        }

        if (other.CompareTag("statue2"))
        {
            s2InRange = true;
            Debug.Log("hmm");
        }

        if (other.CompareTag("statue3"))
        {
            s3InRange = true;
        }

        if (other.CompareTag("radio") && GM.radioStart == true)
        {
            radioInRange = true;
        }

        //switch
        if (other.CompareTag("switch1"))
        {
            GM.switch1InRange = true;
            Debug.Log("s1");
        }

        if (other.CompareTag("switch2"))
        {
            GM.switch2InRange = true;
            Debug.Log("s2");
        }

        if (other.CompareTag("switch3"))
        {
            GM.switch3InRange = true;
            Debug.Log("s3");
        }


        //Event4
        if (other.CompareTag("event4"))
        {
            GM.event4Trigger = true;
            Debug.Log("triggeruieste");
        }

        //Pedestals
        if (other.CompareTag("pedestal1"))
        {
            GM.pedetalInRange = true;
        }

        if (other.CompareTag("pedestal2"))
        {
            GM.pedetal2InRange = true;
        }

        if (other.CompareTag("pedestal3"))
        {
            GM.pedetal3InRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("statue1"))
        {
            s1InRange = false;
        }

        if (other.CompareTag("statue2"))
        {
            s2InRange = false;
        }

        if (other.CompareTag("statue3"))
        {
            s3InRange = false;
        }

        if (other.CompareTag("radio"))
        {
            radioInRange = false;
        }

        //Switch
        if (other.CompareTag("switch1"))
        {
            GM.switch1InRange = false;
            tutText.SetActive(false);
        }

        if (other.CompareTag("switch2"))
        {
            GM.switch2InRange = false;
            tutText.SetActive(false);
        }

        if (other.CompareTag("switch3"))
        {
            GM.switch3InRange = false;
            tutText.SetActive(false);
        }

        //Event4
        if (other.CompareTag("event4"))
        {
            GM.event4Trigger = true;
        }

        //Pedestals
        if (other.CompareTag("pedestal1"))
        {
            GM.pedetalInRange = true;
            tutText.SetActive(false);
        }

        if (other.CompareTag("pedestal2"))
        {
            GM.pedetal2InRange = true;
            tutText.SetActive(false);
        }

        if (other.CompareTag("pedestal3"))
        {
            GM.pedetal3InRange = true;
            tutText.SetActive(false);
        }
    }

    IEnumerator TxtActivate(GameObject txt, float time)
    {
        yield return new WaitForSeconds(time);
        txt.SetActive(true);
        StartCoroutine(DestroyText(txt, time));

    }

    IEnumerator DestroyText(GameObject txt, float time)
    {
        yield return new WaitForSeconds(time);
        txt.SetActive(false);
        tutorialTxt.SetActive(true);
        StartCoroutine(tutTxtInv(time));
    }

    IEnumerator tutTxtInv(float time)
    {
        yield return new WaitForSeconds(time);
        tutorialTxt.SetActive(false);
    }
}
