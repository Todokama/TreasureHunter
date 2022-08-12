using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot1 : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent botagent; // ������ �� ����� ���������
    private Animator animbot; // ������ �� �������� ����

    [SerializeField]
    private GameObject[] points; // ������ ����� ��� ���������
    float weight = 0;

    //������������ ��������� ����
    private enum states
    {
        waiting, // �������
        going, // ���
        dialog // �������
    }

    states state = states.waiting; // ����������� ��������� ��������

    private void Start()
    {
        animbot = GetComponent<Animator>(); // ����� ��������� ���������
        botagent = GetComponent<NavMeshAgent>(); // ����� ��������� ������
        StartCoroutine(Wait()); // ��������� �������� ��������
        player = FindObjectOfType<Movement>().gameObject;
    }


    private void FixedUpdate()
    {
        switch (state)
        {
            case (states.waiting):
                {
                    if (PlayerNear())
                    {
                        PrepareToDialog();
                    }
                    break;
                }

            case states.going:
                {
                    if (PlayerNear())
                    {
                        PrepareToDialog();
                    }
                    // ���� ��������� �� ������ ���������� ������ ��������� ���������� (�.�. ��� ����� �� �������� ��� �����)
                    else if ((Vector3.Distance(transform.position, botagent.destination)) < 0.4)
                    {
                        StartCoroutine(Wait()); // �������� �������� ��������
                    }
                    break;
                }
            case states.dialog:
                {
                    if (!PlayerNear())
                    {
                        StartCoroutine(Wait());
                    }
                    break;
                }
        }
    }

    private bool PlayerNear()
    {
        return (Vector3.Distance(gameObject.transform.position, player.transform.position) < 2);
    }


    private void PrepareToDialog()
    {

        botagent.SetDestination(transform.position); // �������� �����, ����� ��� ������ �� ���
        animbot.SetBool("walk", false); // ������������� �������� ������
        state = states.dialog; // ������������� ��������� ������� � ������� � ������� ������ �����

    }

    private void OnAnimatorIK()
    {
        if (state == states.dialog)
        {
            if (weight < 1)
            {
                weight += 0.05f;
            }
            animbot.SetLookAtWeight(weight); // ��������� ���� ����������� �� ������
            // ��������� ���� ��������
            animbot.SetLookAtPosition(player.transform.TransformPoint(Vector3.up * 1.5f));
        }
        else if (weight > 0)
        {
            weight -= 0.05f;
            animbot.SetLookAtWeight(weight);
            animbot.SetLookAtPosition(player.transform.TransformPoint(Vector3.up * 1.5f));
        }
    }

    private IEnumerator Wait() // �������� ��������
    {
        botagent.SetDestination(transform.position); // �������� �����, ����� ��� ������ �� ���
        animbot.SetBool("walk", false); // ������������� �������� ������
        state = states.waiting; // ���������, ��� ��� ������� � ����� ��������
        yield return new WaitForSeconds(3f); // ���� 10 ������
        botagent.SetDestination(points[Random.Range(0, points.Length)].transform.position);
        // destination � ���� ���� ����, �������� ��� �������� ���� �� ����� �����
        animbot.SetBool("walk", true); // �������� �������� ������
        state = states.going; // ���������, ��� ��� ��������� � ��������
    }


}
