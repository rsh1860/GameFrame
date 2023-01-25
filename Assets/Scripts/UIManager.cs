using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance()
    {
        if (instance == null)
        {
            instance = new UIManager();
        }
        return instance;
    }

    GameObject rootObject;
    static UISimpleLoading _simpleLoading;

    public void LoadloadingUI()
    {
        rootObject = new GameObject("LoadingUI>>");
        DontDestroyOnLoad(rootObject);
        var loading = Resources.Load<GameObject>("UI/UILoading");
        var instance = Instantiate(loading);
        instance.transform.SetParent(rootObject.transform);
        _simpleLoading = instance.GetComponentInChildren<UISimpleLoading>();
        _simpleLoading.gameObject.SetActive(true);
    }

    public void ShowSimpleLoading()
    {
        _simpleLoading.Begin();
    }

    public void HideSimpleLoading()
    {
        _simpleLoading.End();
    }

    public void CreateEventSystem()
    {
        var eventSystem = new GameObject("EventSystem>>");
        eventSystem.AddComponent<UnityEngine.EventSystems.EventSystem>();
        eventSystem.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        UnityEngine.Object.DontDestroyOnLoad(eventSystem);
    }
}
