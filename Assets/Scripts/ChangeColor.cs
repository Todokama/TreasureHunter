using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Material[] material;
    public Text text;
    Renderer rend;
    public GameObject levelPanel;
    public GameManager currentGold;
    public Text goldText;
    Timer timer;
    private string playerName;
    public static ChangeColor instance;
    float gold = 0;
    float hightScore;

   

    void Start()
    {
        playerName = PlayerPrefs.GetString("playerName");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        goldText.GetComponent<Text>();
        timer = FindObjectOfType<Timer>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(rend.sharedMaterial == material[0])
            {
                text.gameObject.SetActive(true);
               

            }
            else
            {

                gold = Mathf.Round(currentGold.currentGold * 10 / 49);
                Time.timeScale = 0f;

                if (gold < 50000)
                {
                    goldText.color = new Color32(255, 83, 74, 255);
                }
                if (gold >= 50000 && gold < 100000)
                {
                    goldText.color = new Color(255, 220, 0, 255);
                }
                if (gold >= 100000)
                {
                    goldText.color = new Color(126, 163, 16, 255);
                }
                
                float score = Mathf.Pow(currentGold.currentGold, 1 + timer.TimeLeft() / timer.TimePassed());
                
                goldText.text = (int)score + "";
                HightScoreTable.AddHighscoreEntry((int)score, playerName);
                levelPanel.SetActive(true);
            }
            
        }
    }
    public void ColorChange()
    {
        rend.sharedMaterial = material[1];
    }


    

    public void ResetScore()
    {
        hightScore = 0;
    }
}
