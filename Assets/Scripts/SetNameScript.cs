using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNameScript : MonoBehaviour
{
    [SerializeField] private InputField inputName;
    public void SetName()
    {
       
        PlayerPrefs.SetString("playerName", inputName.text);
        PlayerPrefs.Save();
        
    }
}
