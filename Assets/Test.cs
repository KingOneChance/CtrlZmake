using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;



public class Test : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Vector3 Pos { get; private set; }
    public Vector3 prevPos { get; private set; }

    GameObject myGameObj;
    RectTransform rect;

    //�鵵�� ��ũ�� ����Ʈ
    BackDoorData backDoorData;

    //public Action<GameObject> recordObject;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
      //recordObject = ControlZ.instance.AddList;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        prevPos = rect.transform.position;
       // recordObject(gameObject);

        //������ �־��ֱ� 
        backDoorData = new BackDoorData();
        backDoorData.position = rect.position;
        backDoorData.rotation = rect.rotation.eulerAngles;
        backDoorData.scale = rect.localScale;
        ControlZ.instance.AddBackDoorLIst(backDoorData, gameObject);
    }
    public void OnDrag(PointerEventData eventData)
    {
        rect.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
     //   recordObject(gameObject);
        //������ �־��ֱ� 
        backDoorData = new BackDoorData();
        backDoorData.position = rect.position;
        backDoorData.rotation = rect.rotation.eulerAngles;
        backDoorData.scale = rect.lossyScale;
        ControlZ.instance.AddBackDoorLIst(backDoorData, gameObject);
    }
}
