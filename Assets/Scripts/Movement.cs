using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController controller;
    public Animator animator;


    public ParticleSystem Effect;
    public float activationTime;


    public EnergyBar energyBar;
    int maxEnergy = 10000;
    public int currentEnergy;
    bool canRun = true;

    
    
    public Transform Cam;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool canDoubleJump = false;

    private AudioSource source;
    public AudioClip run;

    public float knockbackForce;
    public float knockbackTime;
    private float knockbackCounter;


    private Vector3 moveDirection;
    public float playerSpeed = 1.5f;
    public float jumpSpeed = 0.5f;
    public float gravityValue = -10f;
    float turnSmoothness;
    public float turnSmoothing = 0.1f;

    
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("talk");
        }
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            
            playerVelocity.y = 0f;
        }

        float h = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, z);

        

        if ((move.magnitude >= 0.1f))
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothness, turnSmoothing);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * playerSpeed * Time.deltaTime);
        }

        animator.SetFloat("speed", move.magnitude);

        if (playerSpeed == 6f && groundedPlayer)
        {
            source.clip = run;
            AudioPlay(move.magnitude);
            
        }
        else
        {
            source.Stop();
        }


        if (knockbackCounter <= 0)
        {
            if (groundedPlayer)
            {
                canDoubleJump = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerVelocity.y += Mathf.Sqrt(jumpSpeed * -2.0f * gravityValue);

                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
                {

                    playerVelocity.y += Mathf.Sqrt(jumpSpeed * 0.8f * -2.0f * gravityValue);
                    animator.SetTrigger("double");
                    canDoubleJump = false;
                    
                }
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
        }



        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (groundedPlayer && playerVelocity.y < 0)
        {
            animator.SetBool("fall", false);
            
        }
        else
        {
            if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("fall", true);

            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && move.magnitude > 0.1f)
        {
            
            {
                playerSpeed = 6f;
                animator.SetBool("run", true);
                TakeEnergy(3);
               
                
            }
        }
        else
        {
            playerSpeed = 2f;
            animator.SetBool("run", false);
            GiveEnergy(10);

        }


       

        if (Input.GetMouseButtonDown(0) && !isPlaying(animator, "spin")){
         
            animator.SetTrigger("attack");
            Invoke("Activate", activationTime);
        }

        if (currentEnergy < 50)
        {
            canRun = false;

        }
        if (currentEnergy > 400)
        {
            canRun = true;
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

    void Activate()
    {
        Effect.Play();
    }
        
    private void AudioPlay(float v)
    {
        if (v != 0 && !source.isPlaying) source.Play();
        else if (v == 0 && source.isPlaying) source.Stop();
    }


    public bool TakeEnergy(int energy)
    {
        if (currentEnergy > energy)
        {
            currentEnergy -= energy;

            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
            }

            energyBar.SetEnergy(currentEnergy);

            return true;
        }
        else
            return false;

    }

    public void GiveEnergy(int energy)
    {
        currentEnergy += energy;
        if (currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;
        }


        energyBar.SetEnergy(currentEnergy);
    }

    public void ResetEnergy()
    {
        maxEnergy = 3000;
        currentEnergy = maxEnergy;
        energyBar.SetEnergy(currentEnergy);
        energyBar.SetMaxEnergy(maxEnergy);
    }

    /*public void Knockback(Vector3 direction)
    {
        knockbackCounter = knockbackTime;
        direction = new Vector3(10f, 10f, 10f);
        
        moveDirection = direction * knockbackForce;
        
    }*/

    /*  private void OnControllerColliderHit(ControllerColliderHit hit)
      {
          if(hit.normal.y < 0.1f)
          {
              if (Input.GetKey(KeyCode.Space))
              {
                  playerVelocity.y = Mathf.Sqrt(jumpSpeed * 0.8f * -2.0f * gravityValue);
                  moveDirection = hit.normal * 15f;
                  transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime);
                  controller.Move(moveDirection * playerSpeed * Time.deltaTime);

              }
          }
      }*/


    /* private void OnTriggerStay(Collider other)
     {
         if (other.CompareTag("Boat"))
         {

                 MainManager.Messenger.WriteMessage("Нажмите F, чтобы покинуть остров!");
                 if (Input.GetKeyDown(KeyCode.F))
                 {
                     MainManager.sceneChanger.OpenNewScene(2);
                 }


         }
     }*/



}
