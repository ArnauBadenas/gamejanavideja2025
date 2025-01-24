using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void FixedUpdate()
    {
        Move();
        Jump();
    }

    //It moves the player
    public void Move()
    {
        Vector3 movement = new Vector3(InputManager.instance.move.x * speed * Time.fixedDeltaTime,0,0);
        rb.MovePosition(rb.position + movement);
    }

    public void Jump()
    {
        if (InputManager.instance.jump.HOLD)
        {
            Vector3 movement = new Vector3(0,jumpForce * Time.fixedDeltaTime,0);
            rb.MovePosition(rb.position + movement);
        }
    }
}