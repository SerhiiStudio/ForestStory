using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemUsedListener : MonoBehaviour
{
    [SerializeField] protected int id;
    [SerializeField] protected UnityEvent onSuccess;
    [SerializeField] protected UnityEvent onFailure;


    protected void OnEnable() => EventSystem.Instance.ItemUsedEvent += ItemUsedHandler;
    protected void OnDisable() => EventSystem.Instance.ItemUsedEvent -= ItemUsedHandler;

    protected void ItemUsedHandler(int id, bool result)
    {
        if(!CanHandle(id))
            return;

        if(result)
            onSuccess?.Invoke();
        else
            onFailure?.Invoke();
        
    }

    protected virtual bool CanHandle(int id) => CompareId(id);

    protected bool CompareId(int id) => id == this.id;

    public void DeleteSelf()
    {
        Destroy(gameObject);
    }
}