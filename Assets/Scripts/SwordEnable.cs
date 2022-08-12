using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnable : MonoBehaviour
{
    public GameObject m_sword;
    public void ActivateSword()
    {
        m_sword.GetComponent<Collider>().enabled = true;
    }
    public void DeactivateSword()
    {
        m_sword.GetComponent<Collider>().enabled = false;
    }
}
