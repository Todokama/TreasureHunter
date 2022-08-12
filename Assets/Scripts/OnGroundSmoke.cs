using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSmoke : MonoBehaviour
{
    public AudioClip clap;
    public AudioSource source;

    public GameObject Effect;
    public float activationTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            
            GameObject smoke = Instantiate(Effect,transform.position + new Vector3(-0.3f,0,0),transform.rotation);
            source.PlayOneShot(clap);
            StartCoroutine(DestroySmoke(smoke));
            
        }
    }
   IEnumerator DestroySmoke(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        DestroyImmediate(obj,true);
    }
}
