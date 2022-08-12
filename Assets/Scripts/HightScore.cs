using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScore : MonoBehaviour
{
    public Text hightScore;
    public Text hightScore2;
    private void Update()
    {
        hightScore.text = PlayerPrefs.GetFloat("SaveScore") + "%";
        hightScore2.text = PlayerPrefs.GetFloat("SaveScore2") + "%";
    }
    
}
