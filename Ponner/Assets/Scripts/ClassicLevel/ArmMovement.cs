using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public GameObject firstRotation;

    private Quaternion desiredRotation;
    private Vector3 target;
    private bool isHolding;

    void Update()
    {
        Movement();
    }

    public void SetTarget(Vector3 grabPoint, bool holding)
    {
        target = grabPoint;
        isHolding = holding;
    }

    private void Movement()
    {
        if (isHolding)
        {
            desiredRotation = Quaternion.LookRotation(target - transform.position);
        }
        else
        {
            desiredRotation = firstRotation.transform.rotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 15 * Time.deltaTime);
    }
}
