using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Messenger : MonoBehaviour
{
    private Text message; // ������ �� �����
    public Image panel;

    private static Coroutine RunMessage; // ������ �� ���������� ��������

    private void Start()

    {

        // ����� ��������� ������, �.�. ����� � ������ ��������� �� ����� �������
        panel.GetComponent<Image>().enabled = false;
        message = GetComponent<Text>();
       // �������� ���� ������ ��������� ��� ������������

    }

    public void WriteMessage(string text) // ����� ��� ������� �������� � ������� ���������

    {

        panel.GetComponent<Image>().enabled = true;
        // �������� � ��������� ��������, ���� ��� ��� ���� ��������

        if (RunMessage != null) StopCoroutine(RunMessage);

        this.message.text = ""; // ������� ������
        

        // ������ �������� � ������� ������ ���������

        RunMessage = StartCoroutine(Message(text));

    }

    private IEnumerator Message(string message) // �������� ��� ������ ���������

    {

        this.message.text = message; // ���������� ���������

        yield return new WaitForSeconds(2f); // ���� 4 �������

        this.message.text = ""; // ������� ������
        panel.GetComponent<Image>().enabled = false;


    }
}
