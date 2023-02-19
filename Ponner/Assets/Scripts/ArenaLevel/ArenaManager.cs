using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public GameObject sphere;
    public int sphereAmount;

    private GameObject spawnedSphere;
    private float sphereX;
    private float sphereY;
    private float sphereZ;
    void Start()
    {
        SetSpherePositions();
    }

    private void SetSpherePositions()
    {
        for (int i = 0; i < sphereAmount; i++)
        {
            sphereX = Random.Range(0, 250);
            sphereY = Random.Range(0, 250);
            sphereZ = Random.Range(0, 250);

            spawnedSphere = Instantiate(sphere, new Vector3(sphereX, sphereY, sphereZ), Quaternion.identity);

            spawnedSphere.transform.SetParent(transform);
        }
    }

    public void TimerForArenaEnergy(GameObject arenaEnergy)
    {
        arenaEnergy.SetActive(false);

        StartCoroutine(StandbyForArenaEnergy(arenaEnergy));
    }

    IEnumerator StandbyForArenaEnergy(GameObject arenaEnergy)
    {
        yield return new WaitForSeconds(10);

        arenaEnergy.SetActive(true);
        arenaEnergy.GetComponent<ArenaEnergy>().SetEnergyPosition();
    }
}
