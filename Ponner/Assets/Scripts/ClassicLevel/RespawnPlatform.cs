using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tracker"))
        {
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);

        gameObject.SetActive(false);
    }
}
