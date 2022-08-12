using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelPanel : MonoBehaviour
{
    public GameManager currentGold;
    public Text goldText;

    void Start()
    {
        currentGold = GetComponent<GameManager>();
    }

    public void MessageCount()
    {
        goldText.text = "Уровень пройден на" + Mathf.Round(currentGold.currentGold / 40 * 100);
    }
}
