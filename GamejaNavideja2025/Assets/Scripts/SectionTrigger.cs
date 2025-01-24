using System;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject conveyorSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ConveyorTrigger"))
        {
            //Quaternion.identity cause it spawns with no rotation :)
            Instantiate(conveyorSection, new Vector3(0,0,other.gameObject.transform.position.z+200), Quaternion.identity);
            
        }
        
    }
}
