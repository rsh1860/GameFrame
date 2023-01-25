using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Logo : Section
{
    protected override void OnLoad()
    {
        var logoPrefab = Resources.Load<GameObject>("UI/UILogo");
        if (logoPrefab != null)
        {
            var instance = Instantiate(logoPrefab);
        }
    }

    public void GoToTitle()
    {
        SectionManager.Instance().ChangeSection("Title").Forget();
    }
}
