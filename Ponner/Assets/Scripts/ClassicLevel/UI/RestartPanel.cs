using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartPanel : MonoBehaviour
{
    public GameObject player;

    public int sceneId;

    public string gameMode;

    public TMP_Text totalEnergy;
    public TMP_Text highscore;
    public TMP_Text score;

    public Button continueButton;
    public TMP_Text continueDurationText;
    public float continuePrice;
    public float durationForContinue;
    private float durationCounter;
    private bool isCounterOpen;

    private string highscorePref;
    private string lastScorePref;

    private void Start()
    {
        durationCounter = durationForContinue;

        switch (gameMode)
        {
            case "Classic":
                highscorePref = "Highscore";
                lastScorePref = "LastScore";
                break;

            case "Arena":
                highscorePref = "ArenaHighscore";
                lastScorePref = "ArenaLastScore";
                break;
        }
    }

    private void Update()
    {
        if (isCounterOpen)
        {
            TimerForContinue();
        }
    }
    public void FirstProcess()
    {
        totalEnergy.text = PlayerPrefs.GetFloat("Energy", 0).ToString();
        highscore.text = PlayerPrefs.GetFloat(highscorePref, 0).ToString();
        score.text = PlayerPrefs.GetFloat(lastScorePref, 0).ToString();

        isCounterOpen = true;
        continueButton.interactable = true;
    }

    private void TimerForContinue()
    {
        if (durationCounter <= 0)
        {
            isCounterOpen = false;
            continueButton.interactable = false;
            continueButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.grey;

            durationCounter = durationForContinue;
        }
        else
        {
            continueDurationText.text = durationCounter.ToString("f1");
            durationCounter -= Time.deltaTime;
        }
    }

    public void ContinueButton()
    {
        if (PlayerPrefs.GetFloat("Energy", 0) > continuePrice)
        {
            PlayerPrefs.SetFloat("Energy", PlayerPrefs.GetFloat("Energy", 0) - continuePrice);

            player.GetComponent<Player>().Respawn();

            durationCounter = durationForContinue;
            gameObject.SetActive(false);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(sceneId);
    }


    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
