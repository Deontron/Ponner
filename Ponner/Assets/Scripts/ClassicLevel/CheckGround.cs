using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WhitePlatform") || other.CompareTag("BlackPlatform") || other.CompareTag("RespawnPlatform"))
        {
            GetComponentInParent<Player>().checkGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WhitePlatform") || other.CompareTag("BlackPlatform") || other.CompareTag("RespawnPlatform"))
        {
            GetComponentInParent<Player>().checkGround = false;
            GetComponentInParent<Player>().doubleJump = true;
        }
    }
}
