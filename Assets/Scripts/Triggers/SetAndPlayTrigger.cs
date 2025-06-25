using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SetAndPlayTrigger : MonoBehaviour
{
    [SerializeField] private AudioClipAsset clipAsset;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(clipAsset != null)
            EventSystem.Instance.SetAndPlayAudio(clipAsset);
        DeleteSelf();
    }

    private void DeleteSelf() => Destroy(gameObject);
}
