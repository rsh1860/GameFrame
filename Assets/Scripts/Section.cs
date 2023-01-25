using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class Section : MonoBehaviour
{
    static Section instance;
    public static Section Instance()
    {
        if (instance == null)
        {
            instance = new Section();  
        }
        return instance;
    }

    public void Load()
    {
        OnLoad();
    }

    protected virtual void OnLoad()
    {
        
    }
}
