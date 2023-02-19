using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    private float speed;
    private float yValue;

    public GameObject player;

    private void Start()
    {
        yValue = PlayerPrefs.GetFloat("SphereDistanceY") / -2;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 75)
        {
            speed = 66;
        }
        else
        {
            speed = 6;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case ("RedSphere"):
                other.GetComponentInParent<ParkourManager>().SetSpherePosition(other.gameObject);

                transform.position = transform.position + (Vector3.down * yValue);
                break;

            case ("GreenSphere"):
                other.GetComponentInParent<ParkourManager>().SetSpherePosition(other.gameObject);

                transform.position = transform.position + (Vector3.down * yValue);
                break;

            case ("WhitePlatform"):
                other.GetComponentInParent<ParkourManager>().SetPlatformPosition(other.gameObject);
                break;

            case ("BlackPlatform"):
                other.GetComponentInParent<ParkourManager>().SetPlatformPosition(other.gameObject);
                break;

            case ("Player"):
                other.GetComponent<Player>().Death();
                break;

            case ("Energy"):
                other.GetComponent<Energy>().SetPos();
                break;
        }
    }
}
