using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class UILobbyBehaviour : MonoBehaviour
{
    UIAssignor assignor;
    RectTransform panelA;
    RectTransform panelB;
    RectTransform panelC;

    public Action ClickedBack;

    void Awake()
    {
        assignor = GetComponent<UIAssignor>();
        assignor.TryGet<RectTransform>("PanelA", out panelA);
        assignor.TryGet<RectTransform>("PanelB", out panelB);
        assignor.TryGet<RectTransform>("PanelC", out panelC);
    }

    public void OptionA()
    {
        Toggle(panelA.gameObject);
    }

    public void OptionB()
    {
        Toggle(panelB.gameObject);
    }

    public void OptionC()
    {
        Toggle(panelC.gameObject);
    }

    public void Toggle(GameObject obj)
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
            return;
        }
        obj.SetActive(true);
    }

    public void BackToTitle()
    {
        ClickedBack.Invoke();
    }
}
