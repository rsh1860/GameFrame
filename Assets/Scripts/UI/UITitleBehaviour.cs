using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitleBehaviour : MonoBehaviour
{
    public Action EnteredLobby;

    public void ClickLobby()
    {
        EnteredLobby.Invoke();
    }
}
