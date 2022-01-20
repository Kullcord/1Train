using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Vector3 initialPos;
    bool active;

    private void Start()
    {
        initialPos = this.transform.position;
        Debug.Log(initialPos);
    }

    private void Update()
    {
        if(active == true)
        {
            this.transform.position = initialPos;
            active = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            active = true;
        } 
    }
}
