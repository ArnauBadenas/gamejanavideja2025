using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    private bool _isGrounded = true;
    

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
        rb.AddForce(movement, ForceMode.Impulse);
        
    }

    public void Jump()
    {
        
        if (InputManager.instance.jump.TAP && _isGrounded)
        {
            FindObjectOfType<AudioManager>().Play("Jump");
            Vector3 movement = new Vector3(0,jumpForce,0);
            rb.AddForce(movement, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        if(other.gameObject.CompareTag("Wall"))
        {
            SpeedManager.Instance.conveyorMovementSpeed = 50f;
            SceneManager.LoadScene("PlayAgainMenu");
        }
    }
    
    
}