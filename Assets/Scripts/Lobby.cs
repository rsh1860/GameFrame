using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : Section
{
    UILobbyBehaviour lobbyUI;

    protected override void OnLoad()
    {
        var lobbyPrefab = Resources.Load<GameObject>("UI/UILobby");
        if (lobbyPrefab != null)
        {
            var instance = Instantiate(lobbyPrefab);
            lobbyUI= instance.GetComponentInChildren<UILobbyBehaviour>();
            lobbyUI.ClickedBack += ClickBack;
        }
    }

    void ClickBack()
    {
        //SectionManager.Instance().ChangeSection("Title").Forget();
        SectionManager.Instance().ChangeSectionWithoutLoading("Title");
    }
}
