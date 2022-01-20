using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringStart : MonoBehaviour
{
    void Update()
    {
        if(GM.s1InInventory == true)
        {
            this.GetComponent<FlickeringLight>().enabled = true;
        }
    }
}
