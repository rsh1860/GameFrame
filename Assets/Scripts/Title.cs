using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : Section
{
    UITitleBehaviour titleUI;
    string loadToScene = string.Empty;

    protected override void OnLoad()
    {
        var titlePrefab = Resources.Load<GameObject>("UI/UITitle");
        if (titlePrefab != null)
        {
            var instance = Instantiate(titlePrefab);
            titleUI = instance.GetComponentInChildren<UITitleBehaviour>();
            if (titleUI != null )
            {
                titleUI.EnteredLobby += EnterLobby;
            }
        }
    }

    void EnterLobby()
    {
        SectionManager.Instance().ChangeSection("Lobby").Forget();
    }
}
