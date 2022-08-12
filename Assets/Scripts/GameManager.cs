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






    private Coroutine end; // ссылка на запущенную корутину, чтобы не проиграть после выигрыша


    public void WinGame() // в случае выигрыша

    {

        if (end == null)

        {
            MainManager.Messenger.WriteMessage("Поздравляем, вы выиграли!");
            end = StartCoroutine(BeforeExit()); // запускаем окончание игры через 4 секунды

        }

    }

    public void LoseGame() // в случае проигрыша

    {

        if (end == null)

        {

            MainManager.Messenger.WriteMessage("Вы проиграли!");

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
