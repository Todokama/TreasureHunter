using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObject : MonoBehaviour
{
    public GameObject objectInScene; // соответствующий объект на сцене
    [SerializeField]
    private Image imagePlace; // место для картинки
    [SerializeField]
   private Sprite image; // картинка
    [SerializeField]
    
    
   

    public bool State { get; set; } // автоматич свойство состояние подобран/не подобран объект

    

    public void UpdateImage() // обновить картинку в зависимости от состояния
    {
        if (State) // если объект активен (подобран)
        {
            imagePlace.sprite = image; // отобразить картинку
             // сделать обводку зеленой
        }
        else // если объект еще не подобран
        {
            imagePlace.sprite =null; // не отображать картинку
        
        }
    }
}
