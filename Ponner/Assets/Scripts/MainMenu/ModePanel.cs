using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModePanel : MonoBehaviour
{
    public int sceneId;

    public GameObject previousScreen;
    public GameObject nextScreen;
    public void ClassicLevelButton()
    {
        nextScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ArenaLevelButton()
    {
        PlayerPrefs.SetFloat("SphereDistanceZ", 44);
        PlayerPrefs.SetFloat("SphereDistanceY", -8);
        PlayerPrefs.SetFloat("ScoreDivider", 2);
        PlayerPrefs.SetFloat("EffectorPower", 25);

        SceneManager.LoadScene(sceneId);
    }
    

    public void BackButton()
    {
        previousScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
