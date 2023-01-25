using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SectionManager : MonoBehaviour
{
    static SectionManager instance;
    public static SectionManager Instance()
    {
        if (instance == null)
        {
            instance = new SectionManager();
        }
        return instance;
    }

    Section _current;

    public async UniTask ChangeSection(string sectionName)
    {
        await ChangeSection(Type.GetType(sectionName));
    }

    public async UniTask ChangeSection(Type sectionType)
    {
        if (sectionType == null)
        {
            sectionType = typeof(Title);
        }

        UIManager.Instance().ShowSimpleLoading();

        Scene activedScene = SceneManager.GetActiveScene();
        Scene[] activedScenes = new Scene[SceneManager.sceneCount];
        for (int i = 0; i < activedScenes.Length; i++)
        {
            activedScenes[i] = SceneManager.GetSceneAt(i);
        }

        await UniTask.Delay(1500); //로딩 화면 유지 시간

        Scene scene = SceneManager.CreateScene($"{sectionType.Name}.Section");
        SceneManager.SetActiveScene(scene);
        var sectionObject = new GameObject($"{sectionType.Name}.Section.Object");
        Section current = sectionObject.AddComponent(sectionType) as Section;
        current.Load();

        for (int i = 0; i < activedScenes.Length; i++)
        {
            var del = activedScenes[i];
            if (del.isLoaded)
            {
                SceneManager.UnloadScene(del);
            }
        }

        UIManager.Instance().HideSimpleLoading();
    }

    public void ChangeSectionWithoutLoading(string sectionName)
    {
        Type sectionType = Type.GetType(sectionName);

        if (sectionType == null)
        {
            sectionType = typeof(Title);
        }

        if (sectionType == null)
        {
            sectionType = typeof(Title);
        }

        Scene activedScene = SceneManager.GetActiveScene();
        Scene[] activedScenes = new Scene[SceneManager.sceneCount];
        for (int i = 0; i < activedScenes.Length; i++)
        {
            activedScenes[i] = SceneManager.GetSceneAt(i);
        }

        Scene scene = SceneManager.CreateScene($"{sectionType.Name}.Section");
        SceneManager.SetActiveScene(scene);
        var sectionObject = new GameObject($"{sectionType.Name}.Section.Object");
        Section current = sectionObject.AddComponent(sectionType) as Section;
        current.Load();

        for (int i = 0; i < activedScenes.Length; i++)
        {
            var del = activedScenes[i];
            if (del.isLoaded)
            {
                SceneManager.UnloadScene(del);
            }
        }
    }
}
