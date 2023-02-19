using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject nextScreen;
    public GameObject previousScreen;
    public void StartButton()
    {
        nextScreen.SetActive(true);
        previousScreen.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
