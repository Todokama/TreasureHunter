using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public Animator [] animators;
    public GameObject gems;
    public GameObject [] points;
    public GameObject panel;
    public GameManager currentGold;
    private string playerName;
    Timer timer;
    float gold = 0;
    float hightScore;
    public Text goldText;




    void Start()
    {
        playerName = PlayerPrefs.GetString("playerName");
        goldText.GetComponent<Text>();
        timer = FindObjectOfType<Timer>();
    }



        private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("isOpen", true);
            }
           
            foreach (GameObject point in points)
            {
                Instantiate(gems, point.transform.position, point.transform.rotation);
            }

            StartCoroutine(WinEnd());
            
        }
    }


    private IEnumerator WinEnd()

    {
        yield return new WaitForSeconds(3);
        gold = Mathf.Round(currentGold.currentGold * 10 / 100);
        Time.timeScale = 0f;

        if (gold < 50)
        {
            goldText.color = new Color32(255, 83, 74, 255);
        }
        if (gold >= 50 && gold < 80)
        {
            goldText.color = new Color(255, 220, 0, 255);
        }
        if (gold > 80)
        {
            goldText.color = new Color(126, 163, 16, 255);
        }

        float score = Mathf.Pow(currentGold.currentGold, 1 + timer.TimeLeft() / timer.TimePassed());
        
        goldText.text = (int)score + "";
        HighSecondTable.AddHighscoreEntry((int)score, playerName);
        panel.SetActive(true);

    }

    



    public void HightScore()
    {
        if (gold > hightScore)
        {
            hightScore = gold;

            PlayerPrefs.SetFloat("SaveScore2", hightScore);
        }
    }
}
