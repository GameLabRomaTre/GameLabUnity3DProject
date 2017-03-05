using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlag : MonoBehaviour {

    public GameObject flagPrefab;

    GameManager gameManager;

    Transform[] spawnPoints;

    Vector3 lastSpawnPos;

	// Use this for initialization
	void Start ()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();
	}
	
    public void SpawnNextFlag()
    {
        GameObject newFlag = Instantiate(flagPrefab, GetNextSpawnLocation(), Quaternion.identity);
        newFlag.GetComponent<FlagTrigger>().gameManager = gameManager;        

    }

    private Vector3 GetNextSpawnLocation()
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
