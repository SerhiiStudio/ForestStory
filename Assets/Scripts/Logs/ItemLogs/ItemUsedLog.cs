using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsedLog : MonoBehaviour
{
    private void OnEnable(){
        EventSystem.Instance.ItemSuccessfullyUsedEvent += Log_;
    }
    private void OnDisable(){
        EventSystem.Instance.ItemSuccessfullyUsedEvent -= Log_;
    }

    private void Log_(int id){
        Debug.Log("Item successfully used. ID: " + id);
    }
}
