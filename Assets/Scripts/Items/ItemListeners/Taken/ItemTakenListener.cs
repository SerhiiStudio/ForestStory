using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemTakenListener : MonoBehaviour
{
    [SerializeField] private ItemData data;
    [SerializeField] private UnityEvent actionsIfTaken;
    [SerializeField] private UnityEvent actionsOnFault;

    private void OnEnable()
    {
        EventSystem.Instance.ItemAddedEvent += SuccessfullyTakenHandler;
        EventSystem.Instance.InventoryFullEvent += FaultHandler;
    }

    private void SuccessfullyTakenHandler(ItemData data, bool result)
    {
        if (data == this.data && result == true)
            actionsIfTaken?.Invoke();
    }

    private void FaultHandler(ItemData data)
    {
        if (data == this.data)
        {
            actionsOnFault?.Invoke();
        }
    }
}