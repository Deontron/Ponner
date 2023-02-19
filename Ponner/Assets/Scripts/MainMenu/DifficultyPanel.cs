using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyPanel : MonoBehaviour
{
    public int sceneId;

    public GameObject previousScreen;
    public void EasyButton()
    {
        PlayerPrefs.SetFloat("SphereDistanceZ", 34);
        PlayerPrefs.SetFloat("SphereDistanceY", -6);
        PlayerPrefs.SetFloat("ScoreDivider", 4);
        PlayerPrefs.SetFloat("EffectorPower", 20);

        LoadScene();
    }
    public void MediumButton()
    {
        PlayerPrefs.SetFloat("SphereDistanceZ", 44);
        PlayerPrefs.SetFloat("SphereDistanceY", -8);
        PlayerPrefs.SetFloat("ScoreDivider", 2);
        PlayerPrefs.SetFloat("EffectorPower", 25);

        LoadScene();
    }
    public void HardButton()
    {
        PlayerPrefs.SetFloat("SphereDistanceZ", 54);
        PlayerPrefs.SetFloat("SphereDistanceY", -10);
        PlayerPrefs.SetFloat("ScoreDivider", 1);
        PlayerPrefs.SetFloat("EffectorPower", 30);

        LoadScene();
    }

    public void BackButton()
    {
        previousScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneId);
    }
}
