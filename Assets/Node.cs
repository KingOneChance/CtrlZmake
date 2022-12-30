using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct NodeData
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
}

public class Node : MonoBehaviour
{
    public Node next;
    public GameObject myObject;
    public NodeData nodeData;
}

public class MyLinkedList
{
    public Node cur;
    public Node head;
    public Node tail;

    public void AddDragStart(NodeData newData, GameObject myObj)
    {
        Node newNode = new Node();
        newNode.nodeData = newData;
        newNode.myObject = myObj;

        if (head == null) head = newNode;
        else tail.next = newNode;

        tail = newNode;
        Debug.Log("드래그 비긴으로 추가된 오브젝트 : " + tail.name);

    }
    public void AddDragEnd(NodeData newData)
    {
        if (head == null) return; //현실적 불가능
        tail.nodeData = newData;
        Debug.Log("드래그 엔드로 추가된 오브젝트 : " + tail.name);
    }
    public void AddInstanitateEnd(NodeData newData, GameObject myObj)
    {
        Node newNode = new Node();
        newNode.nodeData = newData;
        newNode.myObject = myObj;

        if (head == null) head = newNode;
        else tail.next = newNode;

        tail = newNode;
        Debug.Log("생성으로 추가된 오브젝트 : " + tail.name);

    }
    public void BackDoor()
    {
        tail = tail.next;
        Debug.Log("되돌릴 이름 : " + tail.name);
        Debug.Log("되돌려진 이름 : " + tail.next.name);
    }
}