using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public GameObject Virus;
    public GameObject InfectingVirus;
    public bool stopSpawning = false;

    public float spawnDelay;
    public float spawnMultiplier = 1;
    public int infectionSpawnDelay = 10;
    float currentTime;
    int spawnedCount = 0;
    void Start()
    {
        currentTime = spawnDelay;
    }

    void Update()
    {
        if(stopSpawning == false)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0) //reached the end of the timer
            {
                //spawn in virus
                spawnVirus();
                currentTime = spawnDelay;
                spawnedCount++;
                if (spawnedCount % infectionSpawnDelay == 0) //every 10 spawned viruses, spawn an infection 1
                {
                    spawnInfectionVirus();
                }
            }
        }
    }

    void spawnVirus()
    {
        Instantiate(Virus, transform.position, transform.rotation);
    }
    void spawnInfectionVirus()
    {
        Instantiate(InfectingVirus, transform.position, transform.rotation);
    }
}
