using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findsmtng : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var obj = FindObjectsOfType(typeof(TakeItemListener));
        foreach (var item in obj) 
        {
            Debug.LogWarning(item.name);
        }
    }

    
}
