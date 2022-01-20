using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    public GameObject blackscreen;
    public GameObject endGameScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FinalEvent(10f));
        }
    }

    IEnumerator FinalEvent(float time)
    {
        yield return new WaitForSeconds(time);
        blackscreen.SetActive(true);

        StartCoroutine(FinalScreen(0.5f));

    }

    IEnumerator FinalScreen(float time)
    {
        yield return new WaitForSeconds(time);
        endGameScreen.SetActive(true);
    }
}
