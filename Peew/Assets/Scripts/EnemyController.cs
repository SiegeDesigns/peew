using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Transform target;
    private Rigidbody2D rb;
    private BoxCollider2D bc2d;

    public Transform myTransform;
    public float speed;
    public float minDistance;
    public float accelerationTime = .5f;
    private Vector2 movement;
    private float timeLeft;

    float timer = 0.0f;
    int seconds;
    int amountOfTime = 0;
    bool changingState = false;
    public bool State { get; private set; } // true = green, false = red
    bool changing = false;
    public Animator animator { get; private set; }

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        amountOfTime = Random.Range(2, 10);
        if (this.name.Contains("Red"))
        {
            State = false;
        }
        else
        {
            State = true;
        }

        bc2d.isTrigger = true;

        myTransform = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer % 60;

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Spawning"))
        {
            bc2d.isTrigger = false;      
        }

        if (seconds == amountOfTime && !changing)
        {
            if (State) animator.SetInteger("State", 1);
            if (!State) animator.SetInteger("State", 3);
            changingState = true;
            changing = true;
            ResetTimers();
        }

        if (seconds == 2 && changingState)
        {
            if (State)
            {
                State = false;
                animator.SetInteger("State", 2);
            }
            else
            {
                amountOfTime = Random.Range(2, 10);
                State = true;
                animator.SetInteger("State", 0);
            }
            changingState = false;
            changing = false;
            ResetTimers();
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rb.velocity = rb.velocity * 0.5f;
            timeLeft += accelerationTime;
        }
    }

    void ResetTimers()
    {
        timer = 0;
        seconds = 0;
    }

    void FixedUpdate()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Spawning"))
        {


            Vector2 difference = target.transform.position - transform.position;
            Vector2 velocity = new Vector2();
            difference.Normalize();

            if (!State)
            {
                velocity = difference * speed;
                rb.velocity = new Vector2(velocity.x, velocity.y);
            }
            else
            {
                rb.AddForce(movement * 1.2f); //speed
            }
        }
    }
}