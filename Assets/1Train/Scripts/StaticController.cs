using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticController : MonoBehaviour
{
    public AudioSource _static;
    public AudioSource morgan;
    public AudioSource staticClip;

    public Transform distance;
    public Transform player;

    private float normalizedDist;

    private float prevX;
    private float prevZ;

    private void Start()
    {
        _static.loop = true;

        prevX = this.transform.position.x;
        prevZ = this.transform.position.z;
    }

    private void Update()
    {
        normalizedDist = Vector3.Distance(distance.position, player.position);

        if (prevX != this.transform.position.x && prevZ != this.transform.position.z)
        {
            _static.volume = normalizedDist / 2;
            morgan.volume = 1 / normalizedDist * 2;
            staticClip.volume = normalizedDist / 2 - morgan.volume;

            if (System.DateTime.Now.Ticks % 3 == 0 && staticClip.isPlaying == false)
            {
                staticClip.Play();
            }

            /*Debug.Log("StaticDebug: " + _static.volume);
            Debug.Log("MorganDebug: " + morgan.volume);*/

            prevX = this.transform.position.x;
            prevZ = this.transform.position.z;
        }
    }
}
