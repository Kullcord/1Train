using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

    //statue 123


    private void Update()
    {
        if (GM.switch1InRange == true && Input.GetMouseButtonDown(0))
        {
            light1.SetActive(false);
            Debug.Log("l1");
        }

        if (GM.switch2InRange == true && Input.GetMouseButtonDown(0))
        {
            light2.SetActive(false);
            Debug.Log("l2");
        }

        if (GM.switch3InRange == true && Input.GetMouseButtonDown(0))
        {
            light3.SetActive(false);
            Debug.Log("l3");
        }
    }
}
