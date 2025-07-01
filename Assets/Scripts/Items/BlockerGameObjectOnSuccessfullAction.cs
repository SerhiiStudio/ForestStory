using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerGameObjectOnSuccessfullAction : MonoBehaviour
{
    [SerializeField] protected GameObject[] toBlock;
    [SerializeField] protected GameObject[] toUnblock;

    public void ExecuteBlocker()
    {
        foreach(var i in toBlock)
            if (i != null) i.SetActive(false);

        foreach(var i in toUnblock)
            if (i != null) i.SetActive(true);
    }
}
