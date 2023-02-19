using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    public TMP_Text currentEnergyAmountText;

    //void Update()
    //{
    //    //fpsCounter = 1 / Time.unscaledDeltaTime;

    //    //fps.text = fpsCounter.ToString("f1");
    //}

    public void SetEnergyAmountTexts(float currentEnergy)
    {
        currentEnergyAmountText.text =currentEnergy.ToString();
    }
}
