using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalEnergy : MonoBehaviour
{
    public TMP_Text totalEnergy;
    void Start()
    {
        totalEnergy.text = "Energy: " + PlayerPrefs.GetFloat("Energy").ToString();
    }
}
