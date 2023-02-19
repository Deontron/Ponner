using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    public TMP_Text highscore;
    public TMP_Text arenaHighscore;
    void Start()
    {
        highscore.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore", 0).ToString();
        arenaHighscore.text = "ArenaHighscore : " + PlayerPrefs.GetFloat("ArenaHighScore", 0).ToString();
    }
}
