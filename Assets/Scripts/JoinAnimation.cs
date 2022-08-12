using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinAnimation : MonoBehaviour

{

    public Animator chestanimator;//������ �� �������� �����  

    public Transform target;//������ �� ����� ��� ������ ��������

    private Quaternion newRot;//��������� �������  

    private Animator anim;//�������� ���������

    private bool secondTurn = false;




    private States state;//������� ���������  


    private enum States//������������ ��������� ���������

    {

        wait,//��������

        turn,//�������

        walk//�����������

    }

   private void OnTriggerEnter(Collider other)
    {

        bool isChestOpen = chestanimator.GetBool("isOpen");
        if (other.gameObject.CompareTag("chest"))
        {

            if (Invemtory.slot[0].GetComponent<Slot>().type == "Key" && !isChestOpen)
            {

                MainManager.Messenger.WriteMessage("������� F, ����� ������� ������");

            }
            else
            {
                if(!isChestOpen)

                MainManager.Messenger.WriteMessage("������� ����, ����� ������� ������");


            }
        }
    }


    private void Start()

    {

        anim = GetComponent<Animator>();//�������������� ��������

        state = States.wait;     //���������� ��������� ��������

    }

    private void Update()

    {
        if (Invemtory.slot[0].GetComponent<Slot>().type == "Key")
        {



            if (Input.GetKeyDown(KeyCode.F))

            {

                GoToPoint();

            }
        }

            switch (state)//����������� � ����������� �� ���������

            {


                case States.turn://��� �������� � �����

                    {
                        bool isOpen = chestanimator.GetBool("isOpen");


                        if (!isOpen)
                        {
                            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * 2);//������������� ����� ��������� ��������� � ���������

                            if (Mathf.Abs(Mathf.Round(newRot.y * 100)) == Mathf.Abs(Mathf.Round(transform.rotation.y * 100)))//��������� ����� �������� ����������

                            {

                                transform.rotation = newRot;//��� ��������� �����������

                            if (!secondTurn)

                            {

                                state = States.walk;//����������� ��������� �� �����������

                                anim.SetFloat("speed", 1f);      //�������� �������� ������  

                            }

                            else

                            {



                                chestanimator.SetTrigger("open");//������ �������� �����

                                anim.SetTrigger("open");//������ �������� ���������

                                secondTurn = !secondTurn;

                                state = States.wait;

                                chestanimator.SetBool("isOpen", true);




                                
                                        
                               
                           


                                }

                            }
                        }
                   

                        break;

                    }


                case States.walk:

                    {

                        transform.position = transform.position + transform.forward * Time.deltaTime;//���������� ��������� �����                  

                        if (Vector3.Distance(transform.position, target.position) <= 0.5)//�����

                        {

                            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);//��� ���������� ����������� ������ � ��������� �����

                            anim.SetFloat("speed", 0);//��������� �������� ������

                            secondTurn = true;

                            state = States.wait;

                            GoToPoint();

                        }

                        break;

                    }

            }

        
    }
    public void GoToPoint()//������� ��� ������ ����������

    {

        if (state == States.wait)//���� ����

        {

            state = States.turn;//��������� � ��������� �������� � �����

            Vector3 relativePos = new Vector3();

            if (!secondTurn)

            {

                relativePos = target.position - transform.position;//��������� ���������� ���� ����� ����� �����������

            }

            else

            {

                Vector3 forward = target.transform.position + target.transform.forward;

                relativePos = new Vector3(forward.x, transform.position.y, forward.z) - transform.position;

            }

            newRot = Quaternion.LookRotation(relativePos);//��������� ������ �������

        }

    }

}