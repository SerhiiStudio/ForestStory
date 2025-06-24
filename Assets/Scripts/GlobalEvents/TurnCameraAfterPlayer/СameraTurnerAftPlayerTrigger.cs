using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraTurnerAftPlayerTrigger : MonoBehaviour
{
    private event Action<float> onZoneExit; // Vill return
    private float timeTreshold = 0.2f;

    private Coroutine coroutine;



    public void SubscribeForTriggerExit(Action<float> methodAction) =>
        onZoneExit += methodAction;

    public void UnsubscribeForTriggerExit(Action<float> methodAction) =>
        onZoneExit -= methodAction;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }

        coroutine = StartCoroutine(ExtractPositionCoroutine(other.transform));
    }   

    // Waits a little and extracts x coordinate. Gives it to the event
    private IEnumerator ExtractPositionCoroutine(Transform playersTransform) 
    {
        var wait = new WaitForSeconds(timeTreshold);
        yield return wait;

        float xPlayerPosition = playersTransform.position.x;
        onZoneExit?.Invoke(xPlayerPosition); // Invoke the event
    } 
}
