using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Inventory; // ссылка на панель с инвентарЄм
    [SerializeField]
    private UIObject[] objects; //массив элементов UI, отображающих предметы
    int prada = 0;

    private void Start()
    {
        Inventory.SetActive(false); // скрываем инвентарь
      
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // отслеживаем нажатие клавиши УIФ
        {
            Inventory.SetActive(!Inventory.activeSelf); // инвертируем состо€ние инвентар€

            // обновл€ем предметы в инвентаре, если инвентарь открытый
            if (Inventory.activeSelf)
            {
                UpdateUI();
            }
        }
         
        
    }
    public void CloseInventory()
    {
        Inventory.SetActive(!Inventory.activeSelf); // инвертируем состо€ние инвентар€

        // обновл€ем предметы в инвентаре, если инвентарь открытый
        if (Inventory.activeSelf)
        {
            UpdateUI();
        }
    } 
    // публичный метод дл€ добавлени€ объекта в инвентарь
    public void AddItem(GameObject objectInScene)
    {
        foreach (UIObject obj in objects) // обходим массив UI объектов
        {
            if (objectInScene.name.Equals(obj.name))
            // если им€ подобранного объекта совпадаем с именем одного из объектов в массиве
            {
                obj.State = true; // отмечаем объект в массиве как активный (подобранный)
                if (obj.name == "key")
                {
                    prada++;
                }
                break; // выходим из цикла, если нашли подход€щий объект
                
            }
        }
        // если после добавлени€ элемента инвентарь был открыт - обновл€ем его
        if (Inventory.activeSelf)
        {
           UpdateUI();
        }
        

    }

    private void UpdateUI() // метод обновлени€ инвентар€
    {
        foreach (UIObject obj in objects) // обходим массив объектов
        {
            obj.UpdateImage(); // обновл€ем каждый из объектов
        }
    }
}
