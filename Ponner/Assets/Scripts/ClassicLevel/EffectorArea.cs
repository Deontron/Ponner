using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorArea : MonoBehaviour
{
    public float powerForward;

    private void Start()
    {
        switch (transform.parent.tag)
        {
            case "WhitePlatform":
                powerForward = PlayerPrefs.GetFloat("EffectorPower", 20);
                break;

            case "BlackPlatform":
                powerForward = PlayerPrefs.GetFloat("EffectorPower", 20) * -1;
                break;

            case "RespawnPlatform":
                powerForward = 20;
                break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.forward * powerForward);
        }
    }
}
