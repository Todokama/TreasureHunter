using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOverTime : MonoBehaviour
{
    public float deltaTime;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Disable", deltaTime);
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }
}
