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

        enemyController = gameObject.GetComponent<EnemyController>();
        state = enemyController.State;

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
        // Player hit a red enemy, gets destroyed
        state = enemyController.State;
        if (coll.gameObject.tag == "Player" && !state)
        {
            Destroy(coll.gameObject);
        }

        // Player hit a green enemy, earns points
        if (coll.gameObject.tag == "Player" && state)
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
