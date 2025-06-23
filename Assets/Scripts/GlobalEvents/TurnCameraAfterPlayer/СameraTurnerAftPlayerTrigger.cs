using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class СameraTurnerAftPlayerTrigger : MonoBehaviour
{
    private event Action<float> onZoneEnter; // Vill return
    private float timeTreshold = 0.2f;

    private Coroutine coroutine;



    public void SubscribeForTriggerExit(Action<float> methodAction) =>
        onZoneEnter += methodAction;

    public void UnsubscribeForTriggerExit(Action<float> methodAction) =>
        onZoneEnter -= methodAction;

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
        onZoneEnter?.Invoke(xPlayerPosition); // Invoke the event
    } 
}
