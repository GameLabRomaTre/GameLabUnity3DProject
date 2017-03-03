using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlag : MonoBehaviour {

    public GameObject flagPrefab;

    Transform[] spawnPoints;

    Vector3 lastSpawnPos;

	// Use this for initialization
	void Start ()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
	}
	
    public Vector3 GetNextSpawnLocation()
    {
        Vector3 candidateSpawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

        if (candidateSpawnPos != lastSpawnPos)
        {
            lastSpawnPos = candidateSpawnPos;
            return candidateSpawnPos;
        }

        else return GetNextSpawnLocation();
    }
}
