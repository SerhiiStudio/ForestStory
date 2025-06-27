using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    [SerializeField] protected ItemData data;
    [SerializeField] protected int id = -1;
    public void Remove()
    {
        if ((EventSystem.Instance?.TakeItemOffInventory(data) ?? false) && data != null)
            {
                EventSystem.Instance.ItemSuccessfullyRemoved(id);
            }
    }
}
