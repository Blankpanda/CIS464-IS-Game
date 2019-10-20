using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public GameObject virus;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    public void SpawnObject ()
    {
        Instantiate(virus, transform.position, transform.rotation);
        if(stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
	}
}
