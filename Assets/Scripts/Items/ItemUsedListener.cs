using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemUsedListener : MonoBehaviour
{
    [SerializeField] protected int id;
    [SerializeField] protected UnityEvent actions;

    protected void OnEnable() => EventSystem.Instance.ItemSuccessfullyUsedEvent += ItemUsedHandler;
    protected void OnDisable() => EventSystem.Instance.ItemSuccessfullyUsedEvent -= ItemUsedHandler;

    protected void ItemUsedHandler(int id)
    {
        if(!CanHandle(id))
            return;
        actions?.Invoke();
        
    }

    protected virtual bool CanHandle(int id) => CompareId(id);

    protected bool CompareId(int id) => id == this.id;

    public void DeleteSelf()
    {
        Destroy(gameObject);
    }
}