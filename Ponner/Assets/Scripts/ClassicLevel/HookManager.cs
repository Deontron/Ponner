using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManager : MonoBehaviour
{
    public GameObject player;

    public LayerMask holdable;

    public GameObject leftArm;
    public GameObject rightArm;

    private GameObject usedArm;
    private LineRenderer lineRenderer;
    private bool extendEnabled;
    private bool isHolding;

    private float touchPoint;

    private Ray ray;
    private RaycastHit hit;
    public float distance = 26;
    public float spring = 2;
    public float damper = 20;

    private Vector3 grabbedObject;
    private SpringJoint joint;

    //For arena level
    public SphereCounter sphereCounter;
    [HideInInspector]
    public GameObject grabbedSphere;

    void Update()
    {
        Grap();
    }

    private void Grap()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        touchPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;

        if (Physics.Raycast(ray, out hit, distance, holdable))
        {
            if (Input.GetMouseButtonDown(0))
            {
                grabbedObject = hit.point;

                if (hit.transform.CompareTag("ArenaSphere")) //for arena level
                {
                    grabbedSphere = hit.transform.gameObject; 
                }

                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grabbedObject;

                float distanceFromPoint = Vector3.Distance(transform.position, grabbedObject);

                joint.maxDistance = distanceFromPoint * 0.2f;
                joint.minDistance = distanceFromPoint * 0.1f;

                joint.spring = spring;
                joint.damper = damper;

                if (touchPoint > 0.5f)
                {
                    ChooseArm(rightArm);
                }
                else
                {
                    ChooseArm(leftArm);
                }
                isHolding = true;

                usedArm.gameObject.GetComponent<ArmMovement>().SetTarget(grabbedObject, isHolding);

                extendEnabled = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(joint);
            extendEnabled = false;
            isHolding = false;

            if (grabbedSphere != null) //for arena level
            {
                sphereCounter.CountSpheres(grabbedSphere);
                grabbedSphere = null;
            }

            if (usedArm != null)
                usedArm.gameObject.GetComponent<ArmMovement>().SetTarget(grabbedObject, isHolding);

            if (lineRenderer != null)
                lineRenderer.positionCount = 0;
        }

        if (extendEnabled)
        {
            ExtendArm();
        }
    }

    private void ChooseArm(GameObject _usedArm)
    {
        if (!isHolding)
        {
            usedArm = _usedArm;
            lineRenderer = usedArm.GetComponent<LineRenderer>();
        }
    }

    private void ExtendArm()
    {
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, usedArm.transform.position);
        lineRenderer.SetPosition(1, grabbedObject);
    }


}
