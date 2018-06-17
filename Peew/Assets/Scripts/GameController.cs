using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject wave;
    public float maxX, minX, maxY, minY;
    public int amountOfEnemies;

    //UI
    public Text scoreText;
    public int score;

    // Use this for initialization
    void Start () {
        scoreText = GameObject.FindGameObjectWithTag("Score Text").GetComponent<Text>();
        score = 0;
        UpdateScore();
        SpawnWaves();
	}

    // Update is called once per frame
    void Update () {
		
	}

    //spawns waves of enemies
    void SpawnWaves()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            //Random position to spawn at
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(wave, spawnPosition, spawnRotation);
        }
    }

    // Add new score
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // Updates score text
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
