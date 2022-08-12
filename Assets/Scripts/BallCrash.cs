using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCrash : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crucher")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(2, new Vector3(0,0,0));
        }
    }
}
