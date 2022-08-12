using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    private Coroutine end; // ссылка на запущенную корутину, чтобы не проиграть после выигрыша


    public void WinGame() // в случае выигрыша

    {

        if (end == null)

        {
            
            end = StartCoroutine(BeforeExit()); // запускаем окончание игры через 4 секунды

        }

    }

    public void LoseGame() // в случае проигрыша

    {

        if (end == null)

        {

            

            end = StartCoroutine(BeforeExit());

        }

    }

    public void ExitGame() // выход из игры

    {

        Application.Quit();

    }

    private IEnumerator BeforeExit() // корутина перед выходом для прочтения последних сообщений

    {

        yield return new WaitForSeconds(4f);

        MainManager.sceneChanger.OpenNewScene(0); // выходим в главное меню

    }
}
