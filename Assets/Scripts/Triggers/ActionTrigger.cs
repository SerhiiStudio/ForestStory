using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ActionTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent actions;
    private void OnTriggerEnter2D(Collider2D other)
    {
        actions?.Invoke();
    }
}
