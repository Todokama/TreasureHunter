using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void OpenNewScene(int id) // метод для смены сцены

    {
        
        StartCoroutine(AsyncLoad(id)); // запускаем асинхронную загрузку сцены

    }

    private IEnumerator AsyncLoad(int index)

    {

        AsyncOperation ready = null;

        ready = SceneManager.LoadSceneAsync(index);

        while (!ready.isDone) // пока сцена не загрузилась

        {

            yield return null; // ждём следующий кадр

        }

    }
   
}
