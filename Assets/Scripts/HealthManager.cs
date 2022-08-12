using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealt;
    public GameManager hearts;

    public Movement thePlayer;

    public float invincibilityLenght;
    private float invicibilityCounter;

    public Renderer[] playerRenderer;
    private float flashCounter;
    public float flashLenght = 0.1f;

    public bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLenght;

    public AudioSource source;
    public AudioClip death;

    public Text heartText;

    public GameObject deathEffect;
    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public float fadeSpeed;
    public float waitForFade;

    // Start is called before the first frame update
    void Start()
    {
        currentHealt = hearts.currentHeart;

        // thePlayer = FindObjectOfType<Movement>();

        respawnPoint = thePlayer.transform.position;



    }

    void Update()
    {

      
        if (invicibilityCounter > 0)
        {
            invicibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;



            if (flashCounter <= 0)
            {
                foreach (Renderer obj in playerRenderer) // обходим массив UI объектов
                {
                    obj.enabled = !obj.enabled;
                    flashCounter = flashLenght;
                }
            }

            if (invicibilityCounter <= 0)
            {
                foreach (Renderer obj in playerRenderer) // обходим массив UI объектов
                {
                    obj.enabled = true;
                }
            }
        }

        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }

        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }



    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invicibilityCounter <= 0)
        {
            currentHealt -= damage;
            FindObjectOfType<GameManager>().RemoveHeart(damage);

            if (currentHealt <= 0)
            {
                Respawn();
            }
            else
            {
                //thePlayer.Knockback(direction);
                invicibilityCounter = invincibilityLenght;

                foreach (Renderer obj in playerRenderer)
                {

                    obj.enabled = false;
                    flashCounter = flashLenght;
                }
            }
        }

        
    }

    public void Respawn()
    {
       
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }


    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        source.PlayOneShot(death);
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);


        yield return new WaitForSeconds(respawnLenght);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeToBlack = false;
        isFadeFromBlack = true;

        isRespawning = false;

        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = respawnPoint + new Vector3(1f,0,0);
        currentHealt = 3;
        hearts.currentHeart = currentHealt;
        heartText.text = "X " + currentHealt;
        invicibilityCounter = invincibilityLenght;

        foreach (Renderer obj in playerRenderer)
        {

            obj.enabled = false;
            flashCounter = flashLenght;
        }


    }

    public void HealPlayer(int heartValue)
    {
        currentHealt += heartValue;
       /* if(currentHealt > maxHealth)
        {
            currentHealt = maxHealth;   
        }*/
    }

    public void SetSpawnPoints(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
