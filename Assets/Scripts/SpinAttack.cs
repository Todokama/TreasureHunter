using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAttack : MonoBehaviour
{

    public Animator anim;
    public AudioClip punch;
    public AudioSource source;

     
    void OnTriggerEnter(Collider col)
    {
        
           
        if (col.CompareTag("Enemy") &&  isPlaying(anim, "spin"))
        {
            source.PlayOneShot(punch);
            DamageEnemy(col.transform);
        }
        
    }

    void DamageEnemy(Transform enemy)
    {
        EnemyHealth e = enemy.GetComponent<EnemyHealth>();

        if (e != null)
        {
            e.HurtEnemy(1);
        }
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
        anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
            return true;
        else
            return false;
    }
}
