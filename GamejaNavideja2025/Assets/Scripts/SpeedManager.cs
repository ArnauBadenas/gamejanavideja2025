using System;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance { get; private set; } 
    
    public float conveyorMovementSpeed;
    public float speedIncreaseRate = 0.1f;
    private float _timeSinceLastIncrease = 0f;
    private float UpdateSpeed()
    {
        _timeSinceLastIncrease += Time.deltaTime;
        if (_timeSinceLastIncrease >= speedIncreaseRate)
        {
            _timeSinceLastIncrease = 0f;
            conveyorMovementSpeed+=speedIncreaseRate;
        }
        return conveyorMovementSpeed;
    }

    private void Update()
    {
        if (conveyorMovementSpeed <= 100)
        {
            UpdateSpeed();
        }
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);  
        }
    }
}
