using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEnergy : MonoBehaviour
{
    public GameManager gameManager;
    public ArenaManager arenaManager;
    public ArenaJumpButton arenaJumpButton;

    private float energyX;
    private float energyY;
    private float energyZ;

    private void Start()
    {
        SetEnergyPosition();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.EnergyCounter();
            arenaManager.TimerForArenaEnergy(gameObject);

            arenaJumpButton.slider.value += 0.2f;

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
    }

    public void SetEnergyPosition()
    {
        energyX = Random.Range(0, 250);
        energyY = Random.Range(0, 250);
        energyZ = Random.Range(0, 250);

        transform.position = new Vector3(energyX, energyY, energyZ);
    }
}
