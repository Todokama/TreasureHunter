using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void OpenNewScene(int id) // ����� ��� ����� �����

    {
        
        StartCoroutine(AsyncLoad(id)); // ��������� ����������� �������� �����

    }

    private IEnumerator AsyncLoad(int index)

    {

        AsyncOperation ready = null;

        ready = SceneManager.LoadSceneAsync(index);

        while (!ready.isDone) // ���� ����� �� �����������

        {

            yield return null; // ��� ��������� ����

        }

    }
   
}
