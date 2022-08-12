using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PanelMove : MonoBehaviour, IPointerClickHandler,

IPointerEnterHandler, IPointerExitHandler

{

    private RectTransform UIGameobject; // ��������� UI ������

    private float width; // ������ ������

    private float changeX; // �������� ���������� �������� ������

    private float speedPanel = 8; // �������� �������� ������

    private enum states // ������������ ��������� ������

    {

        open, close, opening, closing

    }

    private states state = states.close; // ����������� ��������� ��������

    private void Start()

    {

        // �������������� ���������� ����������

        UIGameobject = gameObject.GetComponent<RectTransform>();

        // ����������� ������ ������ �� ������� ���� ������������ ������

        width = 150 ;

    }

    private void FixedUpdate()

    {

        if (state == states.closing)

        {

            float x = UIGameobject.anchoredPosition.x;

            float y = UIGameobject.anchoredPosition.y;

            x -= speedPanel;

            changeX += speedPanel;

            UIGameobject.anchoredPosition = new Vector2(x, y);

            if (changeX > width)

            {

                state = states.close;

                changeX = 0;

            }

        }

        if (state == states.opening)

        {

            float x = UIGameobject.anchoredPosition.x;

            float y = UIGameobject.anchoredPosition.y;

            x += speedPanel;

            changeX += speedPanel;

            UIGameobject.anchoredPosition = new Vector2(x, y);

            if (changeX > width)

            {

                state = states.open;

                changeX = 0;

            }

        }

    }

    //�� ����� �� ������, ��������� ����� �����

    public void OnPointerClick(PointerEventData eventData)

    {

        MainManager.sceneChanger.OpenNewScene(0);

    }

    //��� ��������� �� ������ �����, ��������� ��

    public void OnPointerEnter(PointerEventData eventData)

    {

        if (state == states.close)

        {

            state = states.opening;

        }

    }

    //��� ��������� ���� ��������� ������

    public void OnPointerExit(PointerEventData eventData)

    {

        if (state == states.open)

        {

            state = states.closing;

        }

    }

}