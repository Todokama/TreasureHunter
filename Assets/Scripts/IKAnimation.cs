using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimation : MonoBehaviour
{
    private Animator anim; //���������� ��� ������ �� ���������� ��������
    private bool interact; // ���������, ���������� �� ��������������
    private Vector3 positionForI�; // ������� ������� ��� ��������������
    float weight = 0;   
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // ����� ������� Update, �� ������������ ��� ����������� ��������
    private void OnAnimatorIK() // ����� ������� Update, �� ������������ ��� ����������� ��������

    {

        if (interact)
        {
            // �.�. ��� �������� �� 0 �� 1, � ���������� �� ������ 0,
            // �� ��� �������� �������� ���� �� �������� �������
            // ���������� ������ �������� ��� ik ��������.
            if (weight < 1) weight += 0.01f;
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight); // ������� 1f �� w
            anim.SetIKPosition(AvatarIKGoal.RightHand, positionForI�);
            //��������� ������� ��� ����������� ����� ����
            anim.SetLookAtWeight(weight);
            //������� ������������� ��� �������� (1 � ��������� �������������� ������������ ��������
            //� �������� ����� �������� ����� �� ������
            anim.SetLookAtPosition(positionForI�); //��������� ���� ����� ��������
        }

        else if (weight > 0) // ������� ��� ������� ��� �������� ��������� �������� ��� ���������
        {
            weight -= 0.02f; // ������ ����� ������ ������ ����������� ��������
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, positionForI�);
            anim.SetLookAtWeight(weight);
            anim.SetLookAtPosition(positionForI�);
        }

    }


    public void StartInteraction(Vector3 pos)
    {
        positionForI� = pos;
        interact = true;
    }
    public void StopInteraction()
    {
        interact = false;
    }
}
