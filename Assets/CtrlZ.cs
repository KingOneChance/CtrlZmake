using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CtrlZ
{
    public CtrlZ next;
    public GameObject lastgameOject;
    public GameObject nowgameOject;
    public Transform lastTransform;
    public Transform nowTransform;
    public Color lastColor;
    public Color nowColor;
}

public class CtrlZList<T>
{
    public CtrlZ cur;
    public CtrlZ tail;

    public void AddStart(GameObject gameObject)
    {
        
    }
    public void AddEnd(GameObject gameObject)
    {

    }
}