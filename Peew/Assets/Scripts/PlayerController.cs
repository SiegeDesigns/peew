using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public float speed;
    public Boundary boundary;

    private Rigidbody2D rb;
    private float movement = 0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(move.x * speed, move.y * speed);

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rb.velocity = movement * speed;      
        //rb.position = new Vector2
        //(
        //    Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),            
        //    Mathf.Clamp(rb.position.y, boundary.zMin, boundary.zMax)
        //);
    }
}
