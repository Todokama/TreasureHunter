using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
     void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            
        }
    }
     void OnTriggerExit(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
