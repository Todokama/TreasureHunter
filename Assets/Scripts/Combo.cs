using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    Animator charAnimator;
  
   

    void Start()
    {
        charAnimator = GetComponent<Animator>();
    }

   
    

  
    void Attack()
    {
        int attackMode = Random.Range(1, 3);
        charAnimator.SetTrigger("attack" + attackMode);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }
}
