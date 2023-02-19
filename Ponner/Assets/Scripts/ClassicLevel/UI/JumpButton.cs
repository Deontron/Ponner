using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    public Player playerScript;

    private Button button;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
    }
    private void Update()
    {
        if (playerScript.checkGround || playerScript.doubleJump)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
