using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    private bool isGrounded = true;
    

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
        Vector3 movement = new Vector3(InputManager.instance.move.x * speed,0,0);
        rb.AddForce(movement, ForceMode.Force);
        
    }

    public void Jump()
    {
        
        if (InputManager.instance.jump.TAP && isGrounded)
        {
            Vector3 movement = new Vector3(0,jumpForce,0);
            rb.AddForce(movement, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    
}