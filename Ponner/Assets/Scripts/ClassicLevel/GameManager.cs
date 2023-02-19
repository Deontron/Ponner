using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GamePanel gamePanelScript;

    [HideInInspector]
    public float currentEnergyAmount;

    private float totalEnergyAmount;


    private void Start()
    {
        currentEnergyAmount = 0;
        gamePanelScript.SetEnergyAmountTexts(currentEnergyAmount);
    }

    public void EnergyCounter()
    {
        currentEnergyAmount++;
        totalEnergyAmount = PlayerPrefs.GetFloat("Energy", 0);

        PlayerPrefs.SetFloat("Energy", totalEnergyAmount + 1);

        gamePanelScript.SetEnergyAmountTexts(currentEnergyAmount);
    }
}
