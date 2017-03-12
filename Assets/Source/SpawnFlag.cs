using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlag : MonoBehaviour {

    public GameObject FlagPrefab;

    private GameManager gameManager;
    private Transform[] spawnPoints;
    private Vector3 lastSpawnPos;

	// Use this for initialization
	void Start ()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();
	}
	
    public void SpawnNextFlag()
    {
        GameObject newFlag = Instantiate(FlagPrefab, GetNextSpawnLocation(), Quaternion.identity);
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
