using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameOnTriggerLog : MonoBehaviour
{
    private void OnEnable(){
        EventSystem.Instance.IteractionTriggers += Logg;
    }
    private void OnDisable(){
        EventSystem.Instance.IteractionTriggers -= Logg;
    }

    private void Logg(int id){

        Debug.Log("Trigger ID: " + id + " activated");
    }
}
