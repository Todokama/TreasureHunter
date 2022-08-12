using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timerPanel;


    [SerializeField]

   
    Text text; 

    private DateTime timer = new DateTime(1, 1, 1, 0, 10, 0); 

    private void Start()

    {

        StartCoroutine(Timerenumerator());

    }

    public void TimeReturn()
    {
        Time.timeScale = 1f;
    }

    private IEnumerator Timerenumerator() 

    {

        while (true)

        {

            text.text = timer.Minute.ToString() + ":" + timer.Second.ToString(); 

            timer = timer.AddSeconds(-1); 
            if(timer.Minute < 1)
            {
                text.color = Color.red;
            }
            if (timer.Second == 0 && timer.Minute == 0) 

            {

                Time.timeScale = 0f;
                timerPanel.SetActive(true);

                break; // завершаем корутину

            }

            yield return new WaitForSeconds(1); // ждем секунду

        }

    }
    public int TimePassed()
    {
        int x = 600 - timer.Minute*60 - timer.Second;
        return x;
    }
    public int TimeLeft()
    {
        int x = timer.Minute * 60 + timer.Second;
        return x;
    }

}
