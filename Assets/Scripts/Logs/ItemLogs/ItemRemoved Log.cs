using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemovedLog : MonoBehaviour
{
    private void OnEnable(){
        EventSystem.Instance.ItemSuccessfullyUsedRemovedEvent += Log_;
    }
    private void OnDisable(){
        EventSystem.Instance.ItemSuccessfullyUsedRemovedEvent -= Log_;
    }

    private void Log_(int id){
        Debug.Log("Item successfully removed. ID: " + id);
    }
}
