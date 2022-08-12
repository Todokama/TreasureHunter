using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScene : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Invemtory.slot[0].GetComponent<Slot>().type == "Key")
            {
                MainManager.Messenger.WriteMessage("������� F, ����� �������� ������!");
                if (Input.GetKeyDown(KeyCode.F))
                {

                    MainManager.sceneChanger.OpenNewScene(5);
                }
            }
            else
            {
                MainManager.Messenger.WriteMessage("�� �� ����� ����");
            }
        }
    }
}
