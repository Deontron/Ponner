using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaJumpButton : MonoBehaviour
{
    public float jumpCost = 10;
    public Slider slider;
    public Player player;

    private Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
    }

    void Update()
    {
        IncreaseJumpSlider();
    }

    private void IncreaseJumpSlider()
    {
        if (slider.value < 1)
        {
            slider.value += Time.deltaTime / 50;
        }
    }

    public void BattleJump()
    {
        if (slider.value >= jumpCost / 100)
        {
            slider.value -= jumpCost / 100;

            player.BattleJump();
        }
    }
}
