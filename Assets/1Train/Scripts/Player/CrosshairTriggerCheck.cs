using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTriggerCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("statue1"))
        {
            Debug.Log("Surprinzator");
        }
    }
}
