using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISimpleLoading : MonoBehaviour
{
    public void Begin()
    {
        transform.parent.gameObject.SetActive(true);
    }

    public void End()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
