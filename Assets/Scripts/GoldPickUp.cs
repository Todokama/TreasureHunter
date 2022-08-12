using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
        
    public int value;

    public AudioSource source;
    public AudioClip coin;

    public GameObject pickupEffect;
 
    void Start()
    {
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddGold(value);
            source.PlayOneShot(coin);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
