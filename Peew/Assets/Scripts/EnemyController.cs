using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform target;
    public Transform myTransform;

    float timer = 0.0f;
    int amountOfTime = 0;
    bool firstState = false;
    bool secondState = false;
    bool thirdState = false;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        amountOfTime = Random.Range(2, 10);
        firstState = true;
        Debug.Log(amountOfTime);
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {


        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);


        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        Debug.Log("SECONDS = " + seconds + "amountoftime = " + amountOfTime);

        //Debug.Log(amountOfTime);
        if (seconds == amountOfTime && firstState)
        {
            Debug.Log("State orange flickering for " + amountOfTime + "seconds");
            animator.SetInteger("State", 1);
            timer = 0;
            seconds = 0;
            firstState = false;
            secondState = true;

        }

        if (seconds == amountOfTime && secondState)
        {
            Debug.Log("State red for" + amountOfTime + "seconds");
            animator.SetInteger("State", 2);
            timer = 0;
            seconds = 0;
            secondState = false;
            thirdState = true;
        }

        if (seconds == amountOfTime && thirdState)
        {
            Debug.Log("State green for" + amountOfTime + "seconds");
            animator.SetInteger("State", 0);
            timer = 0;
            seconds = 0;
            amountOfTime = Random.Range(2, 10);
            thirdState = false;
            firstState = true;
        }
    }



}