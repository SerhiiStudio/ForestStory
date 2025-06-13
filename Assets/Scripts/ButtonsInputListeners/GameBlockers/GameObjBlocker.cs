using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjBlocker : MonoBehaviour
{
    [SerializeField] protected int id;
    [SerializeField] protected GameObject[] gameObjectsToBlock;
    [SerializeField] protected GameObject[] gameObjectsToUnblock;


    protected void OnEnable()
    {
        EventSystem.Instance.Buttons += EventHandler_ObjBlocker;
    }
    protected void OnDisable()
    {
        EventSystem.Instance.Buttons -= EventHandler_ObjBlocker;
    }

    protected void EventHandler_ObjBlocker(int id)
    {
        if (id == this.id)
        {
            CallMethods();
        }
    }

    protected virtual void CallMethods()
    {
        BlockGameObjects();
        UnblockGameObjects();
    }

    protected virtual bool CanExecute()
    {
        return true;
    }

    protected void BlockGameObjects()
    {
        foreach (GameObject go in gameObjectsToBlock)
        {
            if (go != null)
                go.SetActive(false);
        }
    }
    protected void UnblockGameObjects()
    {
        foreach (GameObject go in gameObjectsToUnblock)
        {
            if (go != null)
                go.SetActive(true);
        }
    }
}
