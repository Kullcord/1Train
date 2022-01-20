using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light _light;
    public Light _araeLight;

    public float MinTime;
    public float MaxTime;
    public float Timer;

    public AudioSource AS;
    public AudioClip LightAudio;

    private void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
        //Debug.Log(Timer);
    }

    private void Update()
    {
        Flicker();
    }

    void Flicker()
    {
        if(Timer > 0)
            Timer -= Time.deltaTime;

        if(Timer <= 0)
        {
            _light.enabled = !_light.enabled;
            _araeLight.enabled = !_araeLight.enabled;
            Timer = Random.Range(MinTime, MaxTime);
            AS.PlayOneShot(LightAudio);
        }
    }

}
