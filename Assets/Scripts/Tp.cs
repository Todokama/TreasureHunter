using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public Transform tp;
    public GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            StartCoroutine("Teleport");

        }
    }

    public IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);

        player.transform.position = tp.transform.position + new Vector3(3,0,0);

    }
}
