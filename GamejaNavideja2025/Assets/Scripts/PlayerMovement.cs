using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public void Start()
    {
    }

    public void Update()
    {
        Move();
        Jump();
    }

    //It moves the player
    public void Move()
    {
        transform.position += new Vector3(InputManager.instance.move.x * speed * Time.deltaTime, 0,
            InputManager.instance.move.y * speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (InputManager.instance.jump.HOLD)
        {
            transform.position += new Vector3(0, jumpForce * Time.deltaTime, 0);
        }
        
    }
}