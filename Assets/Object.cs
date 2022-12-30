using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    NodeData nodeData;
    RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        nodeData = new NodeData();
        nodeData.position = rect.position;
        nodeData.rotation = rect.rotation.eulerAngles;
        nodeData.scale = rect.localScale;
        DiaryMGR.instance.AddDrangBegin(nodeData,gameObject);
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        nodeData = new NodeData();
        nodeData.position = rect.position;
        nodeData.rotation = rect.rotation.eulerAngles;
        nodeData.scale = rect.localScale;
        DiaryMGR.instance.AddDrangEnd(nodeData);
    }
}
