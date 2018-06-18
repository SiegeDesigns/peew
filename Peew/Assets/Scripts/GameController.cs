using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject greenEnemy;
    public GameObject redEnemy;
    public float maxX, minX, maxY, minY;
    public int amountOfEnemies;

    //UI
    public Text scoreText;
    public int score;
    List<GameObject> enemies;

    // Use this for initialization
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score Text").GetComponent<Text>();
        score = 0;

        enemies = new List<GameObject> {
            greenEnemy, redEnemy
        };

        UpdateScore();
        SpawnWaves();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //spawns waves of enemies
    void SpawnWaves()
    {
        bool overlap = false;
        Vector3 spawnPosition = new Vector3();
        
        

        for (int i = 0; i < amountOfEnemies; i++)
        {

            spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
            overlap = Physics2D.OverlapCircle(spawnPosition, 1);
            while (overlap)
            {
                spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);
                overlap = Physics2D.OverlapCircle(spawnPosition, 0.5f);
            }
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);

            Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPosition, spawnRotation);

        }

        //spawn enemie instead of loading circle

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
