using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public GameObject wheel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wheel.transform.Rotate(new Vector3(10,0,0));
    }
}
