using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryMGR : MonoBehaviour
{
    #region singletonMGR
    private static DiaryMGR _instance;
    public static DiaryMGR instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DiaryMGR>();
                if (_instance == null)
                    _instance = new GameObject().AddComponent<DiaryMGR>();
            }
            return _instance;
        }
    }
    #endregion

    public MyLinkedList conZ =null;

    private void Start()
    {
        conZ = new MyLinkedList();
    }

    public void AddDrangBegin(NodeData nodata, GameObject gameObject) => conZ.AddDragStart(nodata, gameObject);

    public void AddDrangEnd(NodeData nodata) => conZ.AddDragEnd(nodata);

}
