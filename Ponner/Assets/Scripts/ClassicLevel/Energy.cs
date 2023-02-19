using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public ParkourManager parkourManager;
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.EnergyCounter();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
    }

    public void SetPos()
    {
        parkourManager.SetEnergyPosition(gameObject);
    }
}
