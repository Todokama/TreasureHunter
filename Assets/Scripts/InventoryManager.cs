using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Inventory; // ������ �� ������ � ���������
    [SerializeField]
    private UIObject[] objects; //������ ��������� UI, ������������ ��������
    int prada = 0;

    private void Start()
    {
        Inventory.SetActive(false); // �������� ���������
      
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // ����������� ������� ������� �I�
        {
            Inventory.SetActive(!Inventory.activeSelf); // ����������� ��������� ���������

            // ��������� �������� � ���������, ���� ��������� ��������
            if (Inventory.activeSelf)
            {
                UpdateUI();
            }
        }
         
        
    }
    public void CloseInventory()
    {
        Inventory.SetActive(!Inventory.activeSelf); // ����������� ��������� ���������

        // ��������� �������� � ���������, ���� ��������� ��������
        if (Inventory.activeSelf)
        {
            UpdateUI();
        }
    } 
    // ��������� ����� ��� ���������� ������� � ���������
    public void AddItem(GameObject objectInScene)
    {
        foreach (UIObject obj in objects) // ������� ������ UI ��������
        {
            if (objectInScene.name.Equals(obj.name))
            // ���� ��� ������������ ������� ��������� � ������ ������ �� �������� � �������
            {
                obj.State = true; // �������� ������ � ������� ��� �������� (�����������)
                if (obj.name == "key")
                {
                    prada++;
                }
                break; // ������� �� �����, ���� ����� ���������� ������
                
            }
        }
        // ���� ����� ���������� �������� ��������� ��� ������ - ��������� ���
        if (Inventory.activeSelf)
        {
           UpdateUI();
        }
        

    }

    private void UpdateUI() // ����� ���������� ���������
    {
        foreach (UIObject obj in objects) // ������� ������ ��������
        {
            obj.UpdateImage(); // ��������� ������ �� ��������
        }
    }
}
