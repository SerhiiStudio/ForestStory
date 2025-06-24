using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCameraByX : MonoBehaviour
{
    private void OnEnable()
    {
        EventSystem.Instance.TurnCameraByXEvent += TurnEventHandler;
    }
    private void OnDisable()
    {
        EventSystem.Instance.TurnCameraByXEvent -= TurnEventHandler;
    }

    private void TurnEventHandler(float xPos)
    {
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
