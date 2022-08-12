using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinAnimation : MonoBehaviour

{

    public Animator chestanimator;//ссылка на аниматор двери  

    public Transform target;//ссылка на точку для начала анимации

    private Quaternion newRot;//требуемый поворот  

    private Animator anim;//аниматор персонажа

    private bool secondTurn = false;




    private States state;//текущее состояние  


    private enum States//перечисление состояний персонажа

    {

        wait,//ожидание

        turn,//поворот

        walk//перемещение

    }

   private void OnTriggerEnter(Collider other)
    {

        bool isChestOpen = chestanimator.GetBool("isOpen");
        if (other.gameObject.CompareTag("chest"))
        {

            if (Invemtory.slot[0].GetComponent<Slot>().type == "Key" && !isChestOpen)
            {

                MainManager.Messenger.WriteMessage("Нажмите F, чтобы открыть сундук");

            }
            else
            {
                if(!isChestOpen)

                MainManager.Messenger.WriteMessage("Найдите ключ, чтобы открыть сундук");


            }
        }
    }


    private void Start()

    {

        anim = GetComponent<Animator>();//инициализируем аниматор

        state = States.wait;     //изначально состояние ожидания

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

            switch (state)//переключаем в зависимости от состояния

            {


                case States.turn://при повороте к точке

                    {
                        bool isOpen = chestanimator.GetBool("isOpen");


                        if (!isOpen)
                        {
                            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * 2);//интерполируем между начальным поворотом и требуемым

                            if (Mathf.Abs(Mathf.Round(newRot.y * 100)) == Mathf.Abs(Mathf.Round(transform.rotation.y * 100)))//проверяем когда персонаж повернулся

                            {

                                transform.rotation = newRot;//для избежания погрешности

                            if (!secondTurn)

                            {

                                state = States.walk;//переключаем состояние на перемещение

                                anim.SetFloat("speed", 1f);      //включаем анимацию ходьбы  

                            }

                            else

                            {



                                chestanimator.SetTrigger("open");//запуск анимации двери

                                anim.SetTrigger("open");//запуск анимации персонажа

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

                        transform.position = transform.position + transform.forward * Time.deltaTime;//перемещаем персонажа прямо                  

                        if (Vector3.Distance(transform.position, target.position) <= 0.5)//дошел

                        {

                            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);//для исключения погрешности ставим в требуемую точку

                            anim.SetFloat("speed", 0);//выключаем анимацию ходьбы

                            secondTurn = true;

                            state = States.wait;

                            GoToPoint();

                        }

                        break;

                    }

            }

        
    }
    public void GoToPoint()//функция для начала выполнения

    {

        if (state == States.wait)//если ждем

        {

            state = States.turn;//переходим в состояние поворота к точке

            Vector3 relativePos = new Vector3();

            if (!secondTurn)

            {

                relativePos = target.position - transform.position;//вычисляем координату куда нужно будет повернуться

            }

            else

            {

                Vector3 forward = target.transform.position + target.transform.forward;

                relativePos = new Vector3(forward.x, transform.position.y, forward.z) - transform.position;

            }

            newRot = Quaternion.LookRotation(relativePos);//указываем нужный поворот

        }

    }

}