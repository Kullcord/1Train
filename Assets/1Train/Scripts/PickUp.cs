using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform hand;
    public GameObject displayText;

    /*bool isPressed = false;*/
    Vector3 initialPos;

    private void Start()
    {
        initialPos = this.transform.position;
    }

    private void Update()
    {
        if(GM.mouseIsPressed == true && Input.GetMouseButtonDown(1))
        {
            Destroy(this.gameObject);
            Debug.Log("mererau");
        }
    }

    void OnMouseDown()
    {
        Debug.Log("mere");
        GM.mouseIsPressed = true;
        //displayText.SetActive(true);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<BoxCollider>().isTrigger = true;
        this.transform.position = hand.transform.position;
        this.transform.parent = GameObject.Find("Hand").transform;
    }

    void OnMouseUp()
    {
        GM.mouseIsPressed = false;
        //displayText.SetActive(false);
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            this.transform.position = initialPos;
        }
    }
}
