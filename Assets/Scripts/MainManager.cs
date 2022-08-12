using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour

{
    private static InventoryManager inventory;
    private static Messenger messenger;
    public static SceneChange sceneChanger;
    public static GameManager1 game;
    

   
    

    public static Messenger Messenger
    {

        get
        {
            if (messenger == null) // инициализация по запросу
            {
                messenger = FindObjectOfType<Messenger>();
            }
            return messenger;
        }
        private set
        {
            messenger = value;
        }
    }
    private void OnEnable()

    {
        game = GetComponent<GameManager1>();
        DontDestroyOnLoad(gameObject);
        sceneChanger = GetComponent<SceneChange>();
    }
    

}
