using Cysharp.Threading.Tasks;
using UnityEngine;

public class Entry : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance().LoadloadingUI();
        UIManager.Instance().CreateEventSystem();
        SectionManager.Instance().ChangeSection("Logo").Forget();
    }
}
