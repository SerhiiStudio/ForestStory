using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraAftPlayerTurner : MonoBehaviour
{
    [SerializeField] private CameraPlace[] cameraPlaces; // Boundary is left inclusive so if first right and next left are the same use fRight - 0.01f
    [SerializeField] private CameraTurnerAftPlayerTrigger[]  triggers;

    private float onEnableTreshold = 0.6f; // Approximate time indeed


    [Serializable] 
    private struct CameraPlace
    {
        public float xCameraPlace;
        public float leftBorderValue;
        public float rightBorderValue; 
    }

    private void OnEnable() => StartCoroutine(SubscribeCoroutine());
    private void OnDisable() => Unsubscribe();
    private void Start() => FixBorderOverlaps();
    

    private IEnumerator SubscribeCoroutine()
    {
        var wait = new WaitForSeconds(onEnableTreshold);
        yield return wait;

        foreach(var trigger in triggers)
            trigger.SubscribeForTriggerExit(OnTriggerExitHandler);
    }

    private void Unsubscribe()
    {
        foreach(var trigger in triggers)
            trigger.UnsubscribeForTriggerExit(OnTriggerExitHandler);
    }

    private void OnTriggerExitHandler(float xPosition)
    {
        var place = DeterminePlace(xPosition);
        if (place != null)
        {
            float x = place.Value.xCameraPlace;
            TurnCameraToPlace(x);
            Debug.Log("Turned");
        }
    }

    private void TurnCameraToPlace(float x) =>
        EventSystem.Instance.TurnCameraByX(x);
    

    private CameraPlace? DeterminePlace(float xPosition)
    {
        foreach(var place in cameraPlaces)
        {
            if (place.leftBorderValue <= xPosition && place.rightBorderValue >= xPosition)
                return place;
        }

        return null;
    }

    private void FixBorderOverlaps()
    {
        for(int i = 1; i < cameraPlaces.Length; i++)
        {
            ref var placeA = ref cameraPlaces[i-1].rightBorderValue;
            ref var placeB = ref cameraPlaces[i].leftBorderValue;

            if(placeA == placeB)
                placeA -= 0.01f;
        }
    }
}
