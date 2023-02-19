using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionButtons : MonoBehaviour
{
    public GameObject player;
    public float turnPower;

    private float turnPowerCounter;
    private float newPlayerRotationY;
    private bool enableTurn;
    private int _direction;

    private void Update()
    {
        if (enableTurn)
        {
            Turn();
        }
    }
    public void TurnButton(int direction)
    {
        _direction = direction;
        turnPowerCounter = turnPower;
        enableTurn = true;
    }

    public void StopTurn()
    {
        enableTurn = false;
    }

    private void Turn()
    {
        newPlayerRotationY += (_direction * turnPowerCounter * Time.deltaTime);

        if (turnPowerCounter <= (turnPower * 4))
        {
            turnPowerCounter += Time.deltaTime * 500;
        }

        player.transform.rotation = Quaternion.Euler(new Vector3(0, newPlayerRotationY, 0));
    }
}
