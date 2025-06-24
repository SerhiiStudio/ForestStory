using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraAftPlayerTurner : MonoBehaviour
{
    [SerializeField] private CameraTurnerAftPlayerTrigger[]  triggers;
    [SerializeField] private Camera cam;

    private float onEnableTreshold = 0.6f; // Approximate time indeed

    private void OnEnable() => StartCoroutine(SubscribeCoroutine());
    private void OnDisable() => Unsubscribe();
    

    private IEnumerator SubscribeCoroutine()
    {
        var wait = new WaitForSeconds(onEnableTreshold);
        yield return wait;

        foreach(var trigger in triggers)
            trigger.SubscribeForTriggerExit(OnTriggerExitHandler);
    }

    private void Unsubscribe()
    {
        if (triggers != null)
            foreach(var trigger in triggers)
                if (trigger != null)
                    trigger.UnsubscribeForTriggerExit(OnTriggerExitHandler);
    }

    private void OnTriggerExitHandler(int direction)
    {
        if (cam != null)
        {
            var transform = MoveCameraOneFrustum(cam, direction);
            TurnCameraToPlace(transform);
        }
    }

    private Vector3 MoveCameraOneFrustum(Camera cam, int direction)
    {
        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        Vector3 pos = cam.transform.position;
        pos.x += direction * width;
        return pos;
    }

    private void TurnCameraToPlace(Vector3 vector) =>
        cam.transform.position = vector;
}
