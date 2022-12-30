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
            Debug.Log("꼬리없" + data.position);
            tailDoor = newBackDoor;
            curDoor = newBackDoor;
            tailDoor.gameObj = ob;
            curDoor.prev = tailDoor;
            tailDoor = curDoor;
        }
        else
        {
            Debug.Log("꼬리있음" + data.position);
            curDoor = newBackDoor;
            newBackDoor.prev =tailDoor;
            newBackDoor.gameObj = ob;
            if (tailDoor.gameObj == newBackDoor.gameObj)
                Debug.Log("같은 사물 : " + ob.name);

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
        Debug.Log("확인 : " + lastPos.name);
        RectTransform newOb = new RectTransform();
        if (curDoor.gameObj == curDoor.prev.gameObj)
        {

            newOb = lastPos.GetComponent<RectTransform>();

            newOb.position = curDoor.prev.backDoorData.position;
            newOb.rotation = Quaternion.identity;
            newOb.Rotate(curDoor.prev.backDoorData.rotation);
            newOb.localScale = curDoor.prev.backDoorData.scale;

            Debug.Log("왜틀렷지 : " + lastPos.name);
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
        Debug.Log("삭제요청");
        if (conZList.Count <= 0) return;
        else if (conZList.Count == 1)
        {
            Debug.Log("하나임");

            Destroy(conZList[conZList.Count - 1]);
            conZList.RemoveAt(conZList.Count - 1);
        }
        else
        {
            Debug.Log("하나아님");

            if (conZList[conZList.Count - 1].name == conZList[conZList.Count - 2].name)
            {
                Debug.Log("같은 이름 오브젝트 자리가져옴");
                Debug.Log("기존 위치: " + conZList[conZList.Count - 1].transform.position + "돌아갈 위치: " + conZList[conZList.Count - 2].transform.position);

                conZList[conZList.Count - 1].transform.position = conZList[conZList.Count - 2].transform.position;
                conZList[conZList.Count - 1].transform.rotation = conZList[conZList.Count - 2].transform.rotation;
                conZList[conZList.Count - 1].transform.localScale = conZList[conZList.Count - 2].transform.localScale;
                conZList.RemoveAt(conZList.Count - 1);
            }
            else
            {
                Debug.Log("다른 이름 오브젝트 삭제함");

                Destroy(conZList[conZList.Count - 1]);
                conZList.RemoveAt(conZList.Count - 1);
            }
        }
    }
}
