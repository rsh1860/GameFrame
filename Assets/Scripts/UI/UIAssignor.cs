using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIAssignor : MonoBehaviour
{
    [SerializeField]
    Component[] components;
    [SerializeField]
    string[] keys;
    [SerializeField]
    Button[] eventAgents;
    [SerializeField]
    int[] eventSizes;
    [SerializeField]
    UnityEvent[] unityEvents;
    [SerializeField]
    UIAction[] uiActions;
    [Serializable]
    public enum UIAction { Ignore, OnClicked, OnValueChagned };

    void Awake()
    {
        int eventIndex = 0;
        for (int agentIndex = 0; agentIndex < eventAgents.Length; agentIndex++)
        {
            var agent = eventAgents[agentIndex];
            for (int j = 0; j < eventSizes[agentIndex]; j++)
            {
                var uEvent = unityEvents[eventIndex];
                var uiAction = uiActions[eventIndex];
                AssginComponentEvent(agent, uEvent, uiAction);
                eventIndex++;
            }
        }
    }
    public bool TryGet<T>(string key, out T result) where T : Component
    {
        result = null;
        if (TryToIndex(key, out var index))
        {
            if (components.Length > index)
            {
                result = components[index] as T;
                return true;
            }
        }

        return false;
    }
    private bool TryToIndex(string key, out ushort index)
    {
        index = ushort.MaxValue;
        for (ushort i = 0; i < keys.Length; ++i)
        {
            if (key.Equals(keys[i]))
            {
                index = i;
                return true;
            }
        }
        return false;
    }

    public static void AssginComponentEvent(Component component, UnityEvent uEvent, UIAction uiAction)
    {
        if (component is Button)
        {
            if (uiAction.Equals(UIAction.OnClicked))
            {
                var button = component as Button;
                button.onClick.AddListener(() =>
                {
                    uEvent.Invoke();
                });
            }
        }
    }
}
