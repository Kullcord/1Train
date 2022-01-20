using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvScript : MonoBehaviour
{
    public GameObject invSlot1;
    public GameObject invSlot2;
    public GameObject invSlot3;

    void Update()
    {
        if(GM.slot1Active == true)
        {
            invSlot1.SetActive(true);
        } else
        {
            invSlot1.SetActive(false);
        }

        if (GM.slot2Active == true)
        {
            invSlot2.SetActive(true);
        } else
        {
            invSlot2.SetActive(false);
        }

        if (GM.slot3Active == true)
        {
            invSlot3.SetActive(true);
        } else
        {
            invSlot3.SetActive(false);
        }
    }
}
