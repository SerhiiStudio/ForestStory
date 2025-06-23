using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraAftPlayerTurner : MonoBehaviour
{
    [SerializeField] private CameraPlace[] cameraPlaces; // Boundary is left inclusive so if first right and next left are the same use fRight - 0.01f
    [SerializeField] private СameraTurnerAftPlayerTrigger[]  triggers;

    private float onEnableTreshold = 0.6f; // Approximate time indeed


    [Serializable] 
    private struct CameraPlace
    {
        public float xCameraPlace;
        public float leftBorderValue;
        public float rightBorderValue; 
    }

    private void OnEnable() => StartCoroutine(SubscribeCoroutine());
    

    private IEnumerator SubscribeCoroutine()
    {
        var wait = new WaitForSeconds(onEnableTreshold);
        yield return wait;

        foreach(var trigger in triggers)
        {
            trigger.SubscribeForTriggerExit(OnTriggerExitHandler);
        }
    }

    private void OnTriggerExitHandler(float xPosition)
    {

    }
}
