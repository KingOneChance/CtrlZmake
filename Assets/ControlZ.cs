using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public struct BackDoorData
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
}
public class BackDoor
{
    public BackDoorData backDoorData;
    public BackDoor prev;
    public GameObject gameObj;
}
public class ControlZ : MonoBehaviour
{
    #region singletontest
    private static ControlZ _instance;
    public static ControlZ instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ControlZ>();
                if (_instance == null)
                    _instance = new GameObject().AddComponent<ControlZ>();
            }
            return _instance;
        }
    }
    #endregion

    public BackDoor curDoor;
    public BackDoor tailDoor;

    GameObject lastPos;
    public void AddBackDoorLIst(BackDoorData data, GameObject ob = null)
    {
        BackDoor newBackDoor = new BackDoor();
        newBackDoor.backDoorData = data;
        if (tailDoor == null)
        {
            Debug.Log("������" + data.position);
            tailDoor = newBackDoor;
            curDoor = newBackDoor;
            tailDoor.gameObj = ob;
            curDoor.prev = tailDoor;
            tailDoor = curDoor;
        }
        else
        {
            Debug.Log("��������" + data.position);
            curDoor = newBackDoor;
            newBackDoor.prev =tailDoor;
            newBackDoor.gameObj = ob;
            if (tailDoor.gameObj == newBackDoor.gameObj)
                Debug.Log("���� �繰 : " + ob.name);

            tailDoor = curDoor;
        }
        lastPos = ob;
    }
  
    public void OnClick_GoBackDoor()
    {
        GoBackDoor();
    }
    public void GoBackDoor()
    {
        if (tailDoor == null) return;
        Debug.Log("Ȯ�� : " + lastPos.name);
        RectTransform newOb = new RectTransform();
        if (curDoor.gameObj == curDoor.prev.gameObj)
        {

            newOb = lastPos.GetComponent<RectTransform>();

            newOb.position = curDoor.prev.backDoorData.position;
            newOb.rotation = Quaternion.identity;
            newOb.Rotate(curDoor.prev.backDoorData.rotation);
            newOb.localScale = curDoor.prev.backDoorData.scale;

            Debug.Log("��Ʋ���� : " + lastPos.name);
            curDoor = curDoor.prev;
            tailDoor = curDoor.prev;
        }
        else
        {
            lastPos = curDoor.prev.gameObj;
            curDoor = tailDoor.prev;
            tailDoor = curDoor.prev;
        }
        lastPos = tailDoor.gameObj;
    }













    List<GameObject> conZList = new List<GameObject>();
    GameObject now;
    public void AddList(GameObject recordObj)
    {
        GameObject test = new GameObject();
        test = recordObj;

        if (conZList.Count <= 1)
            conZList.Add(recordObj);
        else
        {
            if (conZList[conZList.Count - 1].name == conZList[conZList.Count - 2].name)
            {
                test.transform.position = recordObj.transform.position;
                test.transform.rotation = recordObj.transform.rotation;
                test.transform.localScale = recordObj.transform.localScale;
                conZList.Add(test);
            }
            else
            {
                conZList.Add(test);
            }
        }
    }
    public void ConZRun()
    {
        Debug.Log("������û");
        if (conZList.Count <= 0) return;
        else if (conZList.Count == 1)
        {
            Debug.Log("�ϳ���");

            Destroy(conZList[conZList.Count - 1]);
            conZList.RemoveAt(conZList.Count - 1);
        }
        else
        {
            Debug.Log("�ϳ��ƴ�");

            if (conZList[conZList.Count - 1].name == conZList[conZList.Count - 2].name)
            {
                Debug.Log("���� �̸� ������Ʈ �ڸ�������");
                Debug.Log("���� ��ġ: " + conZList[conZList.Count - 1].transform.position + "���ư� ��ġ: " + conZList[conZList.Count - 2].transform.position);

                conZList[conZList.Count - 1].transform.position = conZList[conZList.Count - 2].transform.position;
                conZList[conZList.Count - 1].transform.rotation = conZList[conZList.Count - 2].transform.rotation;
                conZList[conZList.Count - 1].transform.localScale = conZList[conZList.Count - 2].transform.localScale;
                conZList.RemoveAt(conZList.Count - 1);
            }
            else
            {
                Debug.Log("�ٸ� �̸� ������Ʈ ������");

                Destroy(conZList[conZList.Count - 1]);
                conZList.RemoveAt(conZList.Count - 1);
            }
        }
    }
}
