using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsedLog : MonoBehaviour
{
    private void OnEnable(){
        EventSystem.Instance.ItemUsedEvent += Log_;
    }
    private void OnDisable(){
        EventSystem.Instance.ItemUsedEvent -= Log_;
    }

    private void Log_(int id, bool result){
        Debug.Log($"Item used. ID: {id}. Result: {result}");
    }
}
