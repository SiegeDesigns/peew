using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    private GameController gameController;
    private EnemyController enemyController;
    public int scoreValue;
    private bool state; // true = green, false = red

    void Start()
    {
        GameObject enemyObject = GameObject.FindGameObjectWithTag("EnemyController");
        if(enemyObject != null)
        {
            enemyController = gameObject.GetComponent<EnemyController>();
            state = enemyController.State;
        }
        if(enemyObject == null)
        {
            Debug.Log("Cannot find 'EnemyController' script");
        }

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        state = enemyController.State;
        if (coll.gameObject.tag == "Player" && !state)
            Debug.Log(state ? "groen" : "rood");
            Destroy(coll.gameObject);
        if (coll.gameObject.tag == "Player" && state)
        {
            Debug.Log(state ? "groen" : "rood");
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
