using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    private Coroutine end; // ������ �� ���������� ��������, ����� �� ��������� ����� ��������


    public void WinGame() // � ������ ��������

    {

        if (end == null)

        {
            
            end = StartCoroutine(BeforeExit()); // ��������� ��������� ���� ����� 4 �������

        }

    }

    public void LoseGame() // � ������ ���������

    {

        if (end == null)

        {

            

            end = StartCoroutine(BeforeExit());

        }

    }

    public void ExitGame() // ����� �� ����

    {

        Application.Quit();

    }

    private IEnumerator BeforeExit() // �������� ����� ������� ��� ��������� ��������� ���������

    {

        yield return new WaitForSeconds(4f);

        MainManager.sceneChanger.OpenNewScene(0); // ������� � ������� ����

    }
}
