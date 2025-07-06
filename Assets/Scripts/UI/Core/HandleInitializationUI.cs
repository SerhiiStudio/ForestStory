using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInitializationUI : MonoBehaviour
{
    [SerializeField] private AbsUiInitializable[] initializeables;

    private void Start()
    {
        foreach(var i in initializeables)
        {
            if (i != null && i.gameObject.activeInHierarchy)
                i.Initialize();
        }
    }
}
