using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SectionTrigger : MonoBehaviour
{
    public GameObject[] conveyorSection;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("ConveyorTrigger"))
        {
            //Quaternion.identity cause it spawns with no rotation :)
            Instantiate(conveyorSection[Random.Range(0,conveyorSection.Length-1)], new Vector3(0,0,other.gameObject.transform.position.z+545), Quaternion.identity);
            
        }
        
    }
}
