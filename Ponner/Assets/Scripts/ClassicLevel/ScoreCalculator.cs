using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    public TMP_Text scoreText;
    public float score;

    private float scoreDivider;

    private void Start()
    {
        scoreDivider = PlayerPrefs.GetFloat("ScoreDivider", 2);
        PlayerPrefs.SetFloat("LastScore", 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedSphere") || other.CompareTag("GreenSphere"))
        {
            score += 1;
            scoreText.text = (score / scoreDivider).ToString();

            PlayerPrefs.SetFloat("LastScore", score / scoreDivider);

            SetHighscore();
        }
    }

    private void SetHighscore()
    {
        if (PlayerPrefs.GetFloat("LastScore") > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", PlayerPrefs.GetFloat("LastScore"));
        }
    }
}
