using System;
using UnityEngine;

public class ConveyorMovement : MonoBehaviour
{
    public float conveyorMovementSpeed;
    //public Rigidbody rb;
    public float speedIncreaseRate = 0.1f;

    private float timeSinceLastIncrease = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastIncrease += Time.deltaTime;
        if (timeSinceLastIncrease >= speedIncreaseRate)
        {
            conveyorMovementSpeed+= speedIncreaseRate;
            timeSinceLastIncrease = 0f;
        }
        transform.position += new Vector3(0,0,-conveyorMovementSpeed)*Time.deltaTime;
        //rb.AddForce(new Vector3(0,0,-conveyorMovementSpeed), ForceMode.Force);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
