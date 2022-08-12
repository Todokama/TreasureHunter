using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int currentGold;
    public Text goldText;

    public int currentHeart;
    public Text heartText;






    private Coroutine end; // ������ �� ���������� ��������, ����� �� ��������� ����� ��������


    public void WinGame() // � ������ ��������

    {

        if (end == null)

        {
            MainManager.Messenger.WriteMessage("�����������, �� ��������!");
            end = StartCoroutine(BeforeExit()); // ��������� ��������� ���� ����� 4 �������

        }

    }

    public void LoseGame() // � ������ ���������

    {

        if (end == null)

        {

            MainManager.Messenger.WriteMessage("�� ���������!");

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

    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        goldText.text = "X " + currentGold;

    }
    public void AddHeart(int heartToAdd)
    {
        currentHeart += heartToAdd;
        heartText.text = "X " + currentHeart;
    }
    public void RemoveHeart(int removeHeart)
    {
        currentHeart -= removeHeart;
        heartText.text = "X " + currentHeart;
    }
}
