using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ActivateGameObjTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjs;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach(var g in gameObjs)
        {
            if(g!=null)
                g.SetActive(true);
        }
    }
}
