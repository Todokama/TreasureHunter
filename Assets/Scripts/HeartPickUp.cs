using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    public int value;
    public ParticleSystem hearts;

    public AudioSource source;
    public AudioClip heart;


    

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddHeart(value);
            FindObjectOfType<HealthManager>().HealPlayer(value);
            source.PlayOneShot(heart);
            Instantiate(hearts, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }

   


}
