using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObject : MonoBehaviour
{
    public GameObject objectInScene; // ��������������� ������ �� �����
    [SerializeField]
    private Image imagePlace; // ����� ��� ��������
    [SerializeField]
   private Sprite image; // ��������
    [SerializeField]
    
    
   

    public bool State { get; set; } // ��������� �������� ��������� ��������/�� �������� ������

    

    public void UpdateImage() // �������� �������� � ����������� �� ���������
    {
        if (State) // ���� ������ ������� (��������)
        {
            imagePlace.sprite = image; // ���������� ��������
             // ������� ������� �������
        }
        else // ���� ������ ��� �� ��������
        {
            imagePlace.sprite =null; // �� ���������� ��������
        
        }
    }
}
