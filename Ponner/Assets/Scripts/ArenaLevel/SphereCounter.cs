using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereCounter : MonoBehaviour
{
    public TMP_Text scoreText;

    private float score;

    private void Start()
    {
        PlayerPrefs.SetFloat("ArenaLastScore", 0);
    }

    public void CountSpheres(GameObject sphere)
    {
        sphere.SetActive(false);

        score++;

        scoreText.text = score.ToString();

        PlayerPrefs.SetFloat("ArenaLastScore", score);

        SetArenaHighScore();
    }

    private void SetArenaHighScore()
    {
        if (score > PlayerPrefs.GetFloat("ArenaHighscore", 0))
        {
            PlayerPrefs.SetFloat("ArenaHighscore", score);
        }
    }
}
