using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourManager : MonoBehaviour
{
    public GameObject[] spheres;

    public Material greenMat;
    public Material redMat;

    private int theCounter = 0;

    private float sphereX;
    private float sphereDistanceZ;
    private float sphereDistanceY;
    private float sphereColorRate = 80;

    private GameObject currentSphere;

    private bool secondSphereControl = true;

    private Vector3 platformPos;

    void Start()
    {
        sphereDistanceZ = PlayerPrefs.GetFloat("SphereDistanceZ", 44);
        sphereDistanceY = PlayerPrefs.GetFloat("SphereDistanceY", -6);

        SetSpheresStartPosition();
    }

    private void SetSpheresStartPosition()
    {
        for (int i = 0; i < spheres.Length; i += 2)
        {
            float randomNumber = Random.Range(0, 100);

            if (randomNumber > 50)
            {
                sphereX = 7;
            }
            else
            {
                sphereX = -7;
            }

            spheres[i].transform.position = new Vector3(sphereX, sphereDistanceY * i / 2, sphereDistanceZ * i / 2);
            spheres[i].SetActive(true);

            spheres[i + 1].transform.position = new Vector3(-sphereX, (sphereDistanceY * i / 2) - 15, sphereDistanceZ * i / 2);
            spheres[i + 1].SetActive(true);

            currentSphere = spheres[i + 1];
            theCounter = i / 2;
        }
    }

    public void SetSpherePosition(GameObject sphere)
    {
        currentSphere = sphere;
        if (secondSphereControl)
        {
            theCounter++;

            float randomNumber = Random.Range(3, 11);

            if (Random.Range(0, 100) >= 50)
            {
                sphereX = randomNumber;
            }
            else
            {
                sphereX = -randomNumber;
            }


            sphere.transform.position = new Vector3(sphereX, sphereDistanceY * theCounter, sphereDistanceZ * theCounter);

            secondSphereControl = false;
        }
        else
        {
            sphere.transform.position = new Vector3(-sphereX, (sphereDistanceY * theCounter) - 15, sphereDistanceZ * theCounter);

            secondSphereControl = true;
        }

        SetSphereColor(sphere);

    }

    private void SetSphereColor(GameObject sphere)
    {
        float randomNum = Random.Range(0, 100);

        if (PlayerPrefs.GetFloat("LastScore", 0) % 50 <= 0 && sphereColorRate > 50)
        {
            sphereColorRate -= 3;
        }

        if (randomNum < sphereColorRate)
        {
            sphere.GetComponent<MeshRenderer>().material = greenMat;
            sphere.layer = 6;
        }
        else
        {
            sphere.GetComponent<MeshRenderer>().material = redMat;
            sphere.layer = 1;
        }
    }

    public void SetPlatformPosition(GameObject platform)
    {
        float _counter = Random.Range(3, 26);
        StartCoroutine(TimerForPlatform(platform, _counter));
    }

    IEnumerator TimerForPlatform(GameObject platform, float _counter)
    {
        yield return new WaitForSeconds(_counter);

        platformPos = new Vector3(0, platform.GetComponent<PlatformPositionY>().SetYPosition(currentSphere), currentSphere.transform.position.z);

        platform.transform.position = platformPos;
    }

    public void SetEnergyPosition(GameObject energy)
    {
        float timer = Random.Range(0, 10);
        StartCoroutine(TimerForEnergy(energy, timer));
    }

    IEnumerator TimerForEnergy(GameObject energy, float timer)
    {
        yield return new WaitForSeconds(timer);

        float randomNumber = Random.Range(0, 16);

        energy.transform.position = new Vector3(0, currentSphere.transform.position.y + randomNumber, currentSphere.transform.position.z);
    }
}