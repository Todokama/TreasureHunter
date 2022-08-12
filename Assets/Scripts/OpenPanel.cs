using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            panel.SetActive(false);
        }
    }
}
