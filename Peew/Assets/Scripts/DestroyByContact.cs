using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public int scoreValue;

    private GameController gameController;
    private EnemyController enemyController;
    private bool state; // true = green, false = red
    private bool playerInEnemy = false;
    private Animator animator;
    void Start()
    {

        enemyController = gameObject.GetComponent<EnemyController>();
        state = enemyController.State;
        animator = enemyController.animator;

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

    void Update()
    {
        if (playerInEnemy && state && !animator.GetCurrentAnimatorStateInfo(0).IsName("Spawning"))
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Player hit a red enemy, gets destroyed
        state = enemyController.State;
     
        if (coll.gameObject.tag == "Player" && !state && !animator.GetCurrentAnimatorStateInfo(0).IsName("Spawning"))
        {
            Destroy(coll.gameObject);
        }

        // Player hit a green enemy, earns points
        if (coll.gameObject.tag == "Player" && state && !animator.GetCurrentAnimatorStateInfo(0).IsName("Spawning"))
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");   
        playerInEnemy = true; 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerInEnemy = false;
    }
}
