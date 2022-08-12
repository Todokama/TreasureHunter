using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject firstTrigger;
    public GameObject cutsceneCam;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        firstTrigger.SetActive(false);
        cutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        
        StartCoroutine(FinishCutscene());
    }

    IEnumerator FinishCutscene()
    {
        yield return new WaitForSeconds(20);
        firstTrigger.SetActive(true);
        thePlayer.SetActive(true);
        cutsceneCam.SetActive(false);
    }

}
