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
        Debug.Log("Screen width: " + Screen.width);
        Debug.Log("Screen height: " + Screen.height);
        List<Vector3> enemyList = new List<Vector3>();
        Vector3 spawnPosition = new Vector3();
        bool overlap;

        for (int i = 0; i < amountOfEnemies; i++)
        {
            //Random position to spawn at
            //if(enemyList.Count == 0) spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
            //else
            //{
            //    spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
            //    overlap = Physics2D.OverlapCircle(spawnPosition, 0.1f);

            //    while (overlap)
            //    {
            //        spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
            //        overlap = Physics2D.OverlapArea(enemyList[i], spawnPosition);
            //    }
            //}
            spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
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
