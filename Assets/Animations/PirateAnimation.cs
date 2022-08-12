using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateAnimation : MonoBehaviour
{
    CharacterController cc;
    Animator anim;
    public float speed = 1.5f;
    public float back_speed = 1.2f;
    public float runSpeed = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
       
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        anim.SetBool("hand", false);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float xx = Input.GetAxis("Mouse X");
        float yy = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))

        {
            anim.SetTrigger("user_anim");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jumping_stay", true);
            
        }


        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walk", true);
            Vector3 dir = transform.TransformDirection(new Vector3(x * speed * Time.deltaTime, 0f, z * speed * Time.deltaTime));
            cc.Move(dir);
        }
        else
        {
            anim.SetBool("walk", false);
        }

      
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk_back", true);
            Vector3 dir = transform.TransformDirection(new Vector3(x * back_speed * Time.deltaTime, 0f, z * back_speed * Time.deltaTime));
            cc.Move(dir);
        }
        else
        {
            anim.SetBool("walk_back", false);
        }

       

        if (x != 0 && z == 0 && Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 5f, 0);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) )
        {
            transform.Rotate(0, 1f, 0);
            anim.SetBool("walk_right", true);
        }
        else
        {
            anim.SetBool("walk_right", false);
        }
            


        if (x != 0 && z == 0 && Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -5f, 0);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1f, 0);
            anim.SetBool("walk_left", true);
        }
        else
        {
            anim.SetBool("walk_left", false);
        }






        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("walk_left", false);
            anim.SetBool("walk_right", false);
            anim.SetBool("run", true);
            if(x == 0 && z != 0)
            {
                Vector3 dir = transform.TransformDirection(new Vector3(x * runSpeed * Time.deltaTime, 0f, z * runSpeed * Time.deltaTime));
                cc.Move(dir);
            }
            if (x != 0 && z != 0)
            {
                Vector3 dir = transform.TransformDirection(new Vector3(x * speed * Time.deltaTime, 0f, z * speed * Time.deltaTime));
                cc.Move(dir);
            }


        }
        else
        {
            anim.SetBool("run", false);
        }



        

   
    }
}
