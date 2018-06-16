﻿using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Transform target;
    private Rigidbody2D rb;
    public Transform myTransform;
    public float speed;
    public float minDistance;

    float timer = 0.0f;
    int seconds;
    int amountOfTime = 0;
    bool greenState = false;
    bool changingState = false;
    bool redState = false;
    bool changing = false;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        amountOfTime = Random.Range(2, 10);
        greenState = true;
        Debug.Log(amountOfTime);
        myTransform = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer % 60;


        if (seconds == amountOfTime && !changing && (greenState || redState))
        {
            Debug.Log("naar changing state");
            if(greenState) animator.SetInteger("State", 1);
            if(redState) animator.SetInteger("State", 3);
            changingState = true;
            changing = true;
            ResetTimers();
        }

        if (seconds == amountOfTime && changingState)
        {
            if (greenState)
            {
                Debug.Log("naar red state");
                greenState = false;
                redState = true;
                animator.SetInteger("State", 2);
            }
            else if (redState)
            {
                amountOfTime = Random.Range(2, 10);
                Debug.Log("naar green state");
                redState = false;
                greenState = true;
                animator.SetInteger("State", 0);
            }
            changingState = false;
            changing = false;
            ResetTimers();
        }
    }

    void ResetTimers()
    {
        timer = 0;
        seconds = 0;
    }

    void FixedUpdate()
    {
        Vector2 difference = target.transform.position - transform.position;
        Vector2 velocity = new Vector2();

        if (redState)
        {
            if (difference.x < minDistance || difference.y < minDistance)
            {
                velocity = difference * speed * 0.5f;
            }
            else
            {
                velocity = difference * speed * 1.5f;
            }
        } else if (greenState) {
            if(difference.x < minDistance || difference.y < minDistance)
            {
                velocity = -(difference * speed * 1.5f);
            } else
            {
                velocity = -(difference * speed * 0.5f);
            }
        }
        

        rb.velocity = new Vector2(velocity.x,velocity.y);
    }
}