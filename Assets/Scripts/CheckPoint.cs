using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{

    public Text text;
    bool isActive=true;
    public HealthManager theHealthManager;
    public Animator anim;
    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        theHealthManager = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        
    }
    
    public void CheckPointOn()
    {
        CheckPoint[] checkPoints = FindObjectsOfType<CheckPoint>();
        foreach (CheckPoint cp in checkPoints)
        {
            cp.CheckPointOff();
        }
        source.PlayOneShot(clip);
        text.gameObject.SetActive(true);
        anim.SetBool("pointOn", true);
    }

    public void CheckPointOff()
    {
        anim.SetBool("pointOn", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player") && isActive)
        {
            theHealthManager.SetSpawnPoints(transform.position);
            CheckPointOn();
            isActive = false;
        }
    }

}
