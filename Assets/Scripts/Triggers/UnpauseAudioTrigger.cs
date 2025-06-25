using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class UnpauseAudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioType aType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        EventSystem.Instance?.UnpauseAudioSystem(aType);
        DeleteSelf();
    }

    private void DeleteSelf() => Destroy(gameObject);
}
