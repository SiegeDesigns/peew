using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject wave;
    public float maxX, minX, maxY, minY;
    public int amountOfEnemies;

	// Use this for initialization
	void Start () {
        SpawnWaves();
	}

    void SpawnWaves()
    {
        for(int i = 0; i < amountOfEnemies; i++)
        {
            //Random position to spawn at
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(wave, spawnPosition, spawnRotation);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
