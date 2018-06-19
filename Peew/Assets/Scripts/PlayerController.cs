using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;

    private Rigidbody2D rb;
    private Transform tf;

    //Joystick controls
    private Joystick joystick;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        //Vector2 move = Vector2.zero;

        //move.x = Input.GetAxis("Horizontal");
        //move.y = Input.GetAxis("Vertical");

        //Vector3 pos = Camera.main.WorldToViewportPoint(tf.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        //if (pos.x > 0 || pos.x < 1 || pos.y > 0 || pos.y < 0)
        //    rb.velocity = new Vector2(move.x * speed, move.y * speed);

        rb.velocity = new Vector2(joystick.Horizontal * speed,
                                  joystick.Vertical * speed);
    }
}
